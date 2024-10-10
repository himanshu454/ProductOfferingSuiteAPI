using ProductOfferingSuiteAPI.Domain.ItemAttributes;

namespace ProductOfferingSuiteAPI.Persistence.ItemDetails
{
    public interface IJewelryItemRepository
    {
        Task<List<JewelryItemModel>> GetJewelryItemDetails(JewelryListInputModel JwlItemDetails);
        Task<List<POModel>> FillPO();
        Task<JewleryModel> GetJewelryDetails(int Id);
        Task<string> CalculateComplexity(List<int> ItemCode);
    }
}