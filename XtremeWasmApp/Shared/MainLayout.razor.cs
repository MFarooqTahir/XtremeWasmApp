using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;

using MudBlazor;

using XtremeModels;

using XtremeWasmApp.Models;
using XtremeWasmApp.Services;

namespace XtremeWasmApp.Shared
{
    public partial class MainLayout
    {
        [Inject]
        private HubConnection _hub { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

        [Inject]
        private HttpData linksData { get; set; }

        [Inject]
        private IJSRuntime Js { get; set; }

        [Inject]
        private WebApiService Auth { get; set; } = null!;

        [Inject]
        private IRefreshService service { get; set; }

        private Company? Company { get; set; }
        public Timer _timer;

        private RepeatDataReturnWA _repeatData;

        public RepeatDataReturnWA repeatData {
            get { return _repeatData; }
            set {
                if (value != _repeatData)
                {
                    _repeatData = value;
                    StateHasChanged();
                }
                else
                {
                    _repeatData = value;
                }
            }
        }

        private bool RunTimer, ac;

        private bool _isDarkMode;
        private MudThemeProvider _mudThemeProvider = null!;
        private string Currpage { get; set; } = null!;
        private bool _selectedCompDraw;

        public bool selectedCompDraw {
            get { return _selectedCompDraw; }
            set { var old = selectedCompDraw; _selectedCompDraw = value; if (old != value) { StateHasChanged(); } }
        }

        private string MBM = "Loading...";
        private bool compSel;
        private bool drawSel;
        private bool MarqSet => MarqData is not null;
        private TopMarqueData? MarqData;

        private bool Check(bool authen)
        {
            var page = string.Equals(Currpage, "Login", StringComparison.OrdinalIgnoreCase) || string.Equals(Currpage, "Register", StringComparison.OrdinalIgnoreCase);
            if (!authen && !page)
            {
                nav.NavigateTo("/Login");
                return false;
            }
            return true;
        }

        public string? Balance { get; set; }

        private async void RefreshMe()
        {
            _timer.Change(0, 12000);
            await InvokeAsync(StateHasChanged);
        }

        private void ontopclick()
        {
            nav.NavigateTo("/DrawSelection?onlyactive=true");
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            Company = await Auth.GetCompany();
            if (firstRender)
            {
                var dtype = await Js.InvokeAsync<string>("getOS") ?? "A";
                await Auth.SetDtype(dtype);
                _timer = new(async _ => {
                    //if (await Auth.IsCompanySelected() && await Auth.GetIsCompanyBlocked())
                    //{
                    //    await Auth.Logout();
                    //}
                    //else if (RunTimer)
                    //{
                    //    RunTimer = false;
                    //    if (await Auth.GetRepeatDataWeb())
                    //    {
                    //        var newRepeat = await Auth.GetRepeatData();
                    //        if (newRepeat is not null && newRepeat != repeatData)
                    //        {
                    //            repeatData = newRepeat;
                    //            if (newRepeat.RelationBlocked)
                    //            {
                    //                await Auth.SetCompanySelected(value: false);
                    //                nav.NavigateTo("/CompanySelection");
                    //            }
                    //            else if (newRepeat.DrawBlocked)
                    //            {
                    //                await Auth.SetDrawSelected(value: false);
                    //                nav.NavigateTo("/DrawSelection");
                    //            }
                    //        }
                    //    }
                    //    RunTimer = true;
                    //    StateHasChanged();
                    //}
                }, state: null, 0, 12000);
                service.RefreshRequested += RefreshMe;
                await Auth.Logout();
                var pal = _mudThemeProvider.Theme.Palette;
                var palD = _mudThemeProvider.Theme.PaletteDark;
                palD.Primary = pal.Primary = "#D2B48C";
                _mudThemeProvider.Theme.Palette = pal;
                _mudThemeProvider.Theme.PaletteDark = palD;
                _isDarkMode = true;// await _mudThemeProvider.GetSystemPreference();
                await InvokeAsync(StateHasChanged);
                nav.LocationChanged += OnLocationChanged;

                _hub.On<BalanceUpdateDto>(
                   "BalanceUpdate",
                   async x => {
                       var part = await Auth.GetParty();
                       var cdrel = await Auth.GetCdrel();
                       part.Balance = x.Balance;
                       await Auth.SetParty(part).ConfigureAwait(false);
                       cdrel.Limit = x.Limit;
                       await Auth.SetCdrel(cdrel).ConfigureAwait(false);
                       var bal = x.Limit + x.Balance;

                       await Auth.SetCurrentBalance(x.Limit <= 0 ? int.MaxValue : bal).ConfigureAwait(false);
                       if (x.Limit > 0)
                       {
                           await Auth.SetCurrentDisplayBalance($"Bal: {bal}").ConfigureAwait(false);
                       }
                       else
                       {
                           await Auth.SetCurrentDisplayBalance($"Sale: {(x.Balance != 0 ? x.Balance * -1 : 0)}").ConfigureAwait(false);
                       }
                       await InvokeAsync(StateHasChanged);
                   });

                _hub.On<bool>(
                    "FranBlock",
                    async x => {
                        if (x)
                        {
                            MarqData = null;
                            await Auth.Logout().ConfigureAwait(false);
                            await InvokeAsync(StateHasChanged);
                        }
                    });
                _ = _hub.On("LogOut",
                    async () =>
                    await Auth.Logout());
                _hub.On<RepeatDataReturnWA>(
                    "UpdateRepeat",
                    async x => {
                        var oldRepeat = await Auth.GetRepeatData().ConfigureAwait(false);
                        x.DrawBlocked = oldRepeat.DrawBlocked;
                        x.DrawCompleted = oldRepeat.DrawCompleted;
                        x.Uac = oldRepeat.Uac;
                        await Auth.SetRepeatData(repeatData).ConfigureAwait(false);
                        repeatData = x;
                    });
                _hub.On<bool>(
                    "UpdateIPrint",
                    async x => {
                        var oldRepeat = await Auth.GetRepeatData().ConfigureAwait(false);
                        var newRepeat = oldRepeat.ShallowCopy();
                        newRepeat.RelationPrint = x;
                        await Auth.SetRepeatData(repeatData).ConfigureAwait(false);
                        repeatData = newRepeat;
                    });
                _hub.On<bool>(
                   "UpdateWPrize",
                   async x => {
                       var oldRepeat = await Auth.GetRepeatData().ConfigureAwait(false);
                       var newRepeat = oldRepeat.ShallowCopy();
                       newRepeat.RelationPrize = x;
                       await Auth.SetRepeatData(repeatData).ConfigureAwait(false);
                       repeatData = newRepeat;
                   });
                _hub.On<bool>(
                   "UpdateActive",
                   async x => {
                       var oldRepeat = await Auth.GetRepeatData().ConfigureAwait(false);
                       var newRepeat = oldRepeat.ShallowCopy();
                       newRepeat.RelationActive = x;
                       var r = newRepeat != oldRepeat;
                       repeatData = newRepeat;
                       await Auth.SetRepeatData(repeatData).ConfigureAwait(false);
                       if (r)
                       {
                           await InvokeAsync(StateHasChanged);
                       }
                   });
                _hub.On<bool>(
                   "UpdateBill",
                   async x => {
                       var oldRepeat = await Auth.GetRepeatData().ConfigureAwait(false);
                       var newRepeat = oldRepeat.ShallowCopy();
                       newRepeat.RelationBill = x;
                       await Auth.SetRepeatData(repeatData).ConfigureAwait(false);
                       repeatData = newRepeat;
                   });
                _hub.On<bool>(
                   "UpdateLedger",
                   async x => {
                       var oldRepeat = await Auth.GetRepeatData().ConfigureAwait(false);
                       var newRepeat = oldRepeat.ShallowCopy();
                       newRepeat.RelationLedger = x;
                       await Auth.SetRepeatData(repeatData).ConfigureAwait(false);
                       repeatData = newRepeat;
                   });
                _hub.On(
                   "RelUnblock",
                   async () => {
                       var oldRepeat = await Auth.GetRepeatData().ConfigureAwait(false);
                       var newRepeat = oldRepeat.ShallowCopy();
                       newRepeat.RelationBlocked = false;
                       var r = newRepeat != oldRepeat;
                       await Auth.SetRepeatData(repeatData).ConfigureAwait(false);
                       repeatData = newRepeat;
                   });
                _hub.On(
                   "RelBlock",
                   async () => {
                       var oldRepeat = await Auth.GetRepeatData().ConfigureAwait(false);
                       var newRepeat = oldRepeat.ShallowCopy();
                       newRepeat.RelationBlocked = true;
                       newRepeat.RelationLedger = false;
                       newRepeat.RelationPrize = false;
                       newRepeat.RelationPrint = false;
                       newRepeat.RelationBill = false;
                       newRepeat.RelationActive = false;
                       await Auth.SetRepeatData(repeatData).ConfigureAwait(false);
                       repeatData = newRepeat;
                   });
                //_hub.Closed += async (ex) => {
                //    await Task.Delay(TimeSpan.FromSeconds(5));
                //    await _hub.StartAsync();
                //};
                try
                {
                    await _hub.StartAsync().ConfigureAwait(false);
                }
                catch
                {
                    nav.NavigateTo("/", true);
                }
            }
            ac = repeatData?.RelationActive == false || repeatData?.Uac == false || repeatData?.DrawCompleted == true;
            MBM = await AuthService.GetMbm().ConfigureAwait(false) ?? "";

            Currpage = nav.Uri.Replace(nav.BaseUri, "", StringComparison.OrdinalIgnoreCase);
            var ind = Currpage.IndexOf('/', StringComparison.OrdinalIgnoreCase);
            if (!string.IsNullOrWhiteSpace(Currpage) && ind > 0)
            {
                Currpage = Currpage.Remove(ind);
            }

            var authState = await AuthenticationStateTask.ConfigureAwait(false);
            var user = authState.User;
            var authen = user?
                .Identity?
                .IsAuthenticated == true;
            RunTimer = authen;
            var res = Check(authen);
            if (res && authen)
            {
                var oldBal = Balance;
                Balance = await Auth.GetCurrentDisplayBalance().ConfigureAwait(false);
                compSel = await Auth.IsCompanySelected().ConfigureAwait(false);
                drawSel = await Auth.IsDrawSelected().ConfigureAwait(false);
                var rerender = selectedCompDraw;
                selectedCompDraw = compSel && drawSel;
                rerender = (rerender != selectedCompDraw) || !string.Equals(oldBal, Balance, StringComparison.InvariantCultureIgnoreCase);
                if (!selectedCompDraw)
                {
                    if (!compSel && Currpage is not "CompanySelection")
                    {
                        nav.NavigateTo("/CompanySelection");
                    }
                    else if (compSel && !drawSel && Currpage is not "DrawSelection")
                    {
                        nav.NavigateTo("/DrawSelection");
                    }
                }

                if (rerender)
                {
                    StateHasChanged();
                }
            }
        }

        private void ThemeCh()
        {
            _isDarkMode = !_isDarkMode;
        }

        private bool _drawerOpen = true;

        private void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }

        public async ValueTask DisposeAsync()
        {
            GC.SuppressFinalize(this);
            nav.LocationChanged -= OnLocationChanged;
            await _timer.DisposeAsync();
            await Auth.Logout();
        }

        private async void OnLocationChanged(object sender, LocationChangedEventArgs args)
        {
            var authState = await AuthenticationStateTask.ConfigureAwait(false);
            var user = authState.User;
            var authen = user?
                .Identity?
                .IsAuthenticated == true;
            if (authen && await Auth.GetRepeatDataWeb().ConfigureAwait(false))
            {
                var newRepeat = await Auth.GetRepeatData().ConfigureAwait(false);

                //var newMarq = (await Auth.GetTopMarqData().ConfigureAwait(false));
                var newMarq = await Auth.GetMarqData().ConfigureAwait(false);// (await Auth.GetTopMarqData().ConfigureAwait(false)) ??

                var r = newMarq != MarqData;
                MarqData = newMarq;

                var rerender = r;
                repeatData = newRepeat;
                if (rerender)
                {
                    await InvokeAsync(StateHasChanged).ConfigureAwait(false);
                }
            }
        }
    }
}