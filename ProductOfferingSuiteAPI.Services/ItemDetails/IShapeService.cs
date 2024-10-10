using ProductOfferingSuiteAPI.Domain.Global;
using ProductOfferingSuiteAPI.Domain.ItemAttributes;

namespace DesignComplexityAPI.Services.ItemDetails
{
    public interface IShapeService
    {
        Task<TransactionDataModel< List<ShapeModel>>> GetShape();
    }
}