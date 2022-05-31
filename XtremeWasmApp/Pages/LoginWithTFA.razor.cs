using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

using XtremeWasmApp.Models;
using XtremeWasmApp.Services;

namespace XtremeWasmApp.Pages
{
    public partial class LoginWithTFA
    {
        public FALoginModel Model { get; set; } = new();

        [CascadingParameter]
        private Task<AuthenticationState>? AuthenticationStateTask { get; set; }

        [Inject]
        private WebApiService? Auth { get; set; }

        private List<string> errors = new();
        private string EmailVerificationStatus = "Verification code has been sent to your email address";

        public async Task SendVerification()
        {
            //var state = await AuthenticationStateTask;
            //bool authenticated = state?.User?.Identity?.IsAuthenticated ?? false;
            //if (!authenticated)
            //    NavigationManager.NavigateTo("/Login");
            //var TFA = (await Auth?.GetFALoggedIn()) ?? false;
            //if (TFA)
            //{
            //    NavigationManager.NavigateTo("/");
            //}
            //var email = await Auth.SendVerificationEmail();
            //if (email == 2)
            //{
            //    EmailVerificationStatus = "Verification code was recently sent to your email, please wait for before trying again";
            //    StateHasChanged();
            //}
        }

        protected override Task OnInitializedAsync()
        {
            _ = SendVerification();
            return base.OnInitializedAsync();
        }

        private async Task HandleLogin()
        {
            //var enabled = await Auth?.TwoFactorLogin(Model.Code);
            //if (enabled == true)
            //{
            //    NavigationManager.NavigateTo("/");
            //}
            //else
            //{
            //    errors = new()
            //    { "Try again" };
            //    StateHasChanged();
            //}
        }
    }
}