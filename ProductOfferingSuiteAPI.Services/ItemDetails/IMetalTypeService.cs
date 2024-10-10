using ProductOfferingSuiteAPI.Domain.Global;
using ProductOfferingSuiteAPI.Domain.ItemAttributes;

namespace ProductOfferingSuiteAPI.Services.ItemDetails
{
    public interface IMetalTypeService
    {
        Task<TransactionDataModel<List<MetalTypeModel>>> GetMetalType();
    }
}