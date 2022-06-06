using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

using System.Globalization;
using System.Text.RegularExpressions;

using Throw;

using XtremeModels;

using XtremeWasmApp.Models;

namespace XtremeWasmApp.Pages
{
    public partial class MixTransaction
    {
        private Regex filter = new Regex("[^0-9XSD]*", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant, TimeSpan.FromSeconds(1));
        private bool AddEntryDisabled = false;

        [Inject]
        private IJSRuntime Js { get; set; }

        [CascadingParameter]
        public RepeatDataReturnWA repeatData { get; set; }

        private CultureInfo Curr = new CultureInfo("hi-IN");
        private NumberFormatInfo numberFormat { get; set; }

        private IList<Transaction>? Transactions { get; set; } = new List<Transaction>();

        private Transaction? Tempdata { get; set; }

        private Inventory? invInfo { get; set; }

        private double Total;
        private int snoCountStart = 0;
        private bool DigitEnabled { get; set; }

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
                if ((value ?? 0) > prz1Limit)
                {
                    new Task(async () => {
                        await DialogService.ShowMessageBox("Limit Exceeded", "Ok");
                        await jsModule.InvokeVoidAsync("focusInput", "Prize1");
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
                if ((value ?? 0) > prz2Limit)
                {
                    new Task(async () => {
                        await DialogService.ShowMessageBox("Limit Exceeded", "Ok");
                        await jsModule.InvokeVoidAsync("focusInput", "Prize2");
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

        private IJSObjectReference jsModule;
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

        protected override async Task OnInitializedAsync()
        {
            jsModule = await Js.InvokeAsync<IJSObjectReference>("import", "./js/functions.js");
            await Js.InvokeVoidAsync("iphoneFocus");
            numberFormat = Curr.NumberFormat;
            numberFormat.CurrencySymbol = "";
        }

        private async Task digitKeyDown(KeyboardEventArgs x)
        {
            if (string.Equals(x.Key, "Enter", StringComparison.OrdinalIgnoreCase))
            {
                await jsModule.InvokeVoidAsync("focusInput", "Prize1");
            }
        }

        private async Task OnDoneClick(MouseEventArgs args)
        {
            AddEntryDisabled = true;
            try
            {
                Digits.Throw().IfNullOrWhiteSpace(x => x);
                mixpktchkModel? ret = await Api.PktCheck(CurrentDigit + Digits);
                if (ret is not null && string.IsNullOrEmpty(ret.msg))
                {
                    prz1Limit = (ret.xamt1 - ret.xuamt1) ?? 0;
                    prz2Limit = (ret.xamt2 - ret.xuamt2) ?? 0;
                    if (Prize1 > prz1Limit)
                    {
                        var result = await DialogService.ShowMessageBox("Prize 1 exceeded limit", "Ok");
                        Digits = "";
                        await jsModule.InvokeVoidAsync("focusInput", "Prize1");
                    }
                    else if (Prize2 > prz2Limit)
                    {
                        var result = await DialogService.ShowMessageBox("Prize 2 exceeded limit", "Ok");
                        Digits = "";
                        await jsModule.InvokeVoidAsync("focusInput", "Prize2");
                    }
                    else
                    {
                        var cdRel = await Api.GetCdrel();
                        var trans = new Transaction()
                        {
                            vno = invInfo.Vno,
                            code = cdRel.rCode,
                            Digit = CurrentDigit + Digits,
                            Prize1 = Prize1 ?? 0,
                            Prize2 = Prize2 ?? 0,
                            MKey = invInfo.propKey
                        };
                        var invD = new EntryData()
                        {
                            transaction = trans,
                            dbf = "FAROOQ",
                            xmkey = 0,
                            xid = cdRel.UName,
                            xdtype = 'W',
                            xmode = 0,
                            xpamt1 = 0,
                            xpamt2 = 0,
                            xpid = 'X',
                        };
                        Tempdata = await Api.MakeNewEntry(invD);
                        if (string.Equals(Tempdata.code, cdRel.rCode, StringComparison.Ordinal))
                        {
                            if (Transactions!.Any() && !string.Equals(Tempdata.sNo, Transactions[^1].sNo, StringComparison.OrdinalIgnoreCase))
                            {
                                await refreshPage();
                            }
                            else
                            {
                                Transactions.Add(Tempdata);
                                Total += Tempdata.Prize1 + Tempdata.Prize2;
                                await Api.UpdateAllBalance();
                            }
                        }
                        else
                        {
                            if (string.Equals(Tempdata.code, "1", StringComparison.Ordinal))
                            {
                                var result = await DialogService.ShowMessageBox("Draw Closed", "Ok");
                                nav.NavigateTo("/");
                                return;
                            }
                            else if (string.Equals(Tempdata.code, "2", StringComparison.Ordinal))
                            {
                                var result = await DialogService.ShowMessageBox("Limit has been reached", "Ok");
                                return;
                            }
                            else if (string.Equals(Tempdata.code, "3", StringComparison.Ordinal))
                            {
                                var result = await DialogService.ShowMessageBox("Invoice has been closed", "Ok");
                                await refreshPage();
                                return;
                            }
                        }
                        if (!AutoPrize)
                        {
                            Prize1 = null;
                            Prize2 = null;
                        }
                        var ret2 = await Api.PktCheck(CurrentDigit + Digits);
                        if (ret2 is not null && string.IsNullOrEmpty(ret2.msg))
                        {
                            prz1Limit = (ret2.xamt1 - ret2.xuamt1) ?? 0;
                            prz2Limit = (ret2.xamt2 - ret2.xuamt2) ?? 0;
                        }
                        Digits = null;
                        await jsModule.InvokeVoidAsync("focusInput", "MixDigitInput");
                    }
                }
                else
                {
                    var result2 = await DialogService.ShowMessageBox("Error " + ret.msg, "Ok");
                }
            }
            catch (Exception ex)
            {
                Digits = null;
                await DialogService.ShowMessageBox("There was an error", "Ok");
                await jsModule.InvokeVoidAsync("focusInput", "MixDigitInput");
            }
            finally
            {
                AddEntryDisabled = false;
            }
        }

        private async Task Prz1KeyDown(KeyboardEventArgs x)
        {
            if (string.Equals(x.Key, "Enter", StringComparison.OrdinalIgnoreCase))
            {
                await jsModule.InvokeVoidAsync("focusInput", "Prize2");
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
                mixpktchkModel? ret = await Api.PktCheck(CurrentDigit + Digits);
                if (ret is not null)
                {
                    if (string.IsNullOrEmpty(ret.msg))
                    {
                        prz1Limit = (ret.xamt1 - ret.xuamt1) ?? 0;
                        prz2Limit = (ret.xamt2 - ret.xuamt2) ?? 0;
                    }
                    else
                    {
                        var result = await DialogService.ShowMessageBox(ret.msg, "Ok");
                        Digits = "";
                        await jsModule.InvokeVoidAsync("focusInput", "MixDigitInput");
                    }
                }
            }
        }

        private async Task OnDigitFocus(FocusEventArgs args)
        {
            prz1Limit = prz2Limit = 0;
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
                invInfo = await Api.GetInvInfo();
                if (invInfo is null || invInfo?.Vno == -1)
                {
                    var cdrel = await Api.GetCdrel();
                    var sch = await Api.GetSch();
                    var qty = await Api.IsQtyUser();
                    var invD = new InvData()
                    { dbf = "FAROOQ", xdemand = false, xmkey = 0, xid = cdrel.UName, xref = $"Online", xsc = 0, xvid = "1SL", xdtype = 'W', db = "", };
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
                    invInfo = await Api.MakeNewInv(invD);
                }

                if (invInfo?.xres == 1)
                {
                    var result = await DialogService.ShowMessageBox("Draw Closed", "Ok");
                    nav.NavigateTo("/");
                }
                else
                {
                    var party = await Api.GetParty();
                    InvNo = invInfo?.Vno.ToString("D4");
                    Ref = invInfo?.Ref;
                    Code = party.Code;
                    PartyName = party.Name;
                    await GetTransList(5);
                }
            }

            loading = false;
            StateHasChanged();
        }

        private async Task GetTransList(int amt = 0)
        {
            if (DigitEnabled)
            {
                var TransactionsInfo = await Api.GetTransactionsListMix(amt, (invInfo?.Vno ?? 0));
                if (TransactionsInfo is not null)
                {
                    Transactions = TransactionsInfo.Transactions;
                    if (amt < TransactionsInfo.TotalRows)
                    {
                        snoCountStart = TransactionsInfo.TotalRows - amt;
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