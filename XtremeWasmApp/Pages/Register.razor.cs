using Microsoft.AspNetCore.Components;

using XtremeWasmApp.Components;
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
            if (!string.IsNullOrWhiteSpace(RegisterModel.Email))
            {
                var Code = await AuthService.GetCode(RegisterModel.Email);
                if (Code)
                {
                    var dialog = DialogService.Show<CodeDialog>("Enter Code");
                    var result2 = await dialog.Result;
                    if (!result2.Cancelled)
                    {
                        RegisterModel.Code = result2.Data.ToString();
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
                    else
                    {
                        Errors = new[] { "Cancelled" };
                        ShowErrors = true;
                        StateHasChanged();
                    }
                }
            }
            else
            {
                Errors = new[] { "No Email Entered" };
                ShowErrors = true;
                StateHasChanged();
            }
        }
    }
}