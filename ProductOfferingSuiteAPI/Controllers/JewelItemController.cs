using DesignComplexityAPI.APIUtility.Controllers;
using DesignComplexityAPI.Domain.ItemAttributes;
using DesignComplexityAPI.Services.ItemDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DesignComplexityAPI.Controllers
{
    public class JewelItemController : ApiBaseController<JewelItemController>
    {
        private readonly IJewelryItemService _jewelryItemService;

        public JewelItemController(IJewelryItemService jewelryItemService)
        {
            _jewelryItemService = jewelryItemService;
        }

        [HttpPost]
        public async Task<IActionResult> GetJewelItemList([FromBody] JewelryListInputModel JwlDtls)
        {
            try
            {
                return Ok(await _jewelryItemService.GetJewelryItemDetails(JwlDtls));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "JewelItem-GetJewelItemList");
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> FillPO()
        {
            try
            {
                return Ok(await _jewelryItemService.FillPO());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "JewelItem-FillPO");
                return StatusCode(500, ex.Message);
            }

        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJewelryDetails(int id)
        {
            try
            {
                return Ok(await _jewelryItemService.GetJewelryDetails(id));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "JewelItem-GetJewelryDetails");
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CalculateComplexity([FromBody] List<int> ItemCode)
        {
            try
            {
                return Ok(await _jewelryItemService.CalculateComplexity(ItemCode));                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "JewelItem-CalculateComplexity");
                return StatusCode(500, ex.Message);
            }

        }

    }
}
