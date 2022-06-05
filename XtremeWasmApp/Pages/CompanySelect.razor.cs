using Microsoft.AspNetCore.Components;
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
            bool? result = await DialogService.ShowMessageBox(
                "Error",
                "Account is blocked");
            StateHasChanged();
        }

        private async Task OnNoParties()
        {
            var result = await DialogService.ShowMessageBox(
                "REG ID: " + acCode,
                "You are not registered to any party", "Log Out");
            StateHasChanged();
            await ApiService.Logout();
        }

        private async Task GetCDRelations()
        {
            var comp = (await ApiService.GetCdRelations().ConfigureAwait(false));
            if (comp?.Any() == true)
            {
                acCode = await ApiService.GetMbm().ConfigureAwait(false);
                if (comp?.Any() == false)
                {
                    await OnNoParties();
                }
                else
                {
                    CompanyList = comp.ToList();
                    StateHasChanged();
                }
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
            //if (currSel.Block || currSel.rBlocked)
            //{
            //    OnBlockClicked();
            //}
            //else
            //{
            //    var res = await ApiService.ChangeCompany(currSel);
            //    if (!res)
            //    {
            //        ErrorsList = new List<string>() { "Error changing company" };
            //        StateHasChanged();
            //    }
            //}
        }
    }
}