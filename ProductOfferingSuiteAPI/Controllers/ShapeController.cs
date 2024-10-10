using System.Runtime.CompilerServices;
using DesignComplexityAPI.APIUtility.Controllers;
using DesignComplexityAPI.Services.ItemDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DesignComplexityAPI.Controllers
{
    public class ShapeController : ApiBaseController<ShapeController>
    {
        private readonly IShapeService _shapeService;

        public ShapeController(IShapeService shapeService)
        {
            _shapeService = shapeService;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetShape()
        //{
        //    try
        //    {
        //        return Ok(await _shapeService.GetShape());
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex, "Shape-GetShape");
        //        return StatusCode(500, "Error");
        //    }            
        //}
    }
}
