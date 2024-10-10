using ProductOfferingSuiteAPI.Domain.Global;
using ProductOfferingSuiteAPI.Domain.ItemAttributes;

namespace ProductOfferingSuiteAPI.Services.ItemDetails
{
    public interface IJewelryItemService
    {
        Task<TransactionDataModel<List<JewelryItemModel>>> GetJewelryItemDetails(JewelryListInputModel JwlDetails);
        Task<TransactionDataModel<List<POModel>>> FillPO();
        Task<TransactionDataModel<JewleryModel>> GetJewelryDetails(int Id);
        Task<TransactionDataModel<string>> CalculateComplexity(List<int> ItemCode);
    }
}