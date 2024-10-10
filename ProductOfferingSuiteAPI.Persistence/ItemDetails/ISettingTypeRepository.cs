using ProductOfferingSuiteAPI.Domain.ItemAttributes;

namespace ProductOfferingSuiteAPI.Persistence.ItemDetails
{
    public interface ISettingTypeRepository
    {
        Task<List<SettingTypeModel>> GetSettingTypes();
    }
}