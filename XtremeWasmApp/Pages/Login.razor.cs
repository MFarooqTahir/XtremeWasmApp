using Microsoft.AspNetCore.Components;

using XtremeWasmApp.Models;

namespace XtremeWasmApp.Pages
{
    public partial class Login
    {
        private readonly LoginModel loginModel = new();
        private bool ShowErrors;
        private string Error = "";

        private async Task HandleLogin()
        {
            ShowErrors = false;
            var result = await AuthService.Login(loginModel);
            if (result?.Successful == true)
            {
                NavigationManager.NavigateTo("/CompanySelection");
            }
            else
            {
                Error = result?.Error ?? "";
                ShowErrors = true;
            }
        }
    }
}