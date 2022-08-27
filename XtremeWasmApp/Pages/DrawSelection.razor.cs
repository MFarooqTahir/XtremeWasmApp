using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using XtremeModels;

namespace XtremeWasmApp.Pages
{
    public partial class DrawSelection
    {
        [Parameter]
        [SupplyParameterFromQuery(Name = "onlyactive")]
        public bool onlyactive { get; set; }

        [CascadingParameter]
        public Timer _timer { get; set; }

        public IList<string> ErrorsList;
        private IList<Schedule> schedules;
        private IJSObjectReference jsModule;
        public int windowHeight, windowWidth;

        public class WindowDimensions
        {
            public int Width { get; set; }

            public int Height { get; set; }
        }

        protected override async Task OnInitializedAsync()
        {
            IList<Schedule>? schT = null;
            if (onlyactive)
            {
                schT = await ApiService.GetScheduleList(onlyactive, false);
            }
            else
            {
                var drawSel = await ApiService.IsDrawSelected();
                schT = await ApiService.GetAllSch();
                if (schT is null)
                {
                    bool GetAll = !drawSel;
                    schT = await ApiService.GetScheduleList(GetAll, drawSel);
                }
            }

            if (schT?.Count == 1)
            {
                var res = await ApiService.ChangeSchedule(schT[0], _timer);
                if (!res.Item1)
                {
                    ErrorsList = new List<string>()
                    {res.Item2, "Either the draw is closed, or there was an error"};
                    schedules = schT;
                    await InvokeAsync(StateHasChanged).ConfigureAwait(false);
                }
            }
            else
            {
                schedules = schT;
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
                    await InvokeAsync(StateHasChanged).ConfigureAwait(false);
                }
            }
        }

        private async Task onRowSelection(int rowIndex)
        {
            var currSel = schedules[rowIndex];
            if (currSel.blocked)
            {
                ErrorsList = new List<string>()
                {"This draw is blocked"};
                await InvokeAsync(StateHasChanged).ConfigureAwait(false);
                return;
            }

            var res = await ApiService.ChangeSchedule(currSel, _timer);
            if (!res.Item1)
            {
                ErrorsList = new List<string>()
                {res.Item2, "Either the draw is closed, or there was an error"};
                await InvokeAsync(StateHasChanged).ConfigureAwait(false);
            }
        }
    }
}