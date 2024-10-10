using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
//using DesignComplexityAPI.Domain.Global;
//using DesignComplexityAPI.Domain.ItemAttributes;
//using DesignComplexityAPI.Domain.Login;
using ProductOfferingSuiteAPI.Domain.OfferSheet;
using ProductOfferingSuiteAPI.Persistence.Configuration;


namespace ProductOfferingSuiteAPI.Persistence.OfferSheet
{
    public class ProductRepository : IProductRepository
    {
        private readonly ISqlConnectionProvider _SQLconnectionProvider;
        public ProductRepository(ISqlConnectionProvider sqlConnectionProvider)
        {
            _SQLconnectionProvider = sqlConnectionProvider;
        }

        public async Task<List<ProductColorModel>> GetProductColor()
        {
            var SPName = "POS_GetProductColor";

            using (var Conn = _SQLconnectionProvider.GetConnection)
            {
                var results = await Conn.QueryAsync<ProductColorModel>(SPName, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }
        }

        public async Task<List<ProductMaterialModel>> GetProductMaterial()
        {
            var SPName = "POS_GetProductMaterial";

            using (var Conn = _SQLconnectionProvider.GetConnection)
            {
                var results = await Conn.QueryAsync<ProductMaterialModel>(SPName, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }
        }

        public async Task<List<ProductVendorModel>> GetProductVendor(int UserID)
        {
            var SPName = "POS_GetVendorDetail";
            var Parameters = new DynamicParameters();
            Parameters.Add("@UserID", UserID, DbType.Int32, ParameterDirection.Input);

            using (var Conn = _SQLconnectionProvider.GetConnection)
            {
                var results = await Conn.QueryAsync<ProductVendorModel>(SPName, Parameters, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }
        }

        public async Task<List<ProductCategoryModel>> GetProductCategory()
        {
            var SPName = "POS_GetCategory";

            using (var Conn = _SQLconnectionProvider.GetConnection)
            {
                var results = await Conn.QueryAsync<ProductCategoryModel>(SPName, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }
        }

        public async Task<List<GetProductOutput>> GetProduct(GetProductInput getProduct)
        {
            var SPName = "POS_GetProduct";

            var Parameters = new DynamicParameters();
            Parameters.Add("@UserID", getProduct.UserId, DbType.Int32, ParameterDirection.Input);
            Parameters.Add("@StartDate", getProduct.StartDate, DbType.String, ParameterDirection.Input);
            Parameters.Add("@EndDate", getProduct.EndDate, DbType.String, ParameterDirection.Input);
            Parameters.Add("@VendorID", getProduct.VendorID, DbType.String, ParameterDirection.Input);


            using (var connection = _SQLconnectionProvider.GetConnection)
            {
                var results = await connection.QueryAsync<GetProductOutput>(SPName, Parameters, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }
        }

        public async Task<List<GetProductOutputExcel>> GetProductExcel(int UserID)
        {
            var SPName = "POS_ProductExcelData";

            var Parameters = new DynamicParameters();
            Parameters.Add("@UserID", UserID, DbType.Int32, ParameterDirection.Input);

            using (var connection = _SQLconnectionProvider.GetConnection)
            {
                var results = await connection.QueryAsync<GetProductOutputExcel>(SPName, Parameters, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }
        }

        public async Task<int> AddProduct(AddProductModel AddProd)
        {
            int RetVal = 0;
            var SPName = "POS_AddProduct";

            var Parameters = new DynamicParameters();
            Parameters.Add("@UserID", AddProd.UserId, DbType.Int32, ParameterDirection.Input);
            Parameters.Add("@ProductName", AddProd.ProductName, DbType.String, ParameterDirection.Input);
            Parameters.Add("@ColorID", AddProd.ColorID, DbType.String, ParameterDirection.Input);
            Parameters.Add("@MaterialID", AddProd.MaterialID, DbType.String, ParameterDirection.Input);
            Parameters.Add("@CategoryID", AddProd.CategoryID, DbType.String, ParameterDirection.Input);
            Parameters.Add("@ProductDimensionLength", AddProd.ProductDimensionLength, DbType.Decimal, ParameterDirection.Input);
            Parameters.Add("@ProductDimensionBreadth", AddProd.ProductDimensionBreadth, DbType.Decimal, ParameterDirection.Input);
            Parameters.Add("@ProductDimensionHeight", AddProd.ProductDimensionHeight, DbType.Decimal, ParameterDirection.Input);
            Parameters.Add("@ItemPerBox", AddProd.ItemPerBox, DbType.Int32, ParameterDirection.Input);
            Parameters.Add("@ProductShippingDimensionLength", AddProd.ProductShippingDimensionLength, DbType.Decimal, ParameterDirection.Input);
            Parameters.Add("@ProductShippingDimensionBreadth", AddProd.ProductShippingDimensionBreadth, DbType.Decimal, ParameterDirection.Input);
            Parameters.Add("@ProductShippingDimensionHeight", AddProd.ProductShippingDimensionHeight, DbType.Decimal, ParameterDirection.Input);
            Parameters.Add("@OrderQuantity", AddProd.OrderQuantity, DbType.Int32, ParameterDirection.Input);
            Parameters.Add("@Rate", AddProd.Rate, DbType.Decimal, ParameterDirection.Input);
            Parameters.Add("@Unit", AddProd.Unit, DbType.String, ParameterDirection.Input);
            Parameters.Add("@VendorID", AddProd.VendorID, DbType.String, ParameterDirection.Input);
            Parameters.Add("@ImagePath1", AddProd.ImagePath1, DbType.String, ParameterDirection.Input);
            Parameters.Add("@ImagePath2", AddProd.ImagePath2, DbType.String, ParameterDirection.Input);
            Parameters.Add("@ImagePath3", AddProd.ImagePath3, DbType.String, ParameterDirection.Input);
            Parameters.Add("@ImagePath4", AddProd.ImagePath4, DbType.String, ParameterDirection.Input);
            Parameters.Add("@DutyPercentage", AddProd.DutyPercentage, DbType.Decimal, ParameterDirection.Input);
            Parameters.Add("@RetVal", RetVal, DbType.String, ParameterDirection.ReturnValue);

            using (var connection = _SQLconnectionProvider.GetConnection)
            {
                var result = await connection.QueryAsync<AddProductModel>(SPName, Parameters, commandType: CommandType.StoredProcedure);
                RetVal = Parameters.Get<int>("@RetVal");
            }
            return RetVal;
        }

        public async Task<int> EditProduct(EditProductModel EditProd)
        {
            int RetVal = 0;
            var SPName = "POS_EditProduct";

            var Parameters = new DynamicParameters();
            Parameters.Add("@UserID", EditProd.UserId, DbType.Int32, ParameterDirection.Input);
            Parameters.Add("@ID", EditProd.ID, DbType.Int32, ParameterDirection.Input);
            Parameters.Add("@ProductName", EditProd.ProductName, DbType.String, ParameterDirection.Input);
            Parameters.Add("@ColorID", EditProd.ColorID, DbType.String, ParameterDirection.Input);
            Parameters.Add("@MaterialID", EditProd.MaterialID, DbType.String, ParameterDirection.Input);
            Parameters.Add("@CategoryID", EditProd.CategoryID, DbType.String, ParameterDirection.Input);
            //Parameters.Add("@ProductDimension", EditProd.ProductDimension, DbType.String, ParameterDirection.Input);
            Parameters.Add("@ProductDimensionLength", EditProd.ProductDimensionLength, DbType.String, ParameterDirection.Input);
            Parameters.Add("@ProductDimensionBreadth", EditProd.ProductDimensionBreadth, DbType.String, ParameterDirection.Input);
            Parameters.Add("@ProductDimensionHeight", EditProd.ProductDimensionHeight, DbType.String, ParameterDirection.Input);

            Parameters.Add("@ItemPerBox", EditProd.ItemPerBox, DbType.Int32, ParameterDirection.Input);
            //Parameters.Add("@ProductShippingDimension", EditProd.ProductShippingDimension, DbType.String, ParameterDirection.Input);
            Parameters.Add("@ProductShippingDimensionLength", EditProd.ProductShippingDimensionLength, DbType.String, ParameterDirection.Input);
            Parameters.Add("@ProductShippingDimensionBreadth", EditProd.ProductShippingDimensionBreadth, DbType.String, ParameterDirection.Input);
            Parameters.Add("@ProductShippingDimensionHeight", EditProd.ProductShippingDimensionHeight, DbType.String, ParameterDirection.Input);

            Parameters.Add("@OrderQuantity", EditProd.OrderQuantity, DbType.Int32, ParameterDirection.Input);
            Parameters.Add("@Rate", EditProd.Rate, DbType.Decimal, ParameterDirection.Input);
            Parameters.Add("@Unit", EditProd.Unit, DbType.String, ParameterDirection.Input);
            Parameters.Add("@VendorID", EditProd.VendorID, DbType.String, ParameterDirection.Input);
            Parameters.Add("@ImagePath1", EditProd.ImagePath1, DbType.String, ParameterDirection.Input);
            Parameters.Add("@ImagePath2", EditProd.ImagePath2, DbType.String, ParameterDirection.Input);
            Parameters.Add("@ImagePath3", EditProd.ImagePath3, DbType.String, ParameterDirection.Input);
            Parameters.Add("@ImagePath4", EditProd.ImagePath4, DbType.String, ParameterDirection.Input);
            Parameters.Add("@DutyPercentage", EditProd.DutyPercentage, DbType.Decimal, ParameterDirection.Input);
            Parameters.Add("@RetVal", RetVal, DbType.String, ParameterDirection.ReturnValue);

            using (var connection = _SQLconnectionProvider.GetConnection)
            {
                var result = await connection.QueryAsync<EditProductModel>(SPName, Parameters, commandType: CommandType.StoredProcedure);
                RetVal = Parameters.Get<int>("@RetVal");
            }
            return RetVal;
        }

        public async Task<int> DeleteProduct(DeleteProductModel DeleteProd)
        {
            int RetVal = 0;
            var SPName = "POS_DeleteProduct";

            var Parameters = new DynamicParameters();
            Parameters.Add("@UserID", DeleteProd.UserId, DbType.Int32, ParameterDirection.Input);
            Parameters.Add("@ID", DeleteProd.ID, DbType.Int32, ParameterDirection.Input);
            Parameters.Add("@RetVal", RetVal, DbType.String, ParameterDirection.ReturnValue);

            using (var connection = _SQLconnectionProvider.GetConnection)
            {
                var result = await connection.QueryAsync<DeleteProductModel>(SPName, Parameters, commandType: CommandType.StoredProcedure);
                RetVal = Parameters.Get<int>("@RetVal");
            }
            return RetVal;
        }
    }
}
