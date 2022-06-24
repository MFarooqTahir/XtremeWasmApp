using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

using MudBlazor;

using XtremeModels;

using XtremeWasmApp.Models;
using XtremeWasmApp.Services;

namespace XtremeWasmApp.Shared
{
    public partial class MainLayout
    {
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

        [Inject]
        private IJSRuntime Js { get; set; }

        [Inject]
        private WebApiService Auth { get; set; } = null!;

        [Inject]
        private IRefreshService service { get; set; }

        private Company? Company { get; set; }
        public Timer _timer;

        private RepeatDataReturnWA repeatData;

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
        private TopMarqueData MarqData;

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

        private void RefreshMe()
        {
            _timer.Change(0, 12000);
            StateHasChanged();
        }

        private void ontopclick()
        {
            nav.NavigateTo("/DrawSelection?onlyactive=true");
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            Company = await Auth.GetCompany();
            var currMarq = MarqSet;
            if (firstRender)
            {
                var dtype = await Js.InvokeAsync<string>("getOS") ?? "A";
                await Auth.SetDtype(dtype);
                _timer = new(async _ => {
                    if (RunTimer)
                    {
                        RunTimer = false;
                        if (await Auth.GetRepeatDataWeb())
                        {
                            var newRepeat = await Auth.GetRepeatData();
                            if (newRepeat is not null && newRepeat != repeatData)
                            {
                                repeatData = newRepeat;
                                if (newRepeat.RelationBlocked)
                                {
                                    await Auth.SetCompanySelected(value: false);
                                    nav.NavigateTo("/CompanySelection");
                                }
                                else if (newRepeat.DrawBlocked)
                                {
                                    await Auth.SetDrawSelected(value: false);
                                    nav.NavigateTo("/DrawSelection");
                                }
                            }
                        }
                        MarqData = await Auth.GetMarqData();
                        RunTimer = true;
                        StateHasChanged();
                    }
                }, state: null, 0, 12000);
                service.RefreshRequested += RefreshMe;
                await Auth.Logout();
                var pal = _mudThemeProvider.Theme.Palette;
                var palD = _mudThemeProvider.Theme.PaletteDark;
                palD.Primary = pal.Primary = "#D2B48C";
                _mudThemeProvider.Theme.Palette = pal;
                _mudThemeProvider.Theme.PaletteDark = palD;
                _isDarkMode = await _mudThemeProvider.GetSystemPreference();
                StateHasChanged();
            }
            ac = repeatData?.RelationActive == false || repeatData?.Uac == false || repeatData?.DrawCompleted == true;
            MBM = await AuthService.GetMbm();

            Currpage = nav.Uri.Replace(nav.BaseUri, "", StringComparison.OrdinalIgnoreCase);
            var ind = Currpage.IndexOf('/', StringComparison.OrdinalIgnoreCase);
            if (!string.IsNullOrWhiteSpace(Currpage) && ind > 0)
            {
                Currpage = Currpage.Remove(ind);
            }

            var authState = await AuthenticationStateTask;
            var user = authState.User;
            var authen = user?
                .Identity?
                .IsAuthenticated == true;
            RunTimer = authen;
            var res = Check(authen);
            if (res && authen)
            {
                compSel = await Auth.IsCompanySelected();
                drawSel = await Auth.IsDrawSelected();
                var rerender = selectedCompDraw;
                selectedCompDraw = compSel && drawSel;
                rerender = rerender != selectedCompDraw;
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
            await _timer.DisposeAsync();
            await Auth.Logout();
        }
    }
}