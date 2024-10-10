using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductOfferingSuiteAPI.Domain.Global;
using ProductOfferingSuiteAPI.Domain.ItemAttributes;
using ProductOfferingSuiteAPI.Persistence.ItemDetails;

namespace ProductOfferingSuiteAPI.Services.ItemDetails
{
    public class ArticleTypeService : IArticleTypeService
    {
        private readonly IArticleTypeRepository _articleTypeRepository;

        public ArticleTypeService(IArticleTypeRepository articleTypeRepository)
        {
            _articleTypeRepository = articleTypeRepository;
        }

        public async Task<TransactionDataModel<List<ArticleTypeModel>>> GetArticleType()
        {
            TransactionDataModel<List<ArticleTypeModel>> GetArticle = new TransactionDataModel<List<ArticleTypeModel>>();
            GetArticle.Data = await _articleTypeRepository.GetArticleType();
            GetArticle.ReturnCode = 0;
            GetArticle.Message = "Data Shown Properly";
            return GetArticle;
        }

        public async Task<TransactionDataModel<List<ItemGroupModel>>> FillItemGroup()
        {
            TransactionDataModel<List<ItemGroupModel>> FillItemGroup = new TransactionDataModel<List<ItemGroupModel>>();
            FillItemGroup.Data = await _articleTypeRepository.FillItemGroup();
            FillItemGroup.ReturnCode = 0;
            FillItemGroup.Message = "Data Shown Properly";
            return FillItemGroup;
        }
    }
}
