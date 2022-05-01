using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Http.Json;

using XtremeModels;

using XtremeWasmApp.Models;

namespace XtremeWasmApp.Services
{
    public class WebApiService : IWebApiService
    {
        private readonly HttpData _httpData;
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _navigationManager;

        public WebApiService(AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage, HttpClient httpClient, NavigationManager navigationManager, HttpData httpData)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
            _httpClient = httpClient;
            _navigationManager = navigationManager;
            _httpData = httpData;
        }

        public async Task<Models.RegisterResult?> Register(Models.RegisterModel registerModel)
        {
            return await SendHttpRequest<Models.RegisterResult?>("api/Login/RegisterWebApp", RequestType.Post, registerModel).ConfigureAwait(false);
        }

        private async Task ChangeToken(string token)
        {
            await _localStorage.SetItemAsync("authToken", token).ConfigureAwait(false);
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", token);
        }

        private void ChangeLink(string Link)
        {
            _httpClient.BaseAddress = new Uri(Link);
        }

        private async Task<string> GetDataLink()
        {
            return await _localStorage.GetItemAsync<string>("DataDbLink").ConfigureAwait(false);
        }

        private async Task<string> GetInvLink()
        {
            return await _localStorage.GetItemAsync<string>("InvDbLink").ConfigureAwait(false);
        }

        private async Task SetDataLink(string link)
        {
            await _localStorage.SetItemAsync("DataDbLink", link).ConfigureAwait(false);
            _httpData.DataLink = new(link);
        }

        private async Task SetInvLink(string link)
        {
            await _localStorage.SetItemAsync("InvDbLink", link).ConfigureAwait(false);
            _httpData.InvoiceLink = new(link);
        }

        public async Task<Models.LoginResult?> Login(Models.LoginModel loginModel)
        {
            var loginResult = await SendHttpRequest<Models.LoginResult>("api/Login/LoginWebApp", RequestType.Post, loginModel).ConfigureAwait(false);

            if (loginResult?.Successful == true)
            {
                await _localStorage.SetItemAsync("UserID", loginResult.ID).ConfigureAwait(false);
                await _localStorage.SetItemAsync("Mbm", loginResult.UnID).ConfigureAwait(false);
                await _localStorage.SetItemAsync("authToken", loginResult.Token).ConfigureAwait(false);
                ((ApiAuthenticationStateProvider)_authenticationStateProvider)
                    .MarkUserAsAuthenticated(loginModel.Email);
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("bearer", loginResult.Token);
                await _localStorage.SetItemAsync("FALoggedIn", data: false).ConfigureAwait(false);
            }
            return loginResult;
        }

        private async Task<T?> SendHttpRequest<T>(string URL, RequestType type, object objPost = null, LinkType linkType = LinkType.Login)
        {
            try
            {
                var baseUri = linkType switch
                {
                    LinkType.Login => _httpData.BaseAddress,
                    LinkType.Data => _httpData.DataLink,
                    LinkType.Invoice => _httpData.InvoiceLink,
                    _ => throw new Exception("Invalid link type")
                };
                if (baseUri is null)
                {
                    var ur = string.Empty;
                    switch (linkType)
                    {
                        case LinkType.Data:
                            ur = await GetDataLink().ConfigureAwait(false);
                            await SetDataLink(ur).ConfigureAwait(false);
                            baseUri = _httpData.DataLink;
                            break;

                        case LinkType.Invoice:
                            ur = await GetInvLink().ConfigureAwait(false);
                            await SetDataLink(ur).ConfigureAwait(false);
                            baseUri = _httpData.InvoiceLink;
                            break;
                    }
                }
                HttpResponseMessage response = type switch
                {
                    RequestType.Get => await _httpClient.GetAsync(baseUri.AbsoluteUri + URL).ConfigureAwait(false),
                    RequestType.Post => await _httpClient.PostAsJsonAsync(baseUri.AbsoluteUri + URL, objPost).ConfigureAwait(false),
                    RequestType.Put => await _httpClient.PutAsJsonAsync(baseUri.AbsoluteUri + URL, objPost).ConfigureAwait(false),
                    RequestType.Delete => await _httpClient.DeleteAsync(baseUri.AbsoluteUri + URL).ConfigureAwait(false),
                    _ => throw new Exception("Invalid Http Request Type")
                };
                if (response is null)
                {
                    return default;
                }
                if (response?.IsSuccessStatusCode == true)
                {
                    return await (response?.Content?.ReadFromJsonAsync<T>()).ConfigureAwait(false);
                }
                else if (response?.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await Logout().ConfigureAwait(false);
                }
                else
                {
                    return default;
                }
                return default;
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public async Task<bool> ChangeCompany(CDRelation cDRelation)
        {
            try
            {
                await SetCompanySelected(value: false).ConfigureAwait(false);
                //var checkCdRel = await SendHttpRequest<bool>($"api/Login/GetCdRel/{cDRelation.DeviceID}/{cDRelation.CompanyID}", "get").ConfigureAwait(false);
                //if (!checkCdRel)
                //{
                //    return false;
                //}
                var res = await SendHttpRequest<ResultSet<Company>>($"api/Company/GetCompanyDetails/{cDRelation.CompanyID}", RequestType.Get).ConfigureAwait(false);
                if (res?.ResultObj is null)
                {
                    return false;
                }
                var Company = res.ResultObj;
                var newToken = await SendHttpRequest<string>($"api/Login/ChangeCompany/0/{cDRelation.CompanyID}", RequestType.Get).ConfigureAwait(false);
                if (newToken is null)
                {
                    return false;
                }
                await ChangeToken(newToken).ConfigureAwait(false);

                await SetCdrel(cDRelation).ConfigureAwait(false);
                await SetCompany(Company).ConfigureAwait(false);

                var DashDataRes = await SendHttpRequest<ResultSet<DashBoardData>>($"api/Data/GetDashData/{cDRelation.rCode}", RequestType.Get, linkType: LinkType.Data).ConfigureAwait(false);
                var DashData = DashDataRes?.ResultObj;
                if (DashData is null)
                {
                    return false;
                }
                if (DashData.party is null || DashData.sch is null)
                {
                    return false;
                }
                await SetpartySchTrans(DashData.partySch).ConfigureAwait(false);
                bool SelShedule = DashData.sch?.Count > 1;
                if (DashData.sch?.Count != 0)
                {
                    var ExtraBalance = 0;
                    if (!SelShedule)
                    {
                        await SetSch(DashData!.sch[0]).ConfigureAwait(false);

                        var newTokenInv = await SendHttpRequest<string>($"api/Login/ChangeDraw/{DashData.sch[0].mkey}", RequestType.Get).ConfigureAwait(false);

                        await ChangeToken(newTokenInv).ConfigureAwait(false);
                        var resl = await SendHttpRequest<ResultSet<bool>>("api/Inv/CheckInvoiceDb", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
                        if (!resl.ResultObj)
                        {
                            return false;
                        }
                        ExtraBalance = (await SendHttpRequest<ResultSet<int>>($"api/Inv/GetOtherBalance/{cDRelation.rCode}", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false)).ResultObj;
                    }
                    else
                    {
                        await SetAllSch(DashData!.sch).ConfigureAwait(false);
                    }
                    DashData.party.Balance += ExtraBalance;
                    DashData.party.Code = cDRelation.rCode;
                    await SetParty(DashData.party).ConfigureAwait(false);
                }
                await SetCompanySelected(value: true).ConfigureAwait(false);
                if (SelShedule)
                {
                    _navigationManager.NavigateTo("/DrawSelection");
                }
                else
                {
                    _navigationManager.NavigateTo("/");
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<TopMarqueData> GetMarqData()
        {
            if (await IsCompanySelected().ConfigureAwait(false) && await IsDrawSelected().ConfigureAwait(false))
            {
                var comp = await GetCompany().ConfigureAwait(false) ?? new();
                var party = await GetParty().ConfigureAwait(false);
                var sch = await GetSch().ConfigureAwait(false) ?? new();
                var cdRel = await GetCdrel().ConfigureAwait(false);
                string ret = string.Empty;
                if (party is not null && cdRel is not null)
                {
                    ret = await UpdateBalance(cdRel, party).ConfigureAwait(false);
                }
                cdRel ??= new();
                return new TopMarqueData
                {
                    Active = cdRel.Active,
                    Balance = ret,
                    BId = sch.BId,
                    DId = sch.DId,
                    Category = sch.Cat,
                    City = comp.City,
                    Date = sch.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PCode = comp.Pcode,
                    PName = cdRel.UName,
                    Uac = sch.Uac,
                };
            }
            return null;
        }

        public async Task<bool> ChangeSchedule(Schedule CurrSelectedSch)
        {
            try
            {
                await SetDrawSelected(value: false).ConfigureAwait(false);
                if (CurrSelectedSch.Period < DateTime.Now)
                {
                    return false;
                }
                var resul = await SendHttpRequest<ResultSet<bool>>($"api/Data/checkUacCompleted/{CurrSelectedSch.mkey}", RequestType.Get, linkType: LinkType.Data).ConfigureAwait(false);
                if (!resul.ResultObj)
                {
                    return false;
                }
                await SetSch(CurrSelectedSch).ConfigureAwait(false);
                var newTokenInv = await SendHttpRequest<string>($"api/Login/ChangeDraw/{CurrSelectedSch.mkey}", RequestType.Get).ConfigureAwait(false);
                await ChangeToken(newTokenInv).ConfigureAwait(false);

                var cDRelation = await GetCdrel().ConfigureAwait(false);
                var res = await SendHttpRequest<ResultSet<bool>>("api/Inv/CheckInvoiceDb", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);

                if (!res.ResultObj)
                {
                    return false;
                }
                var ExtraBalance = await SendHttpRequest<ResultSet<int>>($"api/Inv/GetOtherBalance/{cDRelation.rCode}", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
                var part = await GetParty().ConfigureAwait(false);
                part.Balance += ExtraBalance?.ResultObj ?? 0;
                await SetParty(part).ConfigureAwait(false);
                await SetDrawSelected(value: true).ConfigureAwait(false);
                _navigationManager.NavigateTo("/");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private async Task<string> UpdateBalance(CDRelation cdrel, Party part)
        {
            var amt = (await SendHttpRequest<ResultSet<int>>($"api/DataSet/Login/GetPartyLimit/{cdrel.CompanyID}/{cdrel.rCode}", RequestType.Get, linkType: LinkType.Login).ConfigureAwait(false))?.ResultObj ?? 0;
            var amt2 = (await SendHttpRequest<ResultSet<int>>($"api/Data/GetPartyBalance/{cdrel.rCode}", RequestType.Get, linkType: LinkType.Data).ConfigureAwait(false))?.ResultObj ?? 0;

            part.Balance = double.Parse(amt2.ToString(), CultureInfo.InvariantCulture);
            await SetParty(part).ConfigureAwait(false);
            cdrel.Limit = amt;
            await SetCdrel(cdrel).ConfigureAwait(false);
            if (amt > 0)
            {
                return $"Bal: {amt - amt2}";
            }
            return $"Sale: {amt2}";
        }

        public async Task<(string Name, string city, string Code, string Balance, string CompanyDetails, string pname)> GetDashboardData()
        {
            var party = await GetParty().ConfigureAwait(false) ?? new();
            var comp = await GetCompany().ConfigureAwait(false) ?? new();
            var cdRel = await GetCdrel().ConfigureAwait(false) ?? new();

            return (party.Name, comp.City, party.Code, cdRel.Limit.ToString("F2", CultureInfo.CurrentCulture), comp.Pcode + " - " + comp.PName, cdRel.UName);
        }

        public async Task<IList<Schedule>> GetScheduleList()
        {
            try
            {
                var getting = await SendHttpRequest<ResultSet<List<Schedule>>>("api/Data/GetScheduleList/false", RequestType.Get, linkType: LinkType.Data).ConfigureAwait(false);
                var resObj = getting.ResultObj;
                await SetAllSch(resObj).ConfigureAwait(false);
                return resObj;
            }
            catch (Exception)
            {
                return new List<Schedule>();
            }
        }

        private async Task SetCompany(Company newCom)
        {
            await _localStorage.SetItemAsync("Company", newCom).ConfigureAwait(false);
            await SetDataLink(newCom.WebApiD).ConfigureAwait(false);
        }

        private async Task<Company> GetCompany() => await _localStorage.GetItemAsync<Company>("Company").ConfigureAwait(false);

        private async Task SetCdrel(CDRelation newcd)
        {
            await _localStorage.SetItemAsync("cdRel", newcd).ConfigureAwait(false);
        }

        private async Task<CDRelation> GetCdrel() => await _localStorage.GetItemAsync<CDRelation>("cdRel").ConfigureAwait(false);

        private async Task SetpartySchTrans(PartySch partySch)
        {
            await _localStorage.SetItemAsync("partySchTrans", partySch).ConfigureAwait(false);
        }

        private async Task<PartySch> GetpartySchTrans() => await _localStorage.GetItemAsync<PartySch>("partySchTrans").ConfigureAwait(false);

        private async Task SetSch(Schedule newCom)
        {
            await _localStorage.SetItemAsync("sch", newCom).ConfigureAwait(false);
            await SetInvLink(newCom.WebApiI).ConfigureAwait(false);
        }

        private async Task<Schedule> GetSch() => await _localStorage.GetItemAsync<Schedule>("sch").ConfigureAwait(false);

        private async Task SetParty(Party newParty)
        {
            await _localStorage.SetItemAsync("party", newParty).ConfigureAwait(false);
        }

        private async Task<Party> GetParty() => await _localStorage.GetItemAsync<Party>("party").ConfigureAwait(false);

        private async Task SetAllSch(IList<Schedule> lst)
        {
            await _localStorage.SetItemAsync("allSch", lst).ConfigureAwait(false);
        }

        public async Task UnsetAllSch()
        {
            await _localStorage.RemoveItemAsync("allSch").ConfigureAwait(false);
        }

        public async Task<IList<Schedule>> GetAllSch() => await _localStorage.GetItemAsync<List<Schedule>>("allSch").ConfigureAwait(false);

        private async Task SetCompanySelected(bool value) => await _localStorage.SetItemAsync("IsCompSel", value).ConfigureAwait(false);

        public async Task<bool> IsCompanySelected() => await _localStorage.GetItemAsync<bool>("IsCompSel").ConfigureAwait(false);

        private async Task SetDrawSelected(bool value) => await _localStorage.SetItemAsync("IsDrawSel", value).ConfigureAwait(false);

        public async Task<bool> IsDrawSelected()
        {
            try
            {
                var sel = await _localStorage.GetItemAsync<bool>("IsDrawSel").ConfigureAwait(false);
                if (sel)
                {
                    var sch = await GetSch().ConfigureAwait(false);
                    if (sch.Period < DateTime.Now)
                    {
                        await SetDrawSelected(value: false).ConfigureAwait(false);
                        return false;
                    }
                    var result = await SendHttpRequest<ResultSet<bool>>($"api/Data/checkUacCompleted/{sch.mkey}", RequestType.Get, linkType: LinkType.Data).ConfigureAwait(false);
                    await SetDrawSelected(value: result.ResultObj).ConfigureAwait(false);

                    return result.ResultObj;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<CDRelation>?> GetCdRelations()
        {
            try
            {
                var ID = await GetUserID().ConfigureAwait(false);
                var listret = await SendHttpRequest<ResultSet<IEnumerable<CDRelation>>>($"api/Company/GetCompanyList/{ID}/false", RequestType.Get).ConfigureAwait(false);
                return listret?.ResultObj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task Logout()
        {
            ((ApiAuthenticationStateProvider)_authenticationStateProvider)
                .MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
            await _localStorage.ClearAsync().ConfigureAwait(false);
        }

        public async Task<string?> GetTest()
        {
            return await SendHttpRequest<string>("api/Login/Test", RequestType.Get).ConfigureAwait(false);
        }

        public async Task<int?> GetUserID()
        {
            return await _localStorage.GetItemAsync<int>("UserID").ConfigureAwait(false);
        }

        public async Task<string?> GetMbm()
        {
            var res = await _localStorage.GetItemAsStringAsync("Mbm").ConfigureAwait(false);
            if (string.IsNullOrEmpty(res))
            {
                return string.Empty;
            }
            return res.Replace("\"", "", StringComparison.OrdinalIgnoreCase);
        }

        //public async Task<bool?> TwoFactorLogin(string Code)
        //{
        //    bool res = await SendHttpRequest<bool>($"/api/Login/TFALogin/{Code}", "get").ConfigureAwait(false);
        //    SetTFA(res);
        //    return res;
        //}

        //public async void SetTFA(bool val)
        //{
        //    await _localStorage.SetItemAsync("FALoggedIn", val).ConfigureAwait(false);
        //}

        //public async Task<bool?> GetFALoggedIn()
        //{
        //    return await _localStorage.GetItemAsync<bool>("FALoggedIn").ConfigureAwait(false);
        //}

        //public async Task<int?> SendVerificationEmail(bool retry = false)
        //{
        //    var res = await SendHttpRequest<int>("api/Login/SendEmailCode", "get").ConfigureAwait(false);
        //    return res;
        //}

        //public async void SetGiven2FA(bool val)
        //{
        //    await _localStorage.SetItemAsync("Given2FA", val);
        //}

        //public async Task<bool> GetGiven2FA()
        //{
        //    return await _localStorage.GetItemAsync<bool>("Given2FA");
        //}
    }
}