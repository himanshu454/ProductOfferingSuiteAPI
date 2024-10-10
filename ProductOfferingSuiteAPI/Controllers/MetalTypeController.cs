using DesignComplexityAPI.APIUtility.Controllers;
using DesignComplexityAPI.Services.ItemDetails;
using Microsoft.AspNetCore.Mvc;

namespace DesignComplexityAPI.Controllers
{
    public class MetalTypeController : ApiBaseController<MetalTypeController>
    {
        private readonly IMetalTypeService _metalTypeService;

        public MetalTypeController(IMetalTypeService metalTypeService)
        {
            _metalTypeService = metalTypeService;
        }

        [HttpGet]
        public async Task <IActionResult> GetMetaltype()
        {
            try
            {
                return Ok(await _metalTypeService.GetMetalType());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "MetalType-GetMetalType");
                return StatusCode(500,ex.Message);
            }
            
        }
    }
}
