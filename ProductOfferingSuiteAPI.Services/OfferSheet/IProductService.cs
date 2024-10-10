//using DesignComplexityAPI.Domain.ItemAttributes;
//using DesignComplexityAPI.Domain.Login;
using ProductOfferingSuiteAPI.Domain.Global;
using ProductOfferingSuiteAPI.Domain.OfferSheet;


namespace DesignComplexityAPI.Services.OfferSheet
{
    public interface IProductService
    {
        Task<TransactionDataModel<List<ProductColorModel>>> GetProductColor();
        Task<TransactionDataModel<List<ProductMaterialModel>>> GetProductMaterial();
        Task<TransactionDataModel<List<ProductVendorModel>>> GetProductVendor(int UserID);
        //Task<TransactionDataModel<List<ProductVendorModel>>> GetProductVendor1(int UserID);
        Task<TransactionDataModel<List<ProductCategoryModel>>> GetProductCategory();
        Task<TransactionDataModel<List<GetProductOutput>>> GetProduct(GetProductInput getProduct);

        Task<TransactionDataModel<List<GetProductOutputExcel>>> GetProductExcel(int UserID);
        Task<int> AddProduct(AddProductModel AddProd);
        
        Task<int> EditProduct(EditProductModel EditProd);
        Task<int> DeleteProduct(DeleteProductModel DeleteProd);
    }
}
