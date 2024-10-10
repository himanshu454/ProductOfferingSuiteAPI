using Microsoft.AspNetCore.Mvc;
using DesignComplexityAPI.Services.OfferSheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using ProductOfferingSuiteAPI.Domain.OfferSheet;
using ProductOfferingSuiteAPI.Domain.Login;
using ProductOfferingSuiteAPI.Domain.Global;
using ProductOfferingSuiteAPI.APIUtility.Controllers;


namespace ProductOfferingSuiteAPI.Controllers
{
    [AllowAnonymous]
    public class ProductController : ApiBaseController<ProductController>
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductColor()
        {
            try
            {
                return Ok(await _productService.GetProductColor());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Product-GetProductColor");
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetProductMaterial()
        {
            try
            {
                return Ok(await _productService.GetProductMaterial());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Product-GetProductMaterial");
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetProductVendor(int UserID)
        {
            try
            {
                return Ok(await _productService.GetProductVendor(UserID));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Product-GetProductVendor");
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetProductCategory()
        {
            try
            {
                return Ok(await _productService.GetProductCategory());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Product-GetProductCategory");
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> GetProduct([FromBody] GetProductInput getProduct)
        {
            try
            {
                return Ok(await _productService.GetProduct(getProduct));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Product-GetProduct");
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetProductExcel(int UserId)
        {
            try
            {
                return Ok(await _productService.GetProductExcel(UserId));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Product-GetProductExcelData");
                return StatusCode(500, ex.Message);
            }

        }

        //[HttpPost]        
        //public async Task<IActionResult> AddProduct([FromBody] AddProductModel AddProd)
        //{
        //    try
        //    {
        //        return Ok(await _productService.AddProduct(AddProd));
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex, "Product-AddProduct");
        //        return StatusCode(500, ex.Message);
        //    }

        //}

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductModel AddProd)
        {
            try
            {
                TransactionDataModel<LoginPOSModel> transactionDataModel = new TransactionDataModel<LoginPOSModel>();

                //if (AddProd.UserId == 0)
                //{
                //    transactionDataModel.ReturnCode = 1;
                //    transactionDataModel.Message = "UserID cannot be 0.";
                //    return Ok(transactionDataModel);
                //}

                var Result = await _productService.AddProduct(AddProd);
                if (Result < 0)
                {
                    transactionDataModel.ReturnCode = Result;
                    transactionDataModel.Message = "Error occur while saving.";
                    return Ok(transactionDataModel);
                }

                transactionDataModel.ReturnCode = 0;
                transactionDataModel.Message = "Data Save Successfully.";
                transactionDataModel.Data = null;  // Empty array
                return Ok(transactionDataModel);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Product-AddProduct");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditProduct([FromBody] EditProductModel EditProd)
        {
            try
            {
                TransactionDataModel<LoginPOSModel> transactionDataModel = new TransactionDataModel<LoginPOSModel>();

                //if (AddProd.UserId == 0)
                //{
                //    transactionDataModel.ReturnCode = 1;
                //    transactionDataModel.Message = "UserID cannot be 0.";
                //    return Ok(transactionDataModel);
                //}

                var Result = await _productService.EditProduct(EditProd);
                if (Result < 0)
                {
                    transactionDataModel.ReturnCode = Result;
                    transactionDataModel.Message = "Error occur while editing.";
                    return Ok(transactionDataModel);
                }

                transactionDataModel.ReturnCode = 0;
                transactionDataModel.Message = "Data updated Successfully.";
                transactionDataModel.Data = null;
                return Ok(transactionDataModel);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Product-EditProduct");
                return StatusCode(500, ex.Message);
            }

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductModel DeleteProd)
        {
            //try
            //{
            //    return Ok(await _productService.DeleteProduct(DeleteProd));
            //}
            //catch (Exception ex)
            //{
            //    Logger.LogError(ex, "Product-DeleteProduct");
            //    return StatusCode(500, ex.Message);
            //}
            try
            {
                TransactionDataModel<LoginPOSModel> transactionDataModel = new TransactionDataModel<LoginPOSModel>();

                //if (AddProd.UserId == 0)
                //{
                //    transactionDataModel.ReturnCode = 1;
                //    transactionDataModel.Message = "UserID cannot be 0.";
                //    return Ok(transactionDataModel);
                //}

                var Result = await _productService.DeleteProduct(DeleteProd);
                if (Result < 0)
                {
                    transactionDataModel.ReturnCode = Result;
                    transactionDataModel.Message = "Error occur while deleting.";
                    return Ok(transactionDataModel);
                }

                transactionDataModel.ReturnCode = 0;
                transactionDataModel.Message = "Data deleted Successfully.";
                transactionDataModel.Data = null;
                return Ok(transactionDataModel);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Product-DeleteProduct");
                return StatusCode(500, ex.Message);
            }

        }

    }
}
