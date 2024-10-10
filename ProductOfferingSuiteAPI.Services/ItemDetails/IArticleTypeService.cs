using ProductOfferingSuiteAPI.Domain.Global;
using ProductOfferingSuiteAPI.Domain.ItemAttributes;

namespace ProductOfferingSuiteAPI.Services.ItemDetails
{
    public interface IArticleTypeService
    {
        Task<TransactionDataModel<List<ArticleTypeModel>>> GetArticleType();
        Task<TransactionDataModel<List<ItemGroupModel>>> FillItemGroup();
    }
}