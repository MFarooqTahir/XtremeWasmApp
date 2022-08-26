using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

using MudBlazor;

using XtremeModels;

using XtremeWasmApp.Services;

namespace XtremeWasmApp.Pages
{
    public partial class CompanySelect
    {
        [Inject]
        private IDialogService DialogService { get; set; }

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

        [Inject]
        public WebApiService ApiService { get; set; }

        [Inject]
        public NavigationManager Nav { get; set; }

        public IList<string> ErrorsList;
        private string acCode;
        private IList<CDRelation> CompanyList;
        public int windowHeight, windowWidth;
        private IJSObjectReference jsModule;

        public class WindowDimensions
        {
            public int Width { get; set; }
            public int Height { get; set; }
        }

        protected override async Task OnInitializedAsync()
        {
            await GetCDRelations();
        }

        private async void OnBlockClicked()
        {
            var result = await DialogService.ShowMessageBox(
                "Error",
                "Account is blocked");
            await InvokeAsync(StateHasChanged);
        }

        private async Task OnNoParties()
        {
            var authState = await AuthenticationStateTask;
            var user = authState.User;
            var authen = user?
                .Identity?
                .IsAuthenticated == true;
            if (authen)
            {
                var result = await DialogService.ShowMessageBox(
                    "REG ID: " + acCode,
                    "You are not registered to any party", "Log Out");
            }
            StateHasChanged();
            await ApiService.Logout();
        }

        private async Task GetCDRelations()
        {
            acCode = await ApiService.GetMbm().ConfigureAwait(false);
            var comp = await ApiService.GetCdRelations().ConfigureAwait(false);

            if (comp is not null && comp.Any())
            {
                CompanyList = comp.ToList();
                if (CompanyList.Count == 1)
                {
                    await onRowSelection(0);
                }
                else
                {
                    await InvokeAsync(StateHasChanged).ConfigureAwait(false);
                }
            }
            else
            {
                await OnNoParties().ConfigureAwait(false);
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                jsModule = await JsRuntime.InvokeAsync<IJSObjectReference>("import", "./js/Dimentions.js");
            }
            if (jsModule is not null)
            {
                var (prevHeight, prevWidth) = (windowHeight, windowWidth);
                var dimension = await jsModule.InvokeAsync<WindowDimensions>("getWindowSize");
                windowHeight = dimension.Height;
                windowWidth = dimension.Width;
                if ((prevHeight, prevWidth) != (windowHeight, windowWidth))
                {
                    StateHasChanged();
                }
            }
        }

        private async Task onRowSelection(int rowIndex)
        {
            await ApiService.SetDrawSelected(value: false);
            if (CompanyList?.Any() == true)
            {
                var currSel = CompanyList[rowIndex];
                if (currSel.Block || currSel.rBlocked)
                {
                    OnBlockClicked();
                }
                else
                {
                    var res = await ApiService.ChangeCompany(currSel);
                    if (!res.Item1)
                    {
                        ErrorsList = new List<string>() { res.Item2 };
                        StateHasChanged();
                    }
                }
            }
        }
    }
}