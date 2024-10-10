using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ProductOfferingSuiteAPI.Domain.ItemAttributes;
using ProductOfferingSuiteAPI.Persistence.Configuration;

namespace ProductOfferingSuiteAPI.Persistence.ItemDetails
{
    public class ArticleTypeRepository : IArticleTypeRepository
    {
        private readonly ISqlConnectionProvider _sqlconnectionProvider;

        public ArticleTypeRepository(ISqlConnectionProvider sqlconnectionProvider)
        {
            _sqlconnectionProvider = sqlconnectionProvider;
        }

        public async Task<List<ArticleTypeModel>> GetArticleType()
        {
            var SPName = "CPLX_FillArticleTypeList";

            using (var Conn = _sqlconnectionProvider.GetConnection)
            {
                var results = await Conn.QueryAsync<ArticleTypeModel>(SPName, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }
        }

        public async Task<List<ItemGroupModel>> FillItemGroup()
        {
            var SPName = "FillCboItemGrp_Mas";
            var Paramters = new DynamicParameters();
            Paramters.Add("@IClsM_Id", 1, DbType.Int32, ParameterDirection.Input);
            Paramters.Add("@ShowSetItem", 1, DbType.Boolean, ParameterDirection.Input);

            using (var Conn = _sqlconnectionProvider.GetConnection)
            {
                var results = await Conn.QueryAsync<ItemGroupModel>(SPName, Paramters, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }
        }
    }
}
