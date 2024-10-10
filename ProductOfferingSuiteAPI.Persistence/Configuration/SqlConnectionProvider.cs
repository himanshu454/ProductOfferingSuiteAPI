using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace ProductOfferingSuiteAPI.Persistence.Configuration
{

    public class SqlConnectionProvider : ISqlConnectionProvider
    {
        private readonly string _connectionString;
        public SqlConnectionProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetConnection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }
    }
}
