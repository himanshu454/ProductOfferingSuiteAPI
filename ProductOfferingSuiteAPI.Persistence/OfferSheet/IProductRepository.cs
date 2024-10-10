using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DesignComplexityAPI.Domain.Global;
//using DesignComplexityAPI.Domain.ItemAttributes;
using ProductOfferingSuiteAPI.Domain.OfferSheet;

namespace ProductOfferingSuiteAPI.Persistence.OfferSheet
{
    public interface IProductRepository
    {
        Task<List<ProductColorModel>> GetProductColor();
        Task<List<ProductMaterialModel>> GetProductMaterial();
        Task<List<ProductVendorModel>> GetProductVendor(int UserID);
        Task<List<ProductCategoryModel>> GetProductCategory();
        Task<List<GetProductOutput>> GetProduct(GetProductInput getProduct);
        Task<List<GetProductOutputExcel>> GetProductExcel(int UserID);
        Task<int> AddProduct(AddProductModel AddProd);
        Task<int> EditProduct(EditProductModel EditProd);
        Task<int> DeleteProduct(DeleteProductModel DeleteProd);
    }
}
