using DesignComplexityAPI.APIUtility.Controllers;
using DesignComplexityAPI.Services.ItemDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DesignComplexityAPI.Controllers
{

    public class ArticleTypeController : ApiBaseController<ArticleTypeController>
    {
        private readonly IArticleTypeService _articleTypeService;

        public ArticleTypeController(IArticleTypeService articleTypeService)
        {
            _articleTypeService = articleTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetArticleType()
        {
            try
            {
                return Ok(await _articleTypeService.GetArticleType());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ArticleType-GetArticleType");
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> FillItemGroup()
        {
            try
            {
                return Ok(await _articleTypeService.FillItemGroup());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "ArticleType-FillItemGroup");
                return StatusCode(500, ex.Message);
            }

        }
    }
}
