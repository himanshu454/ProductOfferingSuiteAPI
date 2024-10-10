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
    public class SettingTypeRepository : ISettingTypeRepository
    {
        private readonly ISqlConnectionProvider _sqlconnectionProvider;

        public SettingTypeRepository(ISqlConnectionProvider sqlconnectionProvider)
        {
            _sqlconnectionProvider = sqlconnectionProvider;
        }
        public async Task<List<SettingTypeModel>> GetSettingTypes()
        {
            var SPName = "CPLX_FillSettingTypeList";

            using (var Conn = _sqlconnectionProvider.GetConnection)
            {
                var result = await Conn.QueryAsync<SettingTypeModel>(SPName, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
