using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

using MudBlazor;

using XtremeWasmApp.Models;
using XtremeWasmApp.Services;

namespace XtremeWasmApp.Shared
{
    public partial class MainLayout
    {
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

        [Inject]
        private IWebApiService Auth { get; set; } = null!;

        private bool _isDarkMode;
        private MudThemeProvider _mudThemeProvider = null!;
        private string Currpage { get; set; } = null!;
        private bool _selectedCompDraw;

        public bool selectedCompDraw {
            get { return _selectedCompDraw; }
            set { var old = selectedCompDraw; _selectedCompDraw = value; if (old != value) { StateHasChanged(); } }
        }

        private bool compSel;
        private bool drawSel;
        private bool MarqSet;
        private TopMarqueData MarqData;

        private async Task<bool> Check(bool authen)
        {
            bool page = string.Equals(Currpage, "Login", StringComparison.OrdinalIgnoreCase) || string.Equals(Currpage, "Register", StringComparison.OrdinalIgnoreCase);
            if (!authen && !page)
            {
                nav.NavigateTo("/Login");
                return false;
            }
            return true;
        }

        private void ontopclick()
        {
            nav.NavigateTo("/DrawSelection?onlyactive=true");
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            var currMarq = MarqSet;
            MarqSet = false;
            if (firstRender)
            {
                //await Auth.Logout();
                var pal = _mudThemeProvider.Theme.Palette;
                var palD = _mudThemeProvider.Theme.PaletteDark;
                palD.Primary = pal.Primary = "#D2B48C";
                _mudThemeProvider.Theme.Palette = pal;
                _mudThemeProvider.Theme.PaletteDark = palD;
                _isDarkMode = await _mudThemeProvider.GetSystemPreference();
                StateHasChanged();
            }
            else
            {
                Currpage = nav.Uri.Replace(nav.BaseUri, "", StringComparison.OrdinalIgnoreCase);
                var ind = Currpage.IndexOf('/', StringComparison.OrdinalIgnoreCase);
                if (!string.IsNullOrWhiteSpace(Currpage) && ind > 0)
                {
                    Currpage = Currpage.Remove(ind);
                }
            }
            var authState = await AuthenticationStateTask;
            var user = authState.User;
            var authen = user?
                .Identity?
                .IsAuthenticated == true;
            var res = await Check(authen);
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
                var currMarqData = MarqData;
                MarqData = await Auth.GetMarqData();
                MarqSet = MarqData is not null;
                rerender = rerender || MarqSet != currMarq || currMarqData != MarqData;
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
    }
}