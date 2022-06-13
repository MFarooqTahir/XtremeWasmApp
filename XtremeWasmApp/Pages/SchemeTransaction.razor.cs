using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

using System.Globalization;
using System.Text.RegularExpressions;

using Throw;

using XtremeModels;

using XtremeWasmApp.Models;
using XtremeWasmApp.Services;

namespace XtremeWasmApp.Pages
{
    public partial class SchemeTransaction
    {
        private Regex editMatch = new Regex(@"([a-zA-Z]+)(\d+)", RegexOptions.Compiled | RegexOptions.CultureInvariant, TimeSpan.FromSeconds(1));
        private Regex filter = new Regex("[^0-9]*", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant, TimeSpan.FromSeconds(1));
        private bool AddEntryDisabled = false;

        [Inject]
        private IRefreshService service { get; set; }

        [Inject]
        private IJSRuntime Js { get; set; }

        [CascadingParameter]
        public RepeatDataReturnWA repeatData { get; set; }

        private int DropSel = 0;
        private CultureInfo Curr = new CultureInfo("hi-IN");
        private NumberFormatInfo numberFormat { get; set; }

        private IList<Transaction>? Transactions { get; set; } = new List<Transaction>();
        private Transaction? Tempdata { get; set; }

        private bool Editmode;
        private Inventory? invInfo { get; set; }

        private double Total { get; set; }
        private int snoCountStart = 0;
        private bool DigitEnabled { get; set; }

        private bool listEnabled;
        private bool Prz1Enabled { get; set; }
        private bool RateEnabled { get; set; }

        private bool Prz2Enabled { get; set; }
        private double[] win = { 0, 0, 0 };

        private int prz1Limit, prz2Limit;
        private bool loading = true;
        private bool AutoPrize = false;
        private double? _Prize1;
        private double? _rate;

        public double? Rate {
            get { return _rate; }
            set {
                if (value is not null)
                {
                    calPrzChange();
                }
                _rate = value;
            }
        }

        public double? Prize1 {
            get {
                return _Prize1;
            }

            set {
                if (Prize1 is not null && (value ?? 0) > prz1Limit)
                {
                    new Task(async () => {
                        //await showDialog("Limit Exceeded", "");
                        //await jsModule.InvokeVoidAsync("focusInput", "Prize1");
                    }).Start();
                }

                _Prize1 = Math.Round(value ?? 0, 2);
            }
        }

        private double? _Prize2;

        public double? Prize2 {
            get {
                return _Prize2;
            }

            set {
                if (Prize2 is not null && (value ?? 0) > prz2Limit)
                {
                    new Task(async () => {
                        //await showDialog("Limit Exceeded", "");
                        //await jsModule.InvokeVoidAsync("focusInput", "Prize2");
                    }).Start();
                }

                _Prize2 = Math.Round(value ?? 0, 2);
            }
        }

        private string? _digit;

        public string? Digits {
            get {
                return _digit;
            }

            set => _digit = filter.Replace(value ?? "", string.Empty);
        }

        //private IJSObjectReference jsModule;
        private string InvNo, Ref, Code, PartyName;

        protected override async Task OnInitializedAsync()
        {
            //jsModule = await Js.InvokeAsync<IJSObjectReference>("import", "./js/functions.js");
            await Js.InvokeVoidAsync("iphoneFocus");
            numberFormat = Curr.NumberFormat;
            numberFormat.CurrencySymbol = "";
        }

        private async Task digitKeyDown(KeyboardEventArgs x)
        {
            if (string.Equals(x.Key, "Enter", StringComparison.OrdinalIgnoreCase))
            {
                await Js.InvokeVoidAsync("focusInput", "Rate");
            }
        }

        private async Task<bool?> showDialog(string Title, string message)
        {
            await Js.InvokeVoidAsync("document.activeElement.blur");
            var res = await DialogService.ShowMessageBox(Title, message, options: new MudBlazor.DialogOptions()
            { CloseOnEscapeKey = true });
            return res;
        }

        private async Task OnEditCancel(MouseEventArgs args)
        {
            Tempdata = new();
            Digits = null;
            Prize1 = null;
            Prize2 = null;
            Editmode = false;
        }

        private async Task OnDoneClick(MouseEventArgs args)
        {
            if (!AddEntryDisabled)
            {
                AddEntryDisabled = true;
                try
                {
                    if (Rate is not null && (await Api.GetCurrentBalance() - Prize1 + Prize2) < 0)
                    {
                        await showDialog("Limit Exceeded", "");
                    }
                    else
                    {
                        Digits.Throw().IfNullOrWhiteSpace(x => x);
                        if (Digits.Length != 3 && Digits.Length != 4)
                        {
                            await showDialog("Invalid Digit", "");
                        }
                        else
                        {
                            await calPrzChange();
                            var txtDigit = Digits;
                            var ret = await Api.PktCheck(txtDigit);
                            if (ret is not null && string.IsNullOrEmpty(ret.msg))
                            {
                                prz1Limit = (ret.xamt1 - ret.xuamt1) ?? 0;
                                prz2Limit = (ret.xamt2 - ret.xuamt2) ?? 0;
                                if (Prize1 > prz1Limit)
                                {
                                    await showDialog("Prize 1 exceeded limit", "");
                                    Digits = "";
                                    await Js.InvokeVoidAsync("focusInput", "Prize1");
                                }
                                else if (Prize2 > prz2Limit)
                                {
                                    await showDialog("Prize 2 exceeded limit", "");
                                    //await DialogService.ShowMessageBox("Prize 2 exceeded limit", "");
                                    Digits = "";
                                    await Js.InvokeVoidAsync("focusInput", "Prize2");
                                }
                                else
                                {
                                    var cdRel = await Api.GetCdrel();
                                    var partySchT = await Api.GetpartySchTrans();
                                    var trans = new Transaction()
                                    { vno = invInfo.Vno, code = cdRel.rCode, Digit = Digits.ToUpperInvariant(), Prize1 = Prize1 ?? 0, Prize2 = Prize2 ?? 0, MKey = invInfo.propKey, };
                                    var invD = new EntryDataSch()
                                    {
                                        dbf = "FAROOQ",
                                        xmkey = 0,
                                        xid = cdRel.UName,
                                        xmode = 0,
                                        xpamt1 = 0,
                                        xpamt2 = 0,
                                        xxmkey = invInfo.propKey,
                                        xpid = txtDigit.Length.ToString(),
                                        xpkt = txtDigit,
                                        xdtype = "W",
                                        xscode = txtDigit.Length == 3 ? "Ring" : "Packet",
                                        xwin1 = Convert.ToInt32(win[0]),
                                        xwin2 = Convert.ToInt32(win[1]),
                                        xwin3 = Convert.ToInt32(win[2]),
                                        xsamt1 = Prize1 ?? 0,
                                        xsamt2 = Prize2 ?? 0,
                                        xsrate = Rate ?? 0,
                                        xscom = txtDigit.Length == 3 ? partySchT.Std_com : partySchT.Sfc_com,
                                        xsown = txtDigit.Length == 3 ? partySchT.Std_own : partySchT.Sfc_own,
                                    };
                                    if (Editmode)
                                    {
                                        invD.xmkey = Tempdata?.MKey ?? 0;
                                    }

                                    Tempdata = await Api.MakeNewEntrySch(invD);
                                    if (string.Equals(Tempdata.code, "0", StringComparison.Ordinal))
                                    {
                                        if (Transactions!.Any() && !string.Equals(Tempdata.sNo, Transactions[^1].sNo, StringComparison.OrdinalIgnoreCase))
                                        {
                                            listEnabled = Editmode;
                                            await refreshPage();
                                        }
                                        else
                                        {
                                            Transactions.Add(Tempdata);
                                            Total += Tempdata.Prize1 + Tempdata.Prize2 + Rate ?? 0;
                                        }
                                    }
                                    else
                                    {
                                        if (string.Equals(Tempdata.code, "1", StringComparison.Ordinal))
                                        {
                                            await showDialog("Draw Closed", "");
                                            nav.NavigateTo("/");
                                            Editmode = false;
                                            return;
                                        }
                                        else if (string.Equals(Tempdata.code, "2", StringComparison.Ordinal))
                                        {
                                            await showDialog("Limit has been reached", "");
                                            Editmode = false;
                                            return;
                                        }
                                        else if (string.Equals(Tempdata.code, "3", StringComparison.Ordinal))
                                        {
                                            await showDialog("Invoice has been closed", "");
                                            await refreshPage();
                                            Editmode = false;
                                            return;
                                        }
                                    }

                                    if (!AutoPrize)
                                    {
                                        Rate = null;
                                        var ret2 = await Api.PktCheck(Digits.ToUpperInvariant());
                                        if (ret2 is not null && string.IsNullOrEmpty(ret2.msg))
                                        {
                                            prz1Limit = (ret2.xamt1 - ret2.xuamt1) ?? 0;
                                            prz2Limit = (ret2.xamt2 - ret2.xuamt2) ?? 0;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                var result2 = await showDialog("Error ", ret.msg);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    await showDialog("There was an error", "Ok");
                }
                finally
                {
                    AddEntryDisabled = false;
                    Editmode = false;
                    Digits = null;
                    service.CallRequestRefresh();
                    await Js.InvokeVoidAsync("focusInput", "MixDigitInput");
                    //await jsModule.InvokeVoidAsync("focusInput", "MixDigitInput");
                }
            }
        }

        private async Task RateKeyDown(KeyboardEventArgs x)
        {
            if (string.Equals(x.Key, "Enter", StringComparison.OrdinalIgnoreCase))
            {
                await OnDoneClick(null);
            }
        }

        private async Task lostDigitFocus(FocusEventArgs args)
        {
            if (!string.IsNullOrEmpty(Digits))
            {
                if (Digits.Length != 3 && Digits.Length != 4)
                {
                    await showDialog("Invalid Digit", "");
                    await Js.InvokeVoidAsync("focusInput", "MixDigitInput");
                }
                else
                {
                    var ret = await Api.PktCheck(Digits);
                    if (ret is not null)
                    {
                        if (string.IsNullOrEmpty(ret.msg))
                        {
                            prz1Limit = (ret.xamt1 - ret.xuamt1) ?? 0;
                            prz2Limit = (ret.xamt2 - ret.xuamt2) ?? 0;
                            if (Rate is not null)
                            {
                                await calPrzChange();
                            }
                        }
                        else
                        {
                            var result = await showDialog(ret.msg, "");
                            Digits = "";
                            await Js.InvokeVoidAsync("focusInput", "MixDigitInput");
                        }
                    }
                }
            }
        }

        private async Task calPrzChange()
        {
            if (Rate >= 10000.00)
            {
                Rate = null;
            }
            else
            {
                var party = await Api.GetParty();

                var sch = await Api.GetSch();
                var partytransSch = await Api.GetpartySchTrans();
                var txtDigit = Digits.ToUpperInvariant();
                if (txtDigit.Length == 3)
                {
                    win[0] = (party.Std1 / 100 * Rate) ?? 0;
                    if (sch.Prz2 == 5)
                    {
                        win[1] = (party.Std3 / 100 * Rate) ?? 0;
                    }
                    else
                    {
                        win[1] = (party.Std2 / 100 * Rate) ?? 0;
                    }
                    win[2] = 0;
                }
                else if (txtDigit.Length == 4)
                {
                    win[0] = (party.Sfc1 / 100 * Rate) ?? 0;
                    if (sch.Prz2 == 5)
                    {
                        win[1] = (party.Sfc3 / 100 * Rate) ?? 0;
                    }
                    else
                    {
                        win[1] = (party.Sfc2 / 100 * Rate) ?? 0;
                    }
                    win[2] = (party.Sfc4 / 100 * Rate) ?? 0;
                    if (win[2] > 0)
                    {
                        win[2] = win[2] * 3 / 5;
                    }
                }
                for (int i = 0; i < win.Length; i++)
                {
                    win[i] = Math.Round(win[i], 0);
                    if (win[i].ToString(CultureInfo.DefaultThreadCurrentCulture)[^1] == '7')
                    {
                        win[i]--;
                    }
                }
                if (txtDigit.Length == 3)
                {
                    Prize1 = (win[0] + (win[0] / 100 * partytransSch.Std_own)) / partytransSch.Win_Rate3;
                    Prize2 = (win[1] + (win[1] / 100 * partytransSch.Std_own)) / partytransSch.Win_Rate4;
                }
                else if (txtDigit.Length == 4)
                {
                    Prize1 = (win[0] + (win[0] / 100 * partytransSch.Sfc_own)) / partytransSch.Win_Rate1;
                    Prize2 = (win[1] + (win[1] / 100 * partytransSch.Sfc_own)) / partytransSch.Win_Rate2;
                }
                //txtWin1.Text = win[0].ToString("N2", Curr);
                //txtWin2.Text = win[1].ToString("N2", Curr);
                //txtWin3.Text = win[2].ToString("N2", Curr);
                StateHasChanged();
                if (Prize1 > prz1Limit || Prize2 > prz2Limit)
                {
                    await showDialog("Prize Limit Exceeded", "");
                }
            }
        }

        private async Task OnDigitFocus(FocusEventArgs args)
        {
            prz1Limit = prz2Limit = 0;
        }

        private async Task OnListClick(MouseEventArgs args)
        {
            try
            {
                //Prz1Enabled = false;
                //Prz2Enabled = false;
                RateEnabled = false;
                AddEntryDisabled = true;
                listEnabled = true;
                await GetTransList();
            }
            catch (Exception ex)
            {
                await showDialog("There was an error", "");
            }
            finally
            {
                //Prz1Enabled = true;
                //Prz2Enabled = true;
                RateEnabled = true;
                AddEntryDisabled = false;
            }
        }

        private async Task OnPrz1Focus(FocusEventArgs args)
        {
            // await jsModule.InvokeVoidAsync("scrollToTop");
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (repeatData?.Uac == false || repeatData?.DrawBlocked == true || repeatData?.DrawCompleted == true || repeatData?.RelationBlocked == true || repeatData?.RelationActive == false)
            {
                nav.NavigateTo("/");
            }
            //Prz1Enabled = Prz2Enabled =
            DigitEnabled = RateEnabled = repeatData?.Uac == true && await Api.GetDigitEnabled();
            if (firstRender)
            {
                await refreshPage();
            }
        }

        private async Task refreshPage()
        {
            loading = true;
            if (DigitEnabled)
            {
                invInfo = await Api.GetInvInfo("1SM");
                if (invInfo is null || invInfo?.Vno == -1)
                {
                    var cdrel = await Api.GetCdrel();
                    var partySch = await Api.GetpartySchTrans();
                    var invD = new InvDataSch()
                    {
                        dbf = "FAROOQ",
                        xdemand = false,
                        xmkey = 0,
                        xid = cdrel.UName,
                        xref = "Online",
                        xsc = 0,
                        xvid = "1SM",
                        xdtype = "W",
                        xcode = cdrel.rCode,
                        sfcom = partySch.Sfc_com,
                        sfown = partySch.Sfc_own,
                        stcom = partySch.Std_com,
                        stown = partySch.Std_own,
                        wrate1 = partySch.Win_Rate1,
                        wrate2 = partySch.Win_Rate2,
                        wrate3 = partySch.Win_Rate3,
                        wrate4 = partySch.Win_Rate4
                    };

                    var res = await Api.MakeNewInvSch(invD);
                    invInfo = await Api.GetInvInfo("1SM");
                }

                if (invInfo is null || invInfo?.xres == 1)
                {
                    var result = await showDialog("Draw Closed", "");
                    nav.NavigateTo("/");
                }
                else
                {
                    var party = await Api.GetParty();
                    InvNo = invInfo?.Vno.ToString("D4");
                    Ref = invInfo?.Ref;
                    Code = party.Code;
                    PartyName = party.Name;
                    await GetTransList(listEnabled ? 0 : 5);
                    StateHasChanged();
                }
            }

            loading = false;
        }

        private async Task OnEntryClick(int Mkey)
        {
            try
            {
                var entry = Transactions.First(x => x.MKey == Mkey);
                if (entry is not null)
                {
                    bool res = await Api.CheckEntryEdit(Mkey);
                    if (res)
                    {
                        Tempdata = entry;
                        Editmode = true;
                        Prize2 = Prize1 = null;
                        StateHasChanged();
                        Digits = entry.Digit;
                        await lostDigitFocus(null);
                        Prize1 = int.Parse(entry.Prize1.ToString(), Curr);
                        Prize2 = int.Parse(entry.Prize2.ToString(), Curr);
                        StateHasChanged();
                    }
                    else
                    {
                        await showDialog("Edit Not Allowed", "");
                    }
                }
            }
            catch (Exception ex)
            {
                Editmode = false;
                await showDialog("There was an error", "");
            }
        }

        private async Task GetTransList(int amt = 0)
        {
            if (DigitEnabled)
            {
                var TransactionsInfo = await Api.GetTransactionsListMix(amt, invInfo?.Vno ?? 0, "1SM");
                if (TransactionsInfo is not null)
                {
                    Transactions = TransactionsInfo.Transactions;
                    if (amt != 0 && amt < TransactionsInfo.TotalRows)
                    {
                        snoCountStart = TransactionsInfo.TotalRows - amt + 1;
                    }
                    else
                    {
                        snoCountStart = 1;
                    }

                    Total = TransactionsInfo.InvoiceTotal;
                }
            }
        }
    }
}