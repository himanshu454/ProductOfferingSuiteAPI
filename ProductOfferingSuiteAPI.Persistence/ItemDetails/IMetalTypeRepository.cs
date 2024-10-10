using ProductOfferingSuiteAPI.Domain.ItemAttributes;

namespace ProductOfferingSuiteAPI.Persistence.ItemDetails
{
    public interface IMetalTypeRepository
    {
        Task<List<MetalTypeModel>> GetMetalTypes();
    }
}