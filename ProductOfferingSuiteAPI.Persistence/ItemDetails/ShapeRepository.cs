using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ProductOfferingSuiteAPI.Domain.ItemAttributes;
using ProductOfferingSuiteAPI.Persistence.Configuration;

namespace ProductOfferingSuiteAPI.Persistence.ItemDetails
{
    public class ShapeRepository : IShapeRepository
    {
        private readonly ISqlConnectionProvider _sqlConnection;

        public ShapeRepository(ISqlConnectionProvider sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<List<ShapeModel>> GetShape()
        {
            var query = "CPLX_FillShapeList";

            using (var connecion = _sqlConnection.GetConnection)
            {
                var results = await connecion.QueryAsync<ShapeModel>(query, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }
        }
    }
}
