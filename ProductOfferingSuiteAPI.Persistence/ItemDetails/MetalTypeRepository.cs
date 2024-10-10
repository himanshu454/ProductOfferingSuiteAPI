using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ProductOfferingSuiteAPI.Domain.ItemAttributes;
using ProductOfferingSuiteAPI.Persistence.Configuration;

namespace ProductOfferingSuiteAPI.Persistence.ItemDetails
{
    public class MetalTypeRepository : IMetalTypeRepository
    {
        private readonly ISqlConnectionProvider _sqlconnectionProvider;

        public MetalTypeRepository(ISqlConnectionProvider sqlconnectionProvider)
        {
            _sqlconnectionProvider = sqlconnectionProvider;
        }

        public async Task<List<MetalTypeModel>> GetMetalTypes()
        {
            var SPName = "CPLX_FillMetalTypeList";

            using (var Conn = _sqlconnectionProvider.GetConnection)
            {
                var result = await Conn.QueryAsync<MetalTypeModel>(SPName, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
