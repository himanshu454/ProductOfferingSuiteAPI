using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ProductOfferingSuiteAPI.Domain.Login;
using ProductOfferingSuiteAPI.Domain.Global;
using ProductOfferingSuiteAPI.Persistence.LoginDetails;

namespace ProductOfferingSuiteAPI.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly JwtTokenConfig _jwtTokenConfig;

        public LoginService(ILoginRepository loginRepository, IOptions<JwtTokenConfig> jwtTokenConfig)
        {
            _loginRepository = loginRepository;
            _jwtTokenConfig = jwtTokenConfig.Value;
        }


        public async Task<LoginModel> GetUserLogin(LoginModel login)
        {
            return await _loginRepository.GetUserLogin(login);
        }

        public string GenerateToken(LoginModel loginModel)
        {
            var claims = new[]
            {
                new Claim("username", loginModel.UserNameV),
                new Claim("password",loginModel.UserPassWord)
            };
            string issuer = _jwtTokenConfig.ValidIssuer;
            string audience = _jwtTokenConfig.ValidAudience;
            var tokeykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenConfig.IssuerSigningKey));
            var signingCredentials = new SigningCredentials(tokeykey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.AddDays(1), signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<LoginPOSModel> GetLoginDetail(LoginPOSInputModel loginPOSinput)
        {
            return await _loginRepository.GetLoginDetail(loginPOSinput);
        }

        public async Task<LoginPOSRegModel> LoginRegistration(LoginPOSRegInputModel loginPOSReginput)
        {
            return await _loginRepository.LoginRegistration(loginPOSReginput);
        }

        public string GenerateTokenPOS(LoginPOSInputModel loginModel)
        {
            var claims = new[]
            {
                new Claim("username", loginModel.UserName),
                new Claim("password",loginModel.Password)
            };
            string issuer = _jwtTokenConfig.ValidIssuer;
            string audience = _jwtTokenConfig.ValidAudience;
            var tokeykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenConfig.IssuerSigningKey));
            var signingCredentials = new SigningCredentials(tokeykey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.AddDays(1), signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<int> UpdateLoginProfile(LoginPOSUpdateProfileInputModel updateProfile)
        {
            return await _loginRepository.UpdateLoginProfile(updateProfile);
        }

        public async Task<int> ChangePassword(LoginPOSChangePwdInputModel changePwd)
        {
            return await _loginRepository.ChangePassword(changePwd);
        }

        public async Task<LoginPOSInputModel> ReLogin(int UserID)
        {
            return await _loginRepository.ReLogin(UserID);
        }
    }
}
