using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DesignComplexityAPI.Domain.ItemAttributes;
using ProductOfferingSuiteAPI.Domain.Global;
using ProductOfferingSuiteAPI.Domain.OfferSheet;
using ProductOfferingSuiteAPI.Persistence.OfferSheet;



namespace DesignComplexityAPI.Services.OfferSheet
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<TransactionDataModel<List<ProductColorModel>>> GetProductColor()
        {
            TransactionDataModel<List<ProductColorModel>> GetProductCol = new TransactionDataModel<List<ProductColorModel>>();
            GetProductCol.Data = await _productRepository.GetProductColor();
            GetProductCol.ReturnCode = 0;
            GetProductCol.Message = "Data Shown Properly";
            return GetProductCol;
        }

        public async Task<TransactionDataModel<List<ProductMaterialModel>>> GetProductMaterial()
        {
            TransactionDataModel<List<ProductMaterialModel>> GetProductMat = new TransactionDataModel<List<ProductMaterialModel>>();
            GetProductMat.Data = await _productRepository.GetProductMaterial();
            GetProductMat.ReturnCode = 0;
            GetProductMat.Message = "Data Shown Properly";
            return GetProductMat;
        }

        public async Task<TransactionDataModel<List<ProductVendorModel>>> GetProductVendor(int UserID)
        {
            TransactionDataModel<List<ProductVendorModel>> GetProductVen = new TransactionDataModel<List<ProductVendorModel>>();
            GetProductVen.Data = await _productRepository.GetProductVendor(UserID);
            GetProductVen.ReturnCode = 0;
            GetProductVen.Message = "Data Shown Properly";
            return GetProductVen;
        }

        public async Task<TransactionDataModel<List<ProductCategoryModel>>> GetProductCategory()
        {
            TransactionDataModel<List<ProductCategoryModel>> GetProductCat = new TransactionDataModel<List<ProductCategoryModel>>();
            GetProductCat.Data = await _productRepository.GetProductCategory();
            GetProductCat.ReturnCode = 0;
            GetProductCat.Message = "Data Shown Properly";
            return GetProductCat;
        }

       
       public async Task<TransactionDataModel<List<GetProductOutput>>> GetProduct(GetProductInput getProduct)
        {
            TransactionDataModel<List<GetProductOutput>> GetProductCol = new TransactionDataModel<List<GetProductOutput>>();
            GetProductCol.Data = await _productRepository.GetProduct(getProduct);
            GetProductCol.ReturnCode = 0;
            GetProductCol.Message = "Data Shown Properly";
            return GetProductCol;
        }

        public async Task<TransactionDataModel<List<GetProductOutputExcel>>> GetProductExcel(int UserID)
        {
            TransactionDataModel<List<GetProductOutputExcel>> GetProductCol = new TransactionDataModel<List<GetProductOutputExcel>>();
            GetProductCol.Data = await _productRepository.GetProductExcel(UserID);
            GetProductCol.ReturnCode = 0;
            GetProductCol.Message = "Data Shown Properly";
            return GetProductCol;
        }

        public async Task<int> AddProduct(AddProductModel AddProd)
        {
            return await _productRepository.AddProduct(AddProd);
        }
        

        public async Task<int> EditProduct(EditProductModel EditProd)
        {
            return await _productRepository.EditProduct(EditProd);
        }
        public async Task<int> DeleteProduct(DeleteProductModel DeleteProd)
        {
            return await _productRepository.DeleteProduct(DeleteProd);
        }
    }
}
