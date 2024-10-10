using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOfferingSuiteAPI.Domain.ItemAttributes
{
    public class DesignGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DesignFindingTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DesignListInputModel
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int DesignGrpID { get; set; }
        public int ArticleTypeId { get; set; }
        public string DesignNo { get; set; }
        public string TempNo { get; set; }
        public string PONo { get; set; }
    }

    public class DesignListOutputModel
    {
        public int DM_ID { get; set; }
        public string DesignNo { get; set; }
        public DateTime CreationDate { get; set; }
        public string ArticleType { get; set; }
        public string TempNo { get; set; }
        public string ConstructionType { get; set; }
        public double WaxWt { get; set; }
        public double ModelWt { get; set; }
        public string Size { get; set; }
        public double SurfaceArea { get; set; }
        public string JBackFitting { get; set; }
    }

    public class DesignStuddingModel
    {
        public int DD_Id { get; set; }
        public string Shape { get; set; }
        public string Size { get; set; }
        public string Cut { get; set; }
        public string SettingType { get; set; }
        public int Qty { get; set; }
        public string IsDiamond { get; set; }
        public string MainStone { get; set; }
        public int ActivityID { get; set; }
        public string ActivityName { get; set; }
    }

    public class DesignPartModel
    {
        public int DPD_Id { get; set; }
        public string PartDesignNo { get; set; }
        public int Qty { get; set; }
        public string ArticleType { get; set; }
        public int FindingTypeID { get; set; }
        public string FindingType { get; set; }
        public int AssemblyCount { get; set; }
        public int LinkingTypeID { get; set; }
        public string LinkingType { get; set; }
    }

    public class DesignModel
    {
        public int DM_ID { get; set; }
        public string DesignNo { get; set; }
        public DateTime CreationDate { get; set; }
        public string ArticleType { get; set; }
        public string TempNo { get; set; }
        public string ConstructionType { get; set; }
        public double WaxWt { get; set; }
        public double ModelWt { get; set; }
        public string Size { get; set; }
        public double SurfaceArea { get; set; }
        public string JBackFitting { get; set; }
        public string ImagePath { get; set; }
        public double ArticleAvgSurfaceArea { get; set; }
        public string JBackPolish { get; set; }
        public string DhagaPolish { get; set; }
        public int JBackPolishCount { get; set; }
        public int DhagaPolishCount { get; set; }
        public List<DesignStuddingModel> DesignStudding { get; set; }
        public List<DesignPartModel> DesignPart { get; set; }
    }
}
