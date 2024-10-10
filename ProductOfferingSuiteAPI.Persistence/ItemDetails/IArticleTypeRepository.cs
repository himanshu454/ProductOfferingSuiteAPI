using ProductOfferingSuiteAPI.Domain.ItemAttributes;

namespace ProductOfferingSuiteAPI.Persistence.ItemDetails
{
    public interface IArticleTypeRepository
    {
        Task<List<ArticleTypeModel>> GetArticleType();
        Task<List<ItemGroupModel>> FillItemGroup();
    }
}