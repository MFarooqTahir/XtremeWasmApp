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
    public class WebApiService
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

        public async Task SetDtype(string dtype) => await _localStorage.SetItemAsync("dtype", dtype);

        public async Task<string> GetDtype() => await _localStorage.GetItemAsync<string>("dtype").ConfigureAwait(false);

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
                            await SetInvLink(ur).ConfigureAwait(false);
                            baseUri = _httpData.InvoiceLink;
                            break;
                    }
                }
                var response = type switch
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

        public async Task<mixpktchkModel?> PktCheck(string? digits)
        {
            var res = await SendHttpRequest<ResultSet<mixpktchkModel?>>($"api/Transactions/MixPktChkWebApp/{digits}", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
            return res.ResultObj;
        }

        public async Task<Transaction?> MakeNewEntry(EntryData invD)
        {
            var isFranchise = await GetIsFranchise().ConfigureAwait(false);
            var mkey = 0;
            if (isFranchise)
            {
                mkey = (await GetFranMkeys().ConfigureAwait(false))[0];
            }
            var res = await SendHttpRequest<ResultSet<Transaction?>>($"api/Transactions/InsertEntry/{isFranchise}/{mkey}", RequestType.Post, invD, LinkType.Invoice).ConfigureAwait(false);
            return res?.ResultObj;
        }

        public async Task<Transaction?> MakeNewEntrySch(EntryDataSch invD)
        {
            var isFranchise = await GetIsFranchise().ConfigureAwait(false);
            var mkey = 0;
            if (isFranchise)
            {
                mkey = (await GetFranMkeys().ConfigureAwait(false))[1];
            }
            var res = await SendHttpRequest<ResultSet<Transaction?>>($"api/Transactions/InsertEntrySch/{isFranchise}/{mkey}", RequestType.Post, invD, LinkType.Invoice).ConfigureAwait(false);
            return res?.ResultObj;
        }

        public async Task<bool> GetDigitEnabled()
        {
            var cdrel = await GetCdrel().ConfigureAwait(false);
            return (cdrel?.Active ?? false) && (cdrel?.Enabled ?? false);
        }

        public async Task<Inventory?> GetInvInfo(string type = "1SL")
        {
            var cdrel = await GetCdrel().ConfigureAwait(false);
            var res = await SendHttpRequest<ResultSet<Inventory>>($"api/Transactions/GetInv/{cdrel.rCode}/{type}", type: RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
            return res?.ResultObj;
        }

        public async Task<(bool, string)> ChangeCompany(CDRelation cDRelation)
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
                    return (false, "Error in changing company");
                }
                var Company = res.ResultObj;
                var newToken = await SendHttpRequest<string>($"api/Login/ChangeCompany/0/{cDRelation.CompanyID}", RequestType.Get).ConfigureAwait(false);
                if (newToken is null)
                {
                    return (false, "Error in changing company");
                }
                await ChangeToken(newToken).ConfigureAwait(false);

                await SetCdrel(cDRelation).ConfigureAwait(false);
                await SetCompany(Company).ConfigureAwait(false);
                var isFranchise = Company.Stype == 'F';
                await setIsFranchise(isFranchise).ConfigureAwait(false);
                await setFcode(Company.FCode).ConfigureAwait(false);
                //List<int> mke = new() { 0, 0, 0 };
                //if (isFranchise)
                //{
                //    var mkeys = await SendHttpRequest<ResultSet<List<int>>>($"api/Transactions/CheckInvExist/{Company.FCode}", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
                //    if (mkeys is null || mkeys.ResultObj is null)
                //    {
                //        return (false, "Error in franchise Invoice");
                //    }
                //    mke = mkeys.ResultObj;
                //    await SetFranMkeys(mkeys.ResultObj).ConfigureAwait(false);
                //}
                var DashDataRes = await SendHttpRequest<ResultSet<DashBoardData>>($"api/Data/GetDashData/{cDRelation.rCode}/0", RequestType.Get, linkType: LinkType.Data).ConfigureAwait(false);
                var DashData = DashDataRes?.ResultObj;
                if (DashData is null)
                {
                    return (false, "Error. There might be no active draws for this company");
                }
                if (DashData.party is null || DashData.sch is null)
                {
                    return (false, "There was an error in getting the data. Please try again later");
                }
                //await SetpartySchTrans(DashData.partySch).ConfigureAwait(false);
                var SelShedule = DashData.sch?.Count > 1;
                if (DashData.sch?.Count != 0)
                {
                    var ExtraBalance = 0;
                    if (!SelShedule)
                    {
                        await SetSch(DashData?.sch?[0]).ConfigureAwait(false);
                        var newTokenInv = await SendHttpRequest<string>($"api/Login/ChangeDraw/{DashData.sch[0].mkey}", RequestType.Get).ConfigureAwait(false);

                        await ChangeToken(newTokenInv).ConfigureAwait(false);
                        List<int> mke = new() { 0, 0, 0 };
                        if (isFranchise)
                        {
                            var mkeys = await SendHttpRequest<ResultSet<List<int>>>($"api/Transactions/CheckInvExist/{Company.FCode}", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
                            if (mkeys is null || mkeys.ResultObj is null)
                            {
                                return (false, "Error in franchise Invoice");
                            }
                            mke = mkeys.ResultObj;
                            await SetFranMkeys(mkeys.ResultObj).ConfigureAwait(false);
                        }
                        var partySchCurr = await GetpartySchTrans().ConfigureAwait(false);
                        if (partySchCurr is not null)
                        {
                            var resx = await SendHttpRequest<ResultSet<List<double>>>($"api/Data/GetInvValues/{mke[1]}", RequestType.Get, linkType: LinkType.Data).ConfigureAwait(false);
                            var values = resx.ResultObj;
                            if (values is null)
                            {
                                return (false, "Error. There might be no active draws for this company");
                            }
                            partySchCurr.Win_Rate1 = values[0];
                            partySchCurr.Win_Rate2 = values[1];
                            partySchCurr.Win_Rate3 = values[2];
                            partySchCurr.Win_Rate4 = values[3];
                            await SetpartySchTrans(partySchCurr).ConfigureAwait(false);
                        }
                        var resl = await SendHttpRequest<ResultSet<bool>>("api/Inv/CheckInvoiceDb", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
                        if (!resl.ResultObj)
                        {
                            return (false, "Error occured, the draw is not available");
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
                return (true, "");
            }
            catch (Exception ex)
            {
                return (false, "Critical error occured");
            }
        }

        public async Task SetFranMkeys(IList<int>? mkeys) => await _localStorage.SetItemAsync("FranMkeys", mkeys).ConfigureAwait(false);

        public async Task<IList<int>?> GetFranMkeys() => await _localStorage.GetItemAsync<List<int>>("FranMkeys").ConfigureAwait(false);

        public async Task setFcode(int fCode) => await _localStorage.SetItemAsync("FCode", fCode).ConfigureAwait(false);

        public async Task setIsFranchise(bool v) => await _localStorage.SetItemAsync("Franchise", v).ConfigureAwait(false);

        public async Task<int> GetFcode() => await _localStorage.GetItemAsync<int>("FCode").ConfigureAwait(false);

        public async Task<bool> GetIsFranchise() => await _localStorage.GetItemAsync<bool>("Franchise").ConfigureAwait(false);

        public async Task<TopMarqueData> GetMarqData()
        {
            if (await IsCompanySelected().ConfigureAwait(false) && await IsDrawSelected().ConfigureAwait(false))
            {
                var comp = await GetCompany().ConfigureAwait(false) ?? new();
                var party = await GetParty().ConfigureAwait(false);
                var sch = await GetSch().ConfigureAwait(false) ?? new();
                var cdRel = await GetCdrel().ConfigureAwait(false);
                var ret = string.Empty;
                if (party is not null && cdRel is not null)
                {
                    ret = await UpdateBalance(cdRel, party).ConfigureAwait(false);
                }
                cdRel ??= new();
                return new TopMarqueData
                {
                    Balance = ret,
                    BId = sch.BId,
                    DId = sch.DId,
                    Category = sch.Cat,
                    City = sch.City,
                    Date = sch.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PCode = comp.Pcode,
                    PName = cdRel.UName,
                };
            }
            return null;
        }

        public async Task<bool> GetRepeatDataWeb()
        {
            try
            {
                var sel = await _localStorage.GetItemAsync<bool>("IsDrawSel").ConfigureAwait(false);
                if (sel)
                {
                    var sch = await GetSch().ConfigureAwait(false);
                    var result = await SendHttpRequest<ResultSet<RepeatDataReturnWA>>($"api/Data/CheckMixWebApp/{sch.mkey}", RequestType.Get, linkType: LinkType.Data).ConfigureAwait(false);
                    if (result?.ResultObj is null)
                    {
                        return false;
                    }
                    await SetRepeatData(result.ResultObj).ConfigureAwait(false);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<TransSearch>?> GetTransSearch(string searchText, LimDem limDem)
        {
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var cdrel = await GetCdrel().ConfigureAwait(false);
                var inl = (int)limDem;
                var res = await SendHttpRequest<ResultSet<List<TransSearch>?>?>($"api/Inv/SearchTrans/{cdrel.rCode}/{searchText}/{inl}", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
                return res?.ResultObj;
            }
            return null;
        }

        public async Task<(bool, string)> ChangeSchedule(Schedule CurrSelectedSch, Timer timer)
        {
            try
            {
                await SetDrawSelected(value: false).ConfigureAwait(false);
                //if (CurrSelectedSch.Period < DateTime.Now)
                //{
                //    return (false, "Period has ended");
                //}
                //var resul = await SendHttpRequest<ResultSet<bool>>($"api/Data/checkUacCompleted/{CurrSelectedSch.mkey}", RequestType.Get, linkType: LinkType.Data).ConfigureAwait(false);
                //if (!resul.ResultObj)
                //{
                //    return (false, "Cannot change the draw, the draw is not available");
                //}
                await SetSch(CurrSelectedSch).ConfigureAwait(false);
                var newTokenInv = await SendHttpRequest<string>($"api/Login/ChangeDraw/{CurrSelectedSch.mkey}", RequestType.Get).ConfigureAwait(false);
                await ChangeToken(newTokenInv).ConfigureAwait(false);
                List<int> mke = new() { 0, 0, 0 };
                if (await GetIsFranchise().ConfigureAwait(false))
                {
                    var Company = await GetCompany().ConfigureAwait(false);
                    var mkeys = await SendHttpRequest<ResultSet<List<int>>>($"api/Transactions/CheckInvExist/{Company.FCode}", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
                    if (mkeys is null || mkeys.ResultObj is null)
                    {
                        return (false, "Error in franchise Invoice");
                    }
                    mke = mkeys.ResultObj;
                    await SetFranMkeys(mkeys.ResultObj).ConfigureAwait(false);
                }
                var cDRelation = await GetCdrel().ConfigureAwait(false);
                var DashDataRes = await SendHttpRequest<ResultSet<DashBoardData>>($"api/Data/GetDashData/{cDRelation.rCode}/{mke[1]}", RequestType.Get, linkType: LinkType.Data).ConfigureAwait(false);
                var DashData = DashDataRes?.ResultObj;
                if (DashData is null)
                {
                    return (false, "Error. There might be no active draws for this company");
                }
                if (DashData.party is null || DashData.sch is null)
                {
                    return (false, "There was an error in getting the data. Please try again later");
                }
                await SetpartySchTrans(DashData.partySch).ConfigureAwait(false);
                var res = await SendHttpRequest<ResultSet<bool>>("api/Inv/CheckInvoiceDb", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);

                if (!res.ResultObj)
                {
                    return (false, "Draw unavailable");
                }
                var ExtraBalance = await SendHttpRequest<ResultSet<int>>($"api/Inv/GetOtherBalance/{cDRelation.rCode}", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
                var part = await GetParty().ConfigureAwait(false);
                part.Balance += ExtraBalance?.ResultObj ?? 0;
                await SetParty(part).ConfigureAwait(false);
                await SetDrawSelected(value: true).ConfigureAwait(false);
                timer.Change(0, 10000);
                _navigationManager.NavigateTo("/");

                return (true, "");
            }
            catch (Exception ex)
            {
                return (false, "Critical Error");
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
            var bal = amt - amt2;

            await SetCurrentBalance(bal).ConfigureAwait(false);
            if (amt > 0)
            {
                return $"Bal: {bal}";
            }
            return $"Sale: {amt2}";
        }

        internal async Task<bool> CheckEntryEdit(int mkey)
        {
            var res = await SendHttpRequest<ResultSet<bool>>($"api/Transactions/CheckEntryEdit/{mkey}", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
            return res.ResultObj;
        }

        public async Task UpdateAllBalance()
        {
            var part = await GetParty().ConfigureAwait(false);
            var cdrel = await GetCdrel().ConfigureAwait(false);
            var amt = (await SendHttpRequest<ResultSet<int>>($"api/DataSet/Login/GetPartyLimit/{cdrel.CompanyID}/{cdrel.rCode}", RequestType.Get, linkType: LinkType.Login).ConfigureAwait(false))?.ResultObj ?? 0;
            var amt2 = (await SendHttpRequest<ResultSet<int>>($"api/Data/GetPartyBalance/{cdrel.rCode}", RequestType.Get, linkType: LinkType.Data).ConfigureAwait(false))?.ResultObj ?? 0;

            part.Balance = double.Parse(amt2.ToString(), CultureInfo.InvariantCulture);
            await SetParty(part).ConfigureAwait(false);
            cdrel.Limit = amt;
            await SetCdrel(cdrel).ConfigureAwait(false);
        }

        public async Task<MixTransVouchersModel?> GetTransactionsListMix(int amt, int Vno, string type = "1SL")
        {
            var cdrel = await GetCdrel().ConfigureAwait(false);
            var res = await SendHttpRequest<ResultSet<MixTransVouchersModel>>($"api/Transactions/GetVouchers/{cdrel.rCode}/{Vno}/{type}{(amt > 0 ? $"/{amt}" : "")}", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
            return res?.ResultObj;
        }

        public async Task<Inventory?> MakeNewInv(InvData inv)
        {
            var res = await SendHttpRequest<ResultSet<Inventory>>("api/Transactions/MakeNewInv", RequestType.Post, inv, LinkType.Invoice).ConfigureAwait(false);
            return res?.ResultObj;
        }

        public async Task<Inventory?> MakeNewInvSch(InvDataSch inv)
        {
            var res = await SendHttpRequest<ResultSet<Inventory>>("api/Transactions/MakeNewInvSch", RequestType.Post, inv, LinkType.Invoice).ConfigureAwait(false);
            return res?.ResultObj;
        }

        public async Task<(string Name, string city, string Code, string Balance, string CompanyDetails, string pname)> GetDashboardData()
        {
            var party = await GetParty().ConfigureAwait(false) ?? new();
            var comp = await GetCompany().ConfigureAwait(false) ?? new();
            var cdRel = await GetCdrel().ConfigureAwait(false) ?? new();

            return (party.Name, comp.City, party.Code, cdRel.Limit.ToString("F0", CultureInfo.CurrentCulture), comp.Pcode + " - " + comp.PName, cdRel.UName);
        }

        public async Task<IList<Schedule>> GetScheduleList(bool notall)
        {
            try
            {
                var getting = await SendHttpRequest<ResultSet<List<Schedule>>>($"api/Data/GetScheduleList/{notall}", RequestType.Get, linkType: LinkType.Data).ConfigureAwait(false);
                var resObj = getting.ResultObj;
                await SetAllSch(resObj).ConfigureAwait(false);
                return resObj;
            }
            catch (Exception)
            {
                return new List<Schedule>();
            }
        }

        public async Task<bool> IsQtyUser() => (await GetCompany().ConfigureAwait(false)).Qtyuser;

        private async Task SetCompany(Company newCom)
        {
            await _localStorage.SetItemAsync("Company", newCom).ConfigureAwait(false);
            await SetDataLink(newCom.WebApiD).ConfigureAwait(false);
        }

        public async Task<Company> GetCompany() => await _localStorage.GetItemAsync<Company>("Company").ConfigureAwait(false);

        public async Task SetRepeatData(RepeatDataReturnWA newObj)
        {
            await _localStorage.SetItemAsync("RepeatData", newObj).ConfigureAwait(false);
        }

        public async Task<RepeatDataReturnWA> GetRepeatData() => await _localStorage.GetItemAsync<RepeatDataReturnWA>("RepeatData").ConfigureAwait(false);

        private async Task SetCdrel(CDRelation newcd)
        {
            await _localStorage.SetItemAsync("cdRel", newcd).ConfigureAwait(false);
        }

        public async Task<CDRelation> GetCdrel() => await _localStorage.GetItemAsync<CDRelation>("cdRel").ConfigureAwait(false);

        private async Task SetCurrentBalance(int amt)
        {
            await _localStorage.SetItemAsync("CurrBalanceAmount", amt).ConfigureAwait(false);
        }

        public async Task<int> GetCurrentBalance() => await _localStorage.GetItemAsync<int>("CurrBalanceAmount").ConfigureAwait(false);

        private async Task SetpartySchTrans(PartySch partySch)
        {
            await _localStorage.SetItemAsync("partySchTrans", partySch).ConfigureAwait(false);
        }

        public async Task<PartySch> GetpartySchTrans() => await _localStorage.GetItemAsync<PartySch>("partySchTrans").ConfigureAwait(false);

        private async Task SetSch(Schedule newCom)
        {
            await _localStorage.SetItemAsync("sch", newCom).ConfigureAwait(false);
            await SetInvLink(newCom.WebApiI).ConfigureAwait(false);
        }

        public async Task<Schedule> GetSch() => await _localStorage.GetItemAsync<Schedule>("sch").ConfigureAwait(false);

        public async Task SetParty(Party newParty)
        {
            await _localStorage.SetItemAsync("party", newParty).ConfigureAwait(false);
        }

        public async Task<Party> GetParty() => await _localStorage.GetItemAsync<Party>("party").ConfigureAwait(false);

        private async Task SetAllSch(IList<Schedule> lst)
        {
            await _localStorage.SetItemAsync("allSch", lst).ConfigureAwait(false);
        }

        public async Task UnsetAllSch()
        {
            await _localStorage.RemoveItemAsync("allSch").ConfigureAwait(false);
        }

        public async Task<IList<Schedule>> GetAllSch() => await _localStorage.GetItemAsync<List<Schedule>>("allSch").ConfigureAwait(false);

        public async Task SetCompanySelected(bool value) => await _localStorage.SetItemAsync("IsCompSel", value).ConfigureAwait(false);

        public async Task<bool> IsCompanySelected() => await _localStorage.GetItemAsync<bool>("IsCompSel").ConfigureAwait(false);

        public async Task SetDrawSelected(bool value) => await _localStorage.SetItemAsync("IsDrawSel", value).ConfigureAwait(false);

        public async Task<bool> IsDrawSelected() => await _localStorage.GetItemAsync<bool>("IsDrawSel").ConfigureAwait(false);

        //public async Task<bool> IsDrawSelected()
        //{
        //    try
        //    {
        //        var sel = await _localStorage.GetItemAsync<bool>("IsDrawSel").ConfigureAwait(false);
        //        if (sel)
        //        {
        //            var sch = await GetSch().ConfigureAwait(false);
        //            if (sch.Period < DateTime.Now)
        //            {
        //                await SetDrawSelected(value: false).ConfigureAwait(false);
        //                return false;
        //            }
        //            var result = await SendHttpRequest<ResultSet<bool>>($"api/Data/checkUacCompleted/{sch.mkey}", RequestType.Get, linkType: LinkType.Data).ConfigureAwait(false);
        //            await SetDrawSelected(value: result.ResultObj).ConfigureAwait(false);

        //            return result.ResultObj;
        //        }
        //        return false;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        public async Task<IEnumerable<CDRelation>?> GetCdRelations()
        {
            try
            {
                var ID = await GetUserID().ConfigureAwait(false);
                var listret = await SendHttpRequest<ResultSet<IEnumerable<CDRelation>>>($"api/Company/GetCompanyList/{ID}/true", RequestType.Get).ConfigureAwait(false);
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