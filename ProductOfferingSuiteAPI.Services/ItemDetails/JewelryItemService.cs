using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductOfferingSuiteAPI.Domain.Global;
using ProductOfferingSuiteAPI.Domain.ItemAttributes;
using ProductOfferingSuiteAPI.Persistence.ItemDetails;
using ProductOfferingSuiteAPI.Services.ItemDetails;

namespace DesignComplexityAPI.Services.ItemDetails
{
    public class JewelryItemService : IJewelryItemService
    {
        private readonly IJewelryItemRepository _jewelryItemRepository;

        public JewelryItemService(IJewelryItemRepository jewelryItemRepository)
        {
            _jewelryItemRepository = jewelryItemRepository;
        }

        public async Task<TransactionDataModel<List<JewelryItemModel>>> GetJewelryItemDetails(JewelryListInputModel JwlDetails)
        {
            TransactionDataModel<List<JewelryItemModel>> JwlDtl = new TransactionDataModel<List<JewelryItemModel>>();
            JwlDtl.Data = await _jewelryItemRepository.GetJewelryItemDetails(JwlDetails);
            JwlDtl.ReturnCode = 0;
            JwlDtl.Message = "Data Shown Properly";
            return JwlDtl;
        }

        public async Task<TransactionDataModel<JewleryModel>> GetJewelryDetails(int Id)
        {
            TransactionDataModel<JewleryModel> JwlDtl = new TransactionDataModel<JewleryModel>();
            JwlDtl.Data = await _jewelryItemRepository.GetJewelryDetails(Id);
            JwlDtl.ReturnCode = 0;
            JwlDtl.Message = "Data Shown Properly";
            return JwlDtl;
        }

        public async Task<TransactionDataModel<List<POModel>>> FillPO()
        {
            TransactionDataModel<List<POModel>> PO = new TransactionDataModel<List<POModel>>();
            PO.Data = await _jewelryItemRepository.FillPO();
            PO.ReturnCode = 0;
            PO.Message = "Data Shown Properly";
            return PO;
        }

        public async Task<TransactionDataModel<string>> CalculateComplexity(List<int> ItemCode)
        {
            TransactionDataModel<string> Complexity = new TransactionDataModel<string>();
            Complexity.Data = await _jewelryItemRepository.CalculateComplexity(ItemCode);
            Complexity.ReturnCode = 0;
            Complexity.Message = "Data Shown Properly";
            return Complexity;
        }
    }
}
