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
    public partial class MixTransaction
    {
        private Regex editMatch = new Regex(@"([a-zA-Z]+)(\d+)", RegexOptions.Compiled | RegexOptions.CultureInvariant, TimeSpan.FromSeconds(1));

        private Regex filter = new Regex("[^0-9XSD]*", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant, TimeSpan.FromSeconds(1));
        private bool AddEntryDisabled = false;

        [Inject]
        private IRefreshService service { get; set; }

        [Inject]
        private IJSRuntime Js { get; set; }

        [CascadingParameter]
        public RepeatDataReturnWA repeatData { get; set; }

        private CultureInfo Curr = new CultureInfo("hi-IN");
        private NumberFormatInfo numberFormat { get; set; }
        private IList<Transaction>? Transactions { get; set; } = new List<Transaction>();

        private Transaction? Tempdata { get; set; }
        private bool Editmode, NotRefreshing = true;
        private Inventory? invInfo { get; set; }

        private double Total;
        private int snoCountStart = 0;
        private bool DigitEnabled { get; set; }
        private bool listEnabled;
        private bool Prz1Enabled { get; set; }

        private bool Prz2Enabled { get; set; }
        private int prz1Limit, prz2Limit;
        private string CurrentDigit;
        private bool loading = true;
        private bool AutoPrize = false;

        private int? _Prize1;

        public int? Prize1 {
            get { return _Prize1; }
            set {
                if (Prize1 is not null && (value ?? 0) > prz1Limit)
                {
                    new Task(async () => {
                        await showDialog("Limit Exceeded", "");
                        await Js.InvokeVoidAsync("focusInput", "Prize1");
                    }).Start();
                    //var result = DialogService.ShowMessageBox("Limit Exceeded", "Ok").Result;
                    //Js.InvokeAsync<object>("alert", "Limit Exceeded");
                    //jsModule.InvokeVoidAsync("focusInput", "Prize1");
                }
                _Prize1 = value;
            }
        }

        private int? _Prize2;

        public int? Prize2 {
            get { return _Prize2; }
            set {
                if (Prize2 is not null && (value ?? 0) > prz2Limit)
                {
                    new Task(async () => {
                        await showDialog("Limit Exceeded", "");
                        await Js.InvokeVoidAsync("focusInput", "Prize2");
                    }).Start();
                    //var result = DialogService.ShowMessageBox("Limit Exceeded", "Ok").Result;
                    //Js.InvokeAsync<object>("alert", "Limit Exceeded");
                    //jsModule.InvokeVoidAsync("focusInput", "Prize2");
                }
                _Prize2 = value;
            }
        }

        private string? _digit;

        public string? Digits {
            get { return _digit; }
            set => _digit = filter.Replace(value ?? "", string.Empty);
        }

        //private IJSObjectReference jsModule;
        private int SearchLimit = 4;

        private string InvNo, Ref, Code, PartyName;
        private int _dropSel = 1;

        public int DropSel {
            get => _dropSel;
            set {
                _dropSel = value;
                switch (value)
                {
                    case 1:
                        SearchLimit = 4;
                        CurrentDigit = "";
                        break;

                    case 2:
                        SearchLimit = 1;
                        CurrentDigit = "X";
                        break;

                    case 3:
                        SearchLimit = 1;
                        CurrentDigit = "XX";
                        break;

                    case 4:
                        SearchLimit = 1;
                        CurrentDigit = "XXX";
                        break;

                    case 5:
                        SearchLimit = 2;
                        CurrentDigit = "X";
                        break;

                    case 6:
                        SearchLimit = 2;
                        CurrentDigit = "XX";
                        break;

                    case 7:
                        SearchLimit = 3;
                        CurrentDigit = "X";
                        break;

                    case 8:
                        SearchLimit = 1;
                        CurrentDigit = "D";
                        break;

                    case 9:
                        SearchLimit = 1;
                        CurrentDigit = "S";
                        break;

                    default:
                        break;
                }

                Digits = "";
            }
        }

        protected override void OnInitialized()
        {
            //jsModule = await Js.InvokeAsync<IJSObjectReference>("import", "./js/functions.js");
            Js.InvokeVoidAsync("iphoneFocus");

            numberFormat = Curr.NumberFormat;
            numberFormat.CurrencySymbol = "";
        }

        private async Task digitKeyDown(KeyboardEventArgs x)
        {
            if (string.Equals(x.Key, "Enter", StringComparison.OrdinalIgnoreCase))
            {
                await Js.InvokeVoidAsync("focusInput", "Prize1");
            }
        }

        private async Task<bool?> showDialog(string Title, string message)
        {
            Prz1Enabled = Prz2Enabled = false;
            await Js.InvokeVoidAsync("document.activeElement.blur");
            var res = await DialogService.ShowMessageBox(Title, message, options: new MudBlazor.DialogOptions() { CloseOnEscapeKey = true });
            Prz1Enabled = Prz2Enabled = true;
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
                    if (Prize1 is not null && Prize2 is not null && (Editmode || (Prize1 > 0 && Prize2 > 0)) && (await Api.GetCurrentBalance() - Prize1 + Prize2) < 0)
                    {
                        await showDialog("Limit Exceeded", "");
                    }
                    else
                    {
                        Digits.Throw().IfNullOrWhiteSpace(x => x);
                        if (DropSel != 1 && Digits.Length != SearchLimit)
                        {
                            await showDialog("Invalid Digit", "");
                        }
                        else
                        {
                            var ret = await Api.PktCheck((CurrentDigit + Digits).ToUpperInvariant());
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
                                    var trans = new Transaction()
                                    {
                                        vno = invInfo.Vno,
                                        code = cdRel.rCode,
                                        Digit = (CurrentDigit + Digits).ToUpperInvariant(),
                                        Prize1 = Prize1 ?? 0,
                                        Prize2 = Prize2 ?? 0,
                                        MKey = invInfo.propKey,
                                    };
                                    var d = Api.DType;
                                    var invD = new EntryData()
                                    {
                                        transaction = trans,
                                        dbf = "FAROOQ",
                                        xid = cdRel.UName,
                                        xdtype = d[0],
                                        xmode = 0,
                                        xpamt1 = 0,
                                        xpamt2 = 0,
                                        xpid = 'X',
                                    };
                                    if (Editmode)
                                    {
                                        invD.lmkey = Tempdata?.lmkey ?? 0;
                                        invD.xmkey = Tempdata?.MKey ?? 0;
                                    }
                                    Tempdata = await Api.MakeNewEntry(invD);
                                    if (string.Equals(Tempdata.code, cdRel.rCode, StringComparison.Ordinal))
                                    {
                                        if (Transactions!.Any() && !string.Equals(Tempdata.sNo, Transactions[^1].sNo, StringComparison.OrdinalIgnoreCase))
                                        {
                                            listEnabled = Editmode;

                                            refreshPage();
                                        }
                                        else
                                        {
                                            Tempdata.sNo = "0";
                                            Transactions.Add(Tempdata);
                                            Total += Tempdata.Prize1 + Tempdata.Prize2;
                                            //await Api.UpdateAllBalance();
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
                                            refreshPage();
                                            Editmode = false;
                                            return;
                                        }
                                    }
                                    if (!AutoPrize)
                                    {
                                        Prize1 = null;
                                        Prize2 = null;
                                    }
                                    var ret2 = await Api.PktCheck((CurrentDigit + Digits).ToUpperInvariant());
                                    if (ret2 is not null && string.IsNullOrEmpty(ret2.msg))
                                    {
                                        prz1Limit = (ret2.xamt1 - ret2.xuamt1) ?? 0;
                                        prz2Limit = (ret2.xamt2 - ret2.xuamt2) ?? 0;
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
                    //await Js.InvokeVoidAsync("focusInput", "MixDigitInput");
                }
            }
        }

        private async Task Prz1KeyDown(KeyboardEventArgs x)
        {
            if (string.Equals(x.Key, "Enter", StringComparison.OrdinalIgnoreCase))
            {
                await Js.InvokeVoidAsync("focusInput", "Prize2");
            }
        }

        private async Task Prz2KeyDown(KeyboardEventArgs x)
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
                if (DropSel != 1 && Digits.Length != SearchLimit)
                {
                    await showDialog("Invalid Digit", "");
                    await Js.InvokeVoidAsync("focusInput", "MixDigitInput");
                }
                else
                {
                    var ret = await Api.PktCheck((CurrentDigit + Digits).ToUpperInvariant());
                    if (ret is not null)
                    {
                        if (string.IsNullOrEmpty(ret.msg))
                        {
                            prz1Limit = (ret.xamt1 - ret.xuamt1) ?? 0;
                            prz2Limit = (ret.xamt2 - ret.xuamt2) ?? 0;
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

        private async Task OnDigitFocus(FocusEventArgs args)
        {
            prz1Limit = prz2Limit = 0;
        }

        private async Task OnListClick(MouseEventArgs args)
        {
            try
            {
                Prz1Enabled = false;
                Prz2Enabled = false;
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
                Prz1Enabled = true;
                Prz2Enabled = true;
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

            DigitEnabled = Prz1Enabled = Prz2Enabled = repeatData?.Uac == true && await Api.GetDigitEnabled();
            if (invInfo is null || invInfo?.propKey == 0)
            {
                refreshPage();
            }
        }

        private async void refreshPage()
        {
            if (NotRefreshing)
            {
                NotRefreshing = false;
                loading = true;
                if (DigitEnabled)
                {
                    invInfo = await Api.GetInvInfo();
                    if (invInfo is null || invInfo?.Vno == -1)
                    {
                        var cdrel = await Api.GetCdrel();
                        var sch = await Api.GetSch();
                        var qty = await Api.IsQtyUser();
                        var invD = new InvData()
                        { dbf = "FAROOQ", xdemand = false, xmkey = 0, xid = cdrel.UName, xref = "Online", xsc = 0, xvid = "1SL", xdtype = Api.DType[0], db = "", };
                        //Dmode = 0
                        var nParty = (await Api.GetParty()).ShallowCopy();
                        if (sch.Prz2 == 5)
                        {
                            if (qty)
                            {
                                nParty.Ak_win2 = nParty.Ak_win2 != 0 ? Math.Ceiling(nParty.Ak_win2 * 3 / 5) : 0;
                                nParty.Fc_win2 = nParty.Fc_win2 != 0 ? Math.Ceiling(nParty.Fc_win2 * 3 / 5) : 0;
                                nParty.Op_win2 = nParty.Op_win2 != 0 ? Math.Ceiling(nParty.Op_win2 * 3 / 5) : 0;
                                nParty.Td_win2 = nParty.Td_win2 != 0 ? Math.Ceiling(nParty.Td_win2 * 3 / 5) : 0;
                                nParty.Xak_win2 = nParty.Xak_win2 != 0 ? Math.Ceiling(nParty.Xak_win2 * 3 / 5) : 0;
                                nParty.Xtd_win2 = nParty.Xtd_win2 != 0 ? Math.Ceiling(nParty.Xtd_win2 * 3 / 5) : 0;
                            }
                            else
                            {
                                nParty.Ak_win2 = nParty.Ak_win1 != 0 ? nParty.Ak_win1 / 5 : 0;
                                nParty.Fc_win2 = nParty.Fc_win1 != 0 ? nParty.Fc_win1 / 5 : 0;
                                nParty.Op_win2 = nParty.Op_win1 != 0 ? nParty.Op_win1 / 5 : 0;
                                nParty.Td_win2 = nParty.Td_win1 != 0 ? nParty.Td_win1 / 5 : 0;
                                nParty.Xak_win2 = nParty.Xak_win1 != 0 ? nParty.Xak_win1 / 5 : 0;
                                nParty.Xtd_win2 = nParty.Xtd_win1 != 0 ? nParty.Xtd_win1 / 5 : 0;
                            }
                        }

                        invD.party = nParty;
                        var res = await Api.MakeNewInv(invD);
                        invInfo = await Api.GetInvInfo();
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
                NotRefreshing = true;
            }
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

                        var alphaPart = entry.Digit.Where(x => char.IsLetter(x)).Aggregate("", (current, c) => current + c);
                        var numberPart = entry.Digit.Where(x => !char.IsLetter(x)).Aggregate("", (current, c) => current + c);
                        if (alphaPart?.Length == 0)
                        {
                            DropSel = 1;
                        }
                        else
                        {
                            switch (numberPart.Length)
                            {
                                case 1 when string.Equals(alphaPart, "X", StringComparison.Ordinal):
                                    DropSel = 2;
                                    break;

                                case 1 when string.Equals(alphaPart, "XX", StringComparison.Ordinal):
                                    DropSel = 3;
                                    break;

                                case 1 when string.Equals(alphaPart, "XXX", StringComparison.Ordinal):
                                    DropSel = 4;
                                    break;

                                case 2 when string.Equals(alphaPart, "X", StringComparison.Ordinal):
                                    DropSel = 5;
                                    break;

                                case 2 when string.Equals(alphaPart, "XX", StringComparison.Ordinal):
                                    DropSel = 6;
                                    break;

                                case 3 when string.Equals(alphaPart, "X", StringComparison.Ordinal):
                                    DropSel = 7;
                                    break;

                                case 1 when string.Equals(alphaPart, "D", StringComparison.Ordinal):
                                    DropSel = 8;
                                    break;

                                case 1 when string.Equals(alphaPart, "S", StringComparison.Ordinal):
                                    DropSel = 9;

                                    break;

                                default:
                                    break;
                            }
                        }
                        Digits = numberPart;
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
                var TransactionsInfo = await Api.GetTransactionsListMix(amt, invInfo?.Vno ?? 0);
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