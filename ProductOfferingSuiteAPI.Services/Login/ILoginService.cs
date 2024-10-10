using ProductOfferingSuiteAPI.Domain.Login;

namespace ProductOfferingSuiteAPI.Services.Login
{
    public interface ILoginService
    {
        Task<LoginModel> GetUserLogin(LoginModel login);
        string GenerateToken(LoginModel loginModel);

        Task<LoginPOSModel> GetLoginDetail(LoginPOSInputModel loginPOSinput);
        string GenerateTokenPOS(LoginPOSInputModel loginModel);

        Task<LoginPOSRegModel> LoginRegistration(LoginPOSRegInputModel loginPOSReginput);

        Task<int> UpdateLoginProfile(LoginPOSUpdateProfileInputModel updateProfile);

        Task<int> ChangePassword(LoginPOSChangePwdInputModel changePwd);

        Task<LoginPOSInputModel> ReLogin(int UserID);
    }


}
