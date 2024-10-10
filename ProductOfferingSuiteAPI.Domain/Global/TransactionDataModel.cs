using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOfferingSuiteAPI.Domain.Global
{
    public class TransactionDataModel<T>
    {
        public int ReturnCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public string Token { get; set; }

    }
}
