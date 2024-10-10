using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductOfferingSuiteAPI.Domain.OfferSheet
{

    public class ProductColorModel
    {
        public string ColorCode { get; set; }
        public string ColorName { get; set; }

    }
    public class ProductMaterialModel
    {
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }

    }
    public class ProductVendorModel
    {
        public string Code { get; set; }
        public string VendorName { get; set; }

    }

    public class ProductCategoryModel
    {
        public string Code { get; set; }
        public string Category { get; set; }

    }


    public class GetProductInput

    {

        public int UserId { get; set; }
        public string VendorID { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }


    public class GetProductOutput
    {
        public long ID { get; set; }
        public string ProductName { get; set; }
        public string Color { get; set; }
        public string ColorID { get; set; }
        public string Material { get; set; }
        public string MaterialID { get; set; }
        public string CategoryID { get; set; }
        public string ProductDimension { get; set; }
        public long ItemPerBox { get; set; }
        public string ProductShippingDimension { get; set; }
        public long OrderQuantity { get; set; }
        public decimal Rate { get; set; }
        public string Unit { get; set; }
        public string VendorID { get; set; }
        public string ImagePath1 { get; set; }
        public string ImagePath2 { get; set; }
        public string ImagePath3 { get; set; }
        public string ImagePath4 { get; set; }
        public decimal DutyPercentage { get; set; }

    }

    public class AddProductModel
    {
        public int UserId { get; set; }
        public string ProductName { get; set; }
        public string ColorID { get; set; }
        public string MaterialID { get; set; }
        public string CategoryID { get; set; }
        public float ProductDimensionLength { get; set; }
        public float ProductDimensionBreadth { get; set; }
        public float ProductDimensionHeight { get; set; }
        public int ItemPerBox { get; set; }
        public float ProductShippingDimensionLength { get; set; }
        public float ProductShippingDimensionBreadth { get; set; }
        public float ProductShippingDimensionHeight { get; set; }
        public int OrderQuantity { get; set; }
        public float Rate { get; set; }
        public string Unit { get; set; }
        public string VendorID { get; set; }
        public string ImagePath1 { get; set; }
        public string ImagePath2 { get; set; }
        public string ImagePath3 { get; set; }
        public string ImagePath4 { get; set; }
        public decimal DutyPercentage { get; set; }

    }

    public class EditProductModel
    {
        public int UserId { get; set; }
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string ColorID { get; set; }
        public string MaterialID { get; set; }
        public string CategoryID { get; set; }
        //public string ProductDimension { get; set; }
        public float ProductDimensionLength { get; set; }
        public float ProductDimensionBreadth { get; set; }
        public float ProductDimensionHeight { get; set; }
        public int ItemPerBox { get; set; }
        //public string ProductShippingDimension { get; set; }
        public float ProductShippingDimensionLength { get; set; }
        public float ProductShippingDimensionBreadth { get; set; }
        public float ProductShippingDimensionHeight { get; set; }
        public int OrderQuantity { get; set; }
        public float Rate { get; set; }
        public string Unit { get; set; }
        public string VendorID { get; set; }
        public string ImagePath1 { get; set; }
        public string ImagePath2 { get; set; }
        public string ImagePath3 { get; set; }
        public string ImagePath4 { get; set; }
        public decimal DutyPercentage { get; set; }

    }

    public class DeleteProductModel
    {
        public int UserId { get; set; }
        public int ID { get; set; }
    }

    //public class GetProductInputExcel
    //{
    //    public int UserId { get; set; }
    //}

    public class GetProductOutputExcel

    {
        public string ProductImage1 { get; set; }
        public string ProductImage2 { get; set; }
        public string ProductImage3 { get; set; }
        public string ProductImage4 { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public string DimensionCM { get; set; }
        public string Packages { get; set; }
        public long Itemperbox { get; set; }
        public float ShippingLength { get; set; }
        public float ShippingBreadth { get; set; }
        public float ShippingHeight { get; set; }
        public long OrderQuantity { get; set; }
        public decimal RateRMB { get; set; }
        public decimal RateUSD { get; set; }
        public decimal ItemcodeCreationCharges { get; set; }
        public decimal CNmargin17Perc { get; set; }
        public decimal FreightSEA { get; set; }
        public decimal LandpriceUS { get; set; }
        public decimal LandingIncludingDuty { get; set; }
        public decimal TSPUSD { get; set; }
        public decimal AMSUS { get; set; }
        public decimal ShopLCMargin { get; set; }
        public string USimportHScode { get; set; }
        public string USimportdutyPerc { get; set; }
        public decimal LandedpriceGBP { get; set; }
        public decimal LandingIncludingDutyGBP { get; set; }
        public decimal TSPGBP { get; set; }
        public decimal AMSUK { get; set; }
        public decimal TJCMarginGBP { get; set; }
        public string TJCHSCode { get; set; }
        public string UKimportdutyPerc { get; set; }
        public decimal LandedpriceEUR { get; set; }
        public string OfferDate { get; set; }
        public string ShipType { get; set; }
        public string DeliveryTime { get; set; }
        public string CategoryID { get; set; }
    }
}
