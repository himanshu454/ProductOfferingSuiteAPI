using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProductOfferingSuiteAPI.Domain.ItemAttributes
{
    public class JewelryItemModel
    {

        public int ItemID { get; set; }
        public int ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ArticleType { get; set; }
        public string ItemGroup { get; set; }
        public string DesigNo { get; set; }
        public string Metal { get; set; }
        public string ItemSize { get; set; }
        public string FinishType { get; set; }
        public double SettingComplexity { get; set; }
        public double CFPComplexity { get; set; }
        public double TotalComplexity { get; set; }
        public string ImagePath { get; set; }

    }

    public class JewelryListInputModel
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int ItemGrpID { get; set; }
        public int ArticleTypeId { get; set; }
        public int MetalID { get; set; }
        public string ItemCode { get; set; }
        public string DesignNo { get; set; }
        public string PONo { get; set; }

    }

    public class POModel
    {
        public string PO { get; set; }
    }

    public class JwlStuddModel
    {
        public int ItemID { get; set; }
        public string StoneType { get; set; }
        public string Shape { get; set; }
        public string Size { get; set; }
        public string Cut { get; set; }
        public string Setting { get; set; }
        public string MainStone { get; set; }
        public string StoneName { get; set; }
        public string StoneItem { get; set; }
        public int Qty { get; set; }
        public double Wt { get; set; }
        public double MinWt { get; set; }
        public string IsWaxSet { get; set; }
        public string StoneHardSoft { get; set; }
        public double SettingSizeTime { get; set; }
        public double ShapeFactor { get; set; }
        public double SettingTime { get; set; }


    }

    public class JwlPartModel
    {
        public int ItemID { get; set; }
        public string PartNo { get; set; }
        public string Metal { get; set; }
        public double RawWt { get; set; }
        public int PartQty { get; set; }
        public double FinishWt { get; set; }
        public string LinkingType { get; set; }
        public int LinkingCount { get; set; }
        public double AssemblyTime { get; set; }
        public string FindingType { get; set; }
        public double FindingTime { get; set; }
        public double JbackTime { get; set; }
        public double TotalAssemblyTime { get; set; }

    }

    public class JewleryModel
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int ItemCode { get; set; }
        public string Details { get; set; }
        public string ItemGroup { get; set; }
        public int DM_Id { get; set; }
        public string DesignNo { get; set; }
        public string Metal { get; set; }
        public string ArticleType { get; set; }
        public double Complexity { get; set; }
        public string FinishType { get; set; }
        public string Size { get; set; }
        public double FinishWt { get; set; }
        public double RawWt { get; set; }
        public string ImgPath { get; set; }
        public double WaxTime { get; set; }
        public double CastingTime { get; set; }
        public double MassFinishingTime { get; set; }
        public double FilingTime { get; set; }
        public double PolishTime { get; set; }
        public double TotalPolishTime { get; set; }
        public double PlatingTime { get; set; }
        public double AssemblyTime { get; set; }
        public double SettingTime { get; set; }
        public List<JwlStuddModel> jwlStuddModels { get; set; }
        public List<JwlPartModel> jwlPartModels { get; set; }
    }

    public class ComplexityModel
    {
        public string ItemCode { get; set; }
        public string ErrorDesc { get; set; }

    }
}
