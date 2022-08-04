using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

using Newtonsoft.Json;

using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

using XtremeModels;

using XtremeWasmApp.Models;

namespace XtremeWasmApp.Services
{
    public class WebApiService
    {
        private readonly HttpData _httpData;
        private readonly HttpClient _httpClient;
        private readonly IRefreshService _refresh;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;
        //private readonly JSRuntime js;
        private readonly NavigationManager _navigationManager;
        public string DType { get; set; } = "";

        public WebApiService(AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage, HttpClient httpClient, NavigationManager navigationManager, HttpData httpData, IRefreshService refresh)//, JSRuntime js)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
            _httpClient = httpClient;
            _navigationManager = navigationManager;
            _httpData = httpData;
            _refresh = refresh;
            //this.js = js;
        }

        public async Task SetDtype(string dtype)
        { await _localStorage.SetItemAsync("dtype", dtype).ConfigureAwait(false); DType = dtype; }

        public async Task<string> GetDtype()
        {
            return await _localStorage.GetItemAsync<string>("dtype").ConfigureAwait(false);
        }

        public async Task<bool> GetCode(string Email)
        {
            byte[] bytes = Encoding.Default.GetBytes(Email);
            Email = Encoding.UTF8.GetString(bytes);
            var res = await SendHttpRequest<bool>($"/api/Login/RegisterCode?Email={Email}", RequestType.Get).ConfigureAwait(false);
            return res;
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

        public async Task<IEnumerable<Transaction?>?> GetInvoiceDetails(int Mkey)
        {
            var cdRel = await GetCdrel().ConfigureAwait(false);
            var res = await SendHttpRequest<ResultSet<List<Transaction?>?>>($"api/Transactions/GetVouchersInvView/{cdRel.rCode}/{Mkey}", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
            return res?.ResultObj;
        }

        private async Task<T?> SendHttpRequest<T>(string URL, RequestType type, object? objPost = null!, LinkType linkType = LinkType.Login)
        {
            try
            {

                var baseUri = linkType switch
                {
                    LinkType.Login => _httpData.BaseAddress,
                    LinkType.Data => _httpData.DataLink,
                    LinkType.Invoice => _httpData.InvoiceLink,
                    LinkType.Reporting => _httpData.ReportingLink,
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
                    RequestType.Post => await _httpClient.PostAsync(baseUri.AbsoluteUri + URL, new StringContent(JsonConvert.SerializeObject(objPost), Encoding.UTF8, "application/json")).ConfigureAwait(false),// await _httpClient.PostAsJsonAsync(baseUri.AbsoluteUri + URL, objPost).ConfigureAwait(false),
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
        //public async ValueTask<object> GetReport(FileReturnModel? fileInfo)
        //{
        //return await js.SaveAs(fileInfo?.FileName ?? "", fileInfo?.File ?? Array.Empty<byte>()).ConfigureAwait(false);
        //}
        public async Task<FileReturnModel?> GetMixInvoiceSerialReport(Inventory inv, bool IsSerial)
        {
            try
            {
                var dt = await SendHttpRequest<ResultSet<List<DtReturn>>>($"api/Transactions/GetRdtDataSerial/{inv.vid}/{inv.Vno}/{(IsSerial ? 0 : 1)}/True/{inv.propKey}", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
                if (dt is not null && (dt.ResultObj[0].Row.Count == 0 || dt.ResultObj[1].Row.Count == 0))
                {
                    return new()
                    {
                        FileName = "Error: No Records",
                        File = null,

                    };
                }

                var comp = await GetCompany().ConfigureAwait(false);
                var cdRel = await GetCdrel().ConfigureAwait(false);
                var party = await GetParty().ConfigureAwait(false);
                var sch = await GetSch().ConfigureAwait(false);
                MixInvSerialModel? model = new()
                {
                    DReturn = dt?.ResultObj.Select(x => x.ToStringArrayRows())?.ToList(),
                    XDATE = DateTime.Now,
                    Comp = comp?.Pcode,
                    Vno = inv.Vno.ToString(CultureInfo.InvariantCulture),
                    Ref = inv.Ref,
                    Uid = cdRel.UName,//"{{{ " + cdRel.UName + " }}}",
                    Lk = inv.lk,
                    Lk2 = inv.lk2,
                    VType = inv.vid,
                    DMode = inv.dmode > 0,
                    Code = party.Code,
                    Name = party.Name,
                    Ld1 = sch.DId.ToString(CultureInfo.InvariantCulture),
                    Ld2 = sch.BId,
                    Ld2c = sch.Cat,
                    Ld3 = sch.Date.ToShortDateString(),
                    Ld4 = sch.City,
                    Osver = "Web Application { PBTS.Net } Version 1.1.2022",
                    mmptit = "R.M Developer System ( azarnishom05@gmail.com )",
                };
                return await SendHttpRequest<FileReturnModel?>("api/Reporting/MixInvSerialBytes", RequestType.Post, model, LinkType.Reporting).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<FileReturnModel?> GetMixSchemeInvoiceReport(Inventory inv, bool IsSerial)
        {
            try
            {
                var dt = await SendHttpRequest<ResultSet<List<DtReturn>>>($"api/Transactions/GetRdtDataSerial/{inv.vid}/{inv.Vno}/{(IsSerial ? 0 : 1)}/True/{inv.propKey}", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
                if (dt is not null && (dt.ResultObj[0].Row.Count == 0 || dt.ResultObj[1].Row.Count == 0))
                {
                    return new()
                    {
                        FileName = "Error: No Records",
                        File = null,

                    };
                }
                var sch = await GetSch().ConfigureAwait(false);
                var comp = await GetCompany().ConfigureAwait(false);
                var cdRel = await GetCdrel().ConfigureAwait(false);
                var party = await GetParty().ConfigureAwait(false);
                MixSchemeModel? model = new()
                {
                    DReturn = dt?.ResultObj.Select(x => x.ToStringArrayRows())?.ToList(),
                    Vid = inv.vid,
                    Ld1 = sch.DId.ToString(CultureInfo.InvariantCulture),
                    Ld2 = sch.BId,
                    Ld2c = sch.Cat,
                    Ld3 = sch.Date.ToShortDateString(),
                    Ld4 = sch.City,
                    Code = party.Code,
                    Name = party.Name,
                    Ref = inv.Ref,
                    lk = inv.lk,
                    lk2 = inv.lk2,
                    dmode = inv.dmode > 0,
                    Osver = "Web Application { PBTS.Net } Version 1.1.2022",
                    mmptit = "R.M Developer System ( azarnishom05@gmail.com )",
                    uid = cdRel.UName,
                    comp = comp?.Pcode,
                    vno = inv.Vno,
                };
                return await SendHttpRequest<FileReturnModel?>("api/Reporting/MixSchemeBytes", RequestType.Post, model, LinkType.Reporting).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<FileReturnModel?> GetSchemePacketInvoiceReport(InvoiceViewItem inv, bool IsSerial)
        {
            try
            {
                var dt = await SendHttpRequest<ResultSet<List<DtReturn>>>($"api/Transactions/GetRdtDataSerial/{inv.Category}/{inv.InvNo}/{(IsSerial ? 0 : 1)}/True/{inv.MKey}", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
                if (dt is not null && (dt.ResultObj[0].Row.Count == 0 || dt.ResultObj[1].Row.Count == 0))
                {
                    return new()
                    {
                        FileName = "Error: No Records",
                        File = null,

                    };
                }
                var sch = await GetSch().ConfigureAwait(false);
                var comp = await GetCompany().ConfigureAwait(false);
                var cdRel = await GetCdrel().ConfigureAwait(false);
                var party = await GetParty().ConfigureAwait(false);
                SchemePacketModel? model = new()
                {
                    DReturn = dt?.ResultObj.Select(x => x.ToStringArrayRows())?.ToList(),
                    Vno = inv.InvNo,
                    Vid = "1PS",
                    Ld1 = sch.DId.ToString(CultureInfo.InvariantCulture),
                    Ld2 = sch.BId,
                    Ld2c = sch.Cat,
                    Ld3 = sch.Date.ToShortDateString(),
                    Ld4 = sch.City,
                    Code = party.Code,
                    Name = party.Name,
                    Ref = inv.Reference,
                    lk = inv.Printable,
                    lk2 = inv.Printable,
                    dmode = (int)inv.LD > 0,
                    Osver = "Web Application { PBTS.Net } Version 1.1.2022",
                    mmptit = "R.M Developer System ( azarnishom05@gmail.com )",
                    uid = cdRel.UName,
                    comp = comp?.Pcode,
                };
                return await SendHttpRequest<FileReturnModel?>("api/Reporting/SchemePktBytes", RequestType.Post, model, LinkType.Reporting).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return null;
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
            var keys = await GetFranMkeys().ConfigureAwait(false);
            if (isFranchise)
            {
                mkey = keys[0];
            }
            var res = await SendHttpRequest<ResultSet<Transaction?>>($"api/Transactions/InsertEntry/{isFranchise}/{mkey}/{keys[3]}", RequestType.Post, invD, LinkType.Invoice).ConfigureAwait(false);
            return res?.ResultObj;
        }

        public async Task<Transaction?> MakeNewEntrySch(EntryDataSch invD)
        {
            var isFranchise = await GetIsFranchise().ConfigureAwait(false);
            var mkey = 0;
            var keys = await GetFranMkeys().ConfigureAwait(false);
            if (isFranchise)
            {
                mkey = keys[1];
            }
            var res = await SendHttpRequest<ResultSet<Transaction?>>($"api/Transactions/InsertEntrySch/{isFranchise}/{mkey}/{keys[4]}", RequestType.Post, invD, LinkType.Invoice).ConfigureAwait(false);
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

        public async Task<IList<InvoiceViewItem>> GetInvoiceList()
        {
            var cdRel = await GetCdrel().ConfigureAwait(false);
            var retList = await SendHttpRequest<ResultSet<List<InvoiceViewItem>>>($"api/Transactions/GetInvList/{cdRel.rCode}", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
            return retList.ResultObj;
        }

        public async Task<(bool, string)> ChangeCompany(CDRelation cDRelation)
        {
            string oldToken = await _localStorage.GetItemAsync<string>("authToken").ConfigureAwait(false);
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
                    await ChangeToken(oldToken).ConfigureAwait(false);
                    return (false, "Error in changing company");
                }
                var Company = res.ResultObj;
                var newToken = await SendHttpRequest<string>($"api/Login/ChangeCompany/0/{cDRelation.CompanyID}", RequestType.Get).ConfigureAwait(false);
                if (newToken is null)
                {
                    await ChangeToken(oldToken).ConfigureAwait(false);
                    return (false, "Error in changing company");
                }
                await ChangeToken(newToken).ConfigureAwait(false);

                await SetCdrel(cDRelation).ConfigureAwait(false);
                await SetCompany(Company).ConfigureAwait(false);
                var isFranchise = Company.Stype == 'F';
                var isDealer = Company.IsDealer || !string.IsNullOrWhiteSpace(Company.DCode);
                await setIsFranchise(isFranchise).ConfigureAwait(false);
                await setIsDealer(isDealer).ConfigureAwait(false);
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
                var homepageres = await SendHttpRequest<ResultSet<HomePageResultsModel>>("api/Inv/GetHomePageResults", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
                await SetHomePageResult(homepageres?.ResultObj).ConfigureAwait(false);

                if (DashData is null)
                {
                    await ChangeToken(oldToken).ConfigureAwait(false);
                    return (false, "Error. There might be no active draws for this company");
                }
                if (DashData.party is null || DashData.sch is null)
                {
                    await ChangeToken(oldToken).ConfigureAwait(false);
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
                        List<int> mke = new() { 0, 0, 0, 0, 0, 0 };
                        if (isFranchise || isDealer)
                        {
                            var mkeys = await SendHttpRequest<ResultSet<List<int>>>($"api/Transactions/CheckInvExist/{Company.FCode}/{Company.DealerCode}", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
                            if (mkeys is null || mkeys.ResultObj is null)
                            {
                                await ChangeToken(oldToken).ConfigureAwait(false);
                                return (false, "Error in franchise Invoice");
                            }
                            mke = mkeys.ResultObj;
                        }
                        await SetFranMkeys(mke).ConfigureAwait(false);

                        var partySchCurr = await GetpartySchTrans().ConfigureAwait(false);
                        if (partySchCurr is not null)
                        {
                            partySchCurr.Win_Rate1 = Company.Sfc1;
                            partySchCurr.Win_Rate2 = Company.Sfc2;
                            partySchCurr.Win_Rate3 = Company.Std1;
                            partySchCurr.Win_Rate4 = Company.Std2;
                            await SetpartySchTrans(partySchCurr).ConfigureAwait(false);
                        }
                        var resl = await SendHttpRequest<ResultSet<bool>>("api/Inv/CheckInvoiceDb", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
                        if (!resl.ResultObj)
                        {
                            await ChangeToken(oldToken).ConfigureAwait(false);
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
                await ChangeToken(oldToken).ConfigureAwait(false);
                return (false, "Critical error occured");
            }
        }

        public async Task SetFranMkeys(IList<int>? mkeys)
        {
            await _localStorage.SetItemAsync("FranMkeys", mkeys).ConfigureAwait(false);
        }

        public async Task<IList<int>?> GetFranMkeys()
        {
            return await _localStorage.GetItemAsync<List<int>>("FranMkeys").ConfigureAwait(false);
        }

        public async Task setFcode(int fCode)
        {
            await _localStorage.SetItemAsync("FCode", fCode).ConfigureAwait(false);
        }

        public async Task setIsFranchise(bool v)
        {
            await _localStorage.SetItemAsync("Franchise", v).ConfigureAwait(false);
        }
        public async Task<bool> GetIsFranchise()
        {
            return await _localStorage.GetItemAsync<bool>("Franchise").ConfigureAwait(false);
        }
        public async Task setIsDealer(bool v)
        {
            await _localStorage.SetItemAsync("isDealer", v).ConfigureAwait(false);
        }
        public async Task<bool> GetIsDealer()
        {
            return await _localStorage.GetItemAsync<bool>("isDealer").ConfigureAwait(false);
        }
        public async Task<int> GetFcode()
        {
            return await _localStorage.GetItemAsync<int>("FCode").ConfigureAwait(false);
        }

        public async Task<bool> GetIsCompanyBlocked()
        {
            var comp = await GetCompany().ConfigureAwait(false);
            return await SendHttpRequest<bool>($"api/Login/FranBlock/{comp.ID}", RequestType.Get).ConfigureAwait(false);
        }

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
            string oldToken = await _localStorage.GetItemAsync<string>("authToken").ConfigureAwait(false);
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
                List<int> mke = new() { 0, 0, 0, 0, 0, 0 };
                var isFranchise = await GetIsFranchise().ConfigureAwait(false);
                var IsDealer = await GetIsDealer().ConfigureAwait(false);
                var Company = await GetCompany().ConfigureAwait(false);
                if (isFranchise || IsDealer)
                {
                    var mkeys = await SendHttpRequest<ResultSet<List<int>>>($"api/Transactions/CheckInvExist/{Company.FCode}/{Company.DealerCode}", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
                    if (mkeys is null || mkeys.ResultObj is null)
                    {
                        await ChangeToken(oldToken).ConfigureAwait(false);
                        return (false, "Error in franchise Invoice");
                    }
                    mke = mkeys.ResultObj;
                }
                await SetFranMkeys(mke).ConfigureAwait(false);

                var cDRelation = await GetCdrel().ConfigureAwait(false);
                var DashDataRes = await SendHttpRequest<ResultSet<DashBoardData>>($"api/Data/GetDashData/{cDRelation.rCode}/{mke[1]}", RequestType.Get, linkType: LinkType.Data).ConfigureAwait(false);
                var DashData = DashDataRes?.ResultObj;
                if (DashData is null)
                {
                    await ChangeToken(oldToken).ConfigureAwait(false);
                    return (false, "Error. There might be no active draws for this company");
                }
                var homepageres = await SendHttpRequest<ResultSet<HomePageResultsModel>>("api/Inv/GetHomePageResults", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
                await SetHomePageResult(homepageres?.ResultObj).ConfigureAwait(false);
                if (DashData.party is null || DashData.sch is null)
                {
                    await ChangeToken(oldToken).ConfigureAwait(false);
                    return (false, "There was an error in getting the data. Please try again later");
                }
                if (DashData.partySch is not null)
                {
                    DashData.partySch.Win_Rate1 = Company.Sfc1;
                    DashData.partySch.Win_Rate2 = Company.Sfc2;
                    DashData.partySch.Win_Rate3 = Company.Std1;
                    DashData.partySch.Win_Rate4 = Company.Std2;
                }
                await SetpartySchTrans(DashData.partySch).ConfigureAwait(false);
                var res = await SendHttpRequest<ResultSet<bool>>("api/Inv/CheckInvoiceDb", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);

                if (!res.ResultObj)
                {
                    await ChangeToken(oldToken).ConfigureAwait(false);
                    return (false, "Draw unavailable");
                }
                var ExtraBalance = await SendHttpRequest<ResultSet<int>>($"api/Inv/GetOtherBalance/{cDRelation.rCode}", RequestType.Get, linkType: LinkType.Invoice).ConfigureAwait(false);
                var part = await GetParty().ConfigureAwait(false);
                part.Balance += ExtraBalance?.ResultObj ?? 0;
                await SetParty(part).ConfigureAwait(false);
                await SetDrawSelected(value: true).ConfigureAwait(false);
                timer.Change(0, 12000);
                _navigationManager.NavigateTo("/");

                return (true, "");
            }
            catch (Exception ex)
            {
                await ChangeToken(oldToken).ConfigureAwait(false);
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

        public async Task<(string Name, string City, string Code, string, string, string UName, HomePageResultsModel HomePageResult)> GetDashboardData()
        {
            var party = await GetParty().ConfigureAwait(false) ?? new();
            var comp = await GetCompany().ConfigureAwait(false) ?? new();
            var cdRel = await GetCdrel().ConfigureAwait(false) ?? new();
            var HomePageResult = await GetHomePageResult().ConfigureAwait(false);
            return (party.Name, comp.City, party.Code, cdRel.Limit.ToString("F0", CultureInfo.CurrentCulture), comp.Pcode + " - " + comp.PName, cdRel.UName, HomePageResult);
        }

        public async Task<IList<Schedule>> GetScheduleList(bool notall, bool isSelected = false)
        {
            try
            {
                var getting = await SendHttpRequest<ResultSet<List<Schedule>>>($"api/Data/GetScheduleList/{notall}/{isSelected}", RequestType.Get, linkType: LinkType.Data).ConfigureAwait(false);
                var resObj = getting.ResultObj;
                await SetAllSch(resObj).ConfigureAwait(false);
                return resObj;
            }
            catch (Exception)
            {
                return new List<Schedule>();
            }
        }

        public async Task<bool> IsQtyUser()
        {
            return (await GetCompany().ConfigureAwait(false)).Qtyuser;
        }

        private async Task SetCompany(Company newCom)
        {
            await _localStorage.SetItemAsync("Company", newCom).ConfigureAwait(false);
            await SetDataLink(newCom.WebApiD).ConfigureAwait(false);
        }

        public async Task<Company?> GetCompany()
        {
            return await _localStorage.GetItemAsync<Company?>("Company").ConfigureAwait(false);
        }
        private async Task SetHomePageResult(HomePageResultsModel newCom)
        {
            await _localStorage.SetItemAsync("HomePageResult", newCom).ConfigureAwait(false);
        }
        private async Task<HomePageResultsModel> GetHomePageResult()
        {
            return await _localStorage.GetItemAsync<HomePageResultsModel>("HomePageResult").ConfigureAwait(false);
        }

        public async Task SetRepeatData(RepeatDataReturnWA newObj)
        {
            await _localStorage.SetItemAsync("RepeatData", newObj).ConfigureAwait(false);
        }

        public async Task<RepeatDataReturnWA> GetRepeatData()
        {
            return await _localStorage.GetItemAsync<RepeatDataReturnWA>("RepeatData").ConfigureAwait(false);
        }

        private async Task SetCdrel(CDRelation newcd)
        {
            await _localStorage.SetItemAsync("cdRel", newcd).ConfigureAwait(false);
        }

        public async Task<CDRelation> GetCdrel()
        {
            return await _localStorage.GetItemAsync<CDRelation>("cdRel").ConfigureAwait(false);
        }

        private async Task SetCurrentBalance(int amt)
        {
            await _localStorage.SetItemAsync("CurrBalanceAmount", amt).ConfigureAwait(false);
        }

        public async Task<int> GetCurrentBalance()
        {
            return await _localStorage.GetItemAsync<int>("CurrBalanceAmount").ConfigureAwait(false);
        }

        private async Task SetpartySchTrans(PartySch partySch)
        {
            await _localStorage.SetItemAsync("partySchTrans", partySch).ConfigureAwait(false);
        }

        public async Task<PartySch> GetpartySchTrans()
        {
            return await _localStorage.GetItemAsync<PartySch>("partySchTrans").ConfigureAwait(false);
        }

        private async Task SetSch(Schedule newCom)
        {
            await _localStorage.SetItemAsync("sch", newCom).ConfigureAwait(false);
            await SetInvLink(newCom.WebApiI).ConfigureAwait(false);
        }

        public async Task<Schedule> GetSch()
        {
            return await _localStorage.GetItemAsync<Schedule>("sch").ConfigureAwait(false);
        }

        public async Task SetParty(Party newParty)
        {
            await _localStorage.SetItemAsync("party", newParty).ConfigureAwait(false);
        }

        public async Task<Party> GetParty()
        {
            return await _localStorage.GetItemAsync<Party>("party").ConfigureAwait(false);
        }

        private async Task SetAllSch(IList<Schedule> lst)
        {
            await _localStorage.SetItemAsync("allSch", lst).ConfigureAwait(false);
        }

        public async Task UnsetAllSch()
        {
            await _localStorage.RemoveItemAsync("allSch").ConfigureAwait(false);
        }

        public async Task<IList<Schedule>> GetAllSch()
        {
            return await _localStorage.GetItemAsync<List<Schedule>>("allSch").ConfigureAwait(false);
        }

        public async Task SetCompanySelected(bool value)
        {
            await _localStorage.SetItemAsync("IsCompSel", value).ConfigureAwait(false);
        }

        public async Task<bool> IsCompanySelected()
        {
            return await _localStorage.GetItemAsync<bool>("IsCompSel").ConfigureAwait(false);
        }

        public async Task SetDrawSelected(bool value)
        {
            await _localStorage.SetItemAsync("IsDrawSel", value).ConfigureAwait(false);
        }

        public async Task<bool> IsDrawSelected()
        {
            return await _localStorage.GetItemAsync<bool>("IsDrawSel").ConfigureAwait(false);
        }

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
            _httpClient.DefaultRequestHeaders.Authorization = null;
            await _localStorage.ClearAsync().ConfigureAwait(false);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider)
                .MarkUserAsLoggedOut();
            _refresh.CallRequestRefresh();
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