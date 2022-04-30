using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

using System.Net.Http.Json;
using System.Security.Claims;

using XtremeWasmApp.Models;
using XtremeWasmApp.Services;

namespace XtremeWasmApp.Pages
{
    public partial class EnableTwoFactor
    {
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        private QRModel qr { get; set; } = new();
        private string Email { get; set; }

        [Inject]
        private IAuthService Auth { get; set; }

        public async void GetQr()
        {
            var state = await authenticationStateTask;
            bool authenticated = state?.User?.Identity?.IsAuthenticated ?? false;
            bool given = await Auth.GetGiven2FA();
            if (authenticated && given)
            {
                NavigationManager.NavigateTo("/FALogin");
            }

            Email = state.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            if (!string.IsNullOrWhiteSpace(Email))
            {
                qr = await client.GetFromJsonAsync<QRModel>($"/api/Login/GetQRDetails");
                StateHasChanged();
            }
        }

        protected override Task OnInitializedAsync()
        {
            GetQr();
            return base.OnInitializedAsync();
        }

        private async Task HandleLogin()
        {
            var enabled = await client.GetFromJsonAsync<bool>($"/api/Login/EnableTFA/{qr.Code}");
            Auth.SetGiven2FA(enabled);
            if (enabled)
            {
                NavigationManager.NavigateTo("/");
            }
            else
            {
                qr = await client.GetFromJsonAsync<QRModel>($"/api/Login/GetQRDetails");
                StateHasChanged();
            }
        }
    }
}