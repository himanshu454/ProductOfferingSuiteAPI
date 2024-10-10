using DesignComplexityAPI.APIUtility.Controllers;
using DesignComplexityAPI.Domain.ItemAttributes;
using DesignComplexityAPI.Services.ItemDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DesignComplexityAPI.Controllers
{
    public class DesignController : ApiBaseController<DesignController>
    {
        private readonly IDesignService _designService;

        public DesignController(IDesignService designService)
        {
            _designService = designService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDesignGroup()
        {
            try
            {
                return Ok(await _designService.GetDesignGroup());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Design-GetDesignGroup");
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> GetDesignListDetails([FromBody] DesignListInputModel DesignDtls)
        {
            try
            {
                return Ok(await _designService.GetDesignListDetails(DesignDtls));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Design-GetDesignDetails");
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDesignDetails(int id)
        {
            try
            {
                return Ok(await _designService.GetDesignDetails(id));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Design-GetDesignDetails");
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> FillActivity()
        {
            try
            {
                return Ok(await _designService.FillActivity());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Design-FillActivity");
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> FillLinkingType()
        {
            try
            {
                return Ok(await _designService.FillLinking());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Design-FillLinkingType");
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateDesignDetails([FromBody] DesignModel designModel)
        {
            try
            {
                return Ok(await _designService.UpdateDesignDetails(designModel));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Design-UpdateDesignDetails");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDesignFindingType()
        {
            try
            {
                return Ok(await _designService.GetDesignFindingType());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Design-GetDesignFindingType");
                return StatusCode(500, ex.Message);
            }

        }

    }
}
