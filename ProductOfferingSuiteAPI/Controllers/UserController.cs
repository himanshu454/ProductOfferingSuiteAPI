//using DesignComplexityAPI.Services.ItemDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductOfferingSuiteAPI.APIUtility.Controllers;
using ProductOfferingSuiteAPI.Domain.Global;
using ProductOfferingSuiteAPI.Domain.Login;
using ProductOfferingSuiteAPI.Services.Login;

namespace ProductOfferingSuiteAPI.Controllers
{
    public class UserController : ApiBaseController<UserController>
    {
        private readonly ILoginService _loginService;

        public UserController(ILoginService loginService)
        {
            _loginService = loginService;
        }


        [HttpPost]
        [Route("UpdateProfile")]
        public async Task<IActionResult> UpdateLoginProfile([FromBody] LoginPOSUpdateProfileInputModel updateProfile)
        {
            try
            {
                TransactionDataModel<LoginPOSModel> transactionDataModel = new TransactionDataModel<LoginPOSModel>();

                var Result = await _loginService.UpdateLoginProfile(updateProfile);
                if (Result < 0)
                {
                    transactionDataModel.ReturnCode = Result;
                    transactionDataModel.Message = "Error occur while saving.";
                    return Ok(transactionDataModel);
                }

                transactionDataModel.ReturnCode = 0;
                transactionDataModel.Message = "Profile Saved Successfully.";
                transactionDataModel.Data = null;  // Empty array
                return Ok(transactionDataModel);

                //return Ok(await _loginService.UpdateLoginProfile(updateProfile));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "UserControl-UpdateLoginProfile");
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] LoginPOSChangePwdInputModel changePwd)
        {
            try
            {
                TransactionDataModel<LoginPOSModel> transactionDataModel = new TransactionDataModel<LoginPOSModel>();

                var Result = await _loginService.ChangePassword(changePwd);
                if (Result < 0)
                {
                    transactionDataModel.ReturnCode = Result;
                    transactionDataModel.Message = "Error occur while saving.";
                    return Ok(transactionDataModel);
                }

                transactionDataModel.ReturnCode = 0;
                transactionDataModel.Message = "Password Changed Successfully.";
                transactionDataModel.Data = null;  // Empty array
                return Ok(transactionDataModel);
                //return Ok(await _loginService.ChangePassword(changePwd));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "UserControl-ChangePassword");
                return StatusCode(500, ex.Message);
            }

        }
    }
}
