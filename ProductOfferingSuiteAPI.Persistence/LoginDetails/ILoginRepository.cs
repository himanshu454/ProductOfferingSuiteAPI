using ProductOfferingSuiteAPI.Domain.Login;

namespace ProductOfferingSuiteAPI.Persistence.LoginDetails
{
    public interface ILoginRepository
    {
        Task<LoginModel> GetUserLogin(LoginModel loginmodel);
        Task<LoginPOSModel> GetLoginDetail(LoginPOSInputModel loginPOSmodelinput);
        Task<LoginPOSRegModel> LoginRegistration(LoginPOSRegInputModel loginPOSReginput);
        Task<int> UpdateLoginProfile(LoginPOSUpdateProfileInputModel updateProfile);
        Task<int> ChangePassword(LoginPOSChangePwdInputModel changePwd);
        Task<LoginPOSInputModel> ReLogin(int UserID);
    }
}