using XtremeModels;

using XtremeWasmApp.Models;

namespace XtremeWasmApp.Services
{
    public interface IWebApiService
    {
        Task<Models.LoginResult?> Login(Models.LoginModel loginModel);

        Task UnsetAllSch();

        Task<(string Name, string city, string Code, string Balance, string CompanyDetails, string pname)> GetDashboardData();

        Task Logout();

        Task<Models.RegisterResult?> Register(Models.RegisterModel registerModel);

        Task<string?> GetTest();

        Task<int?> GetUserID();

        Task<TopMarqueData> GetMarqData();

        Task<string?> GetMbm();

        Task<bool> IsCompanySelected();

        Task<bool> IsDrawSelected();

        Task<bool> ChangeCompany(CDRelation cDRelation);

        Task<IList<Schedule>> GetAllSch();

        Task<IList<Schedule>> GetScheduleList();

        Task<bool> ChangeSchedule(Schedule CurrSelectedSch);

        Task<IEnumerable<CDRelation>?> GetCdRelations();

        //Task<bool?> GetFALoggedIn();

        //Task<int?> SendVerificationEmail(bool retry = false);

        //Task<bool?> TwoFactorLogin(string Code);

        //void SetTFA(bool val);
    }
}