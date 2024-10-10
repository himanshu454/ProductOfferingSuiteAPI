using System.Data;

namespace ProductOfferingSuiteAPI.Persistence.Configuration
{
    public interface ISqlConnectionProvider
    {
        IDbConnection GetConnection { get; }
    }
}