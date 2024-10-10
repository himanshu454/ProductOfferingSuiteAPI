using DesignComplexityAPI.APIUtility.Controllers;
using DesignComplexityAPI.Services.ItemDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DesignComplexityAPI.Controllers
{
    public class SettingTypeController : ApiBaseController<SettingTypeController>
    {
        private readonly ISettingTypeService _settingTypeService;

        public SettingTypeController(ISettingTypeService settingTypeService)
        {
            this._settingTypeService = settingTypeService;
        }

        [HttpGet]        
        public async Task<IActionResult> GetSettingType()
        {
            try
            {
                return Ok(await _settingTypeService.GetSettingType());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "SettingType-GetSettingType");
                return StatusCode(500, ex.Message);
            }

        }
    }
}
