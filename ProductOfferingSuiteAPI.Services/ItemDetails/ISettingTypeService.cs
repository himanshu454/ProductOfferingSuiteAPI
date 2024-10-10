using ProductOfferingSuiteAPI.Domain.Global;
using ProductOfferingSuiteAPI.Domain.ItemAttributes;

namespace DesignComplexityAPI.Services.ItemDetails
{
    public interface ISettingTypeService
    {
        Task<TransactionDataModel<List<SettingTypeModel>>> GetSettingType();
    }
}