using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOfferingSuiteAPI.Domain.ItemAttributes
{
    public class ArticleTypeModel
    {
        public int DCM_Id { get; set; }
        public string DCM_Name { get; set; }
        public bool DCM_IsFinding { get; set; }
        public string DCM_DNCode { get; set; }
        public double DCM_SurfaceArea { get; set; }

    }

    public class ItemGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
