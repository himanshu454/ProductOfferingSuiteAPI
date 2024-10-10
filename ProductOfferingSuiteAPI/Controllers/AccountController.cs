using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using ProductOfferingSuiteAPI.Domain.Login;
using ProductOfferingSuiteAPI.Domain.Global;
using ProductOfferingSuiteAPI.Services.Login;
using ProductOfferingSuiteAPI.APIUtility.Controllers;


namespace ProductOfferingSuiteAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiBaseController<AccountController>
    {
        private readonly ILoginService _loginService;

        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginPOSInputModel loginModelInput)
        {
            try
            {
                TransactionDataModel<LoginPOSModel> transactionDataModel = new TransactionDataModel<LoginPOSModel>();

                if (string.IsNullOrEmpty(loginModelInput.UserName) || string.IsNullOrEmpty(loginModelInput.Password))
                {
                    transactionDataModel.ReturnCode = -1;
                    transactionDataModel.Message = "UserName or Password cannot be empty";
                    return Ok(transactionDataModel);
                }

                var Result = await _loginService.GetLoginDetail(loginModelInput);
                if (Result == null)
                {
                    transactionDataModel.ReturnCode = -2;
                    transactionDataModel.Message = "Invalid username or password";
                    return Ok(transactionDataModel);
                }

                transactionDataModel.ReturnCode = 0;
                transactionDataModel.Message = "User Authenticate successfully";
                transactionDataModel.Data = Result;
                transactionDataModel.Token = _loginService.GenerateTokenPOS(loginModelInput);
                return Ok(transactionDataModel);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Account-Login");
                return StatusCode(500, "Error");
            }
        }


        [HttpPost]
        [Route("ReLogin")]
        public async Task<IActionResult> ReLogin(int userID)
        {
            try
            {
                TransactionDataModel<LoginPOSInputModel> transactionDataModel = new TransactionDataModel<LoginPOSInputModel>();

                if (userID == 0)
                {
                    transactionDataModel.ReturnCode = -1;
                    transactionDataModel.Message = "Please send UserID";
                    return Ok(transactionDataModel);
                }

                var Result = await _loginService.ReLogin(userID);
                if (Result == null)
                {
                    transactionDataModel.ReturnCode = -2;
                    transactionDataModel.Message = "Invalid username or password";
                    return Ok(transactionDataModel);
                }

                transactionDataModel.ReturnCode = 0;
                transactionDataModel.Message = "User Authenticate successfully";
                transactionDataModel.Data = Result;
                transactionDataModel.Token = _loginService.GenerateTokenPOS(Result);
                return Ok(transactionDataModel);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Account-ReLogin");
                return StatusCode(500, "Error");
            }
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Registration([FromBody] LoginPOSRegInputModel loginModelRegInput)
        {
            try
            {
                TransactionDataModel<LoginPOSRegModel> transactionDataModel = new TransactionDataModel<LoginPOSRegModel>();

                if (string.IsNullOrEmpty(loginModelRegInput.FirstName) || string.IsNullOrEmpty(loginModelRegInput.LastName))
                {
                    transactionDataModel.ReturnCode = -1;
                    transactionDataModel.Message = "First Name or Last Name cannot be empty";
                    return Ok(transactionDataModel);
                }

                var Result = await _loginService.LoginRegistration(loginModelRegInput);
                if (Result == null)
                {
                    transactionDataModel.ReturnCode = -2;
                    transactionDataModel.Message = "Registration failed.Please try again.";
                    return Ok(transactionDataModel);
                }

                transactionDataModel.ReturnCode = 0;
                transactionDataModel.Message = "Registration created successfully";
                transactionDataModel.Data = Result;
                return Ok(transactionDataModel);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Account-Registration");
                return StatusCode(500, "Error");
            }
        }

    }
}
