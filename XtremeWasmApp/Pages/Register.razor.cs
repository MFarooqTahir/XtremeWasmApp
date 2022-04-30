using Microsoft.AspNetCore.Components;

using XtremeWasmApp.Models;

namespace XtremeWasmApp.Pages
{
    public partial class Register
    {
        private readonly RegisterModel RegisterModel = new();
        private bool ShowErrors;
        private IEnumerable<string>? Errors;

        private async Task HandleRegistration()
        {
            ShowErrors = false;
            var result = await AuthService.Register(RegisterModel);
            if (result.Successful)
            {
                NavigationManager.NavigateTo("/Login");
            }
            else
            {
                Errors = result.Errors;
                ShowErrors = true;
                StateHasChanged();
            }
        }
    }
}