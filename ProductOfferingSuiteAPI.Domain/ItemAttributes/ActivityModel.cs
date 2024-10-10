using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOfferingSuiteAPI.Domain.ItemAttributes
{
    public class ActivityModel
    {
        public int ActivityID { get; set; }
        public string ActivityName { get; set; }
    }

    public class LinkingTypeModel
    {
        public int LinkingTypeID { get; set; }
        public string LinkingTypeName { get; set; }
    }
}
