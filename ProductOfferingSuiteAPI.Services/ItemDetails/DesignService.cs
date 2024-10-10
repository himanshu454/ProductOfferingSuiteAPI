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
    public class DesignService : IDesignService
    {
        private readonly IDesignRepository _designRepository;

        public DesignService(IDesignRepository designRepository)
        {
            _designRepository = designRepository;
        }

        public async Task<TransactionDataModel<List<DesignGroupModel>>> GetDesignGroup()
        {
            TransactionDataModel<List<DesignGroupModel>> DesignGrp = new TransactionDataModel<List<DesignGroupModel>>();
            DesignGrp.Data = await _designRepository.GetDesignGroup();
            DesignGrp.ReturnCode = 0;
            DesignGrp.Message = "Data Shown Properly";
            return DesignGrp;
        }

        public async Task<TransactionDataModel<List<ActivityModel>>> FillActivity()
        {
            TransactionDataModel<List<ActivityModel>> Activity = new TransactionDataModel<List<ActivityModel>>();
            Activity.Data = await _designRepository.FillActivity();
            Activity.ReturnCode = 0;
            Activity.Message = "Data Shown Properly";
            return Activity;
        }
        public async Task<TransactionDataModel<List<LinkingTypeModel>>> FillLinking()
        {
            TransactionDataModel<List<LinkingTypeModel>> Linking = new TransactionDataModel<List<LinkingTypeModel>>();
            Linking.Data = await _designRepository.FillLinkingType();
            Linking.ReturnCode = 0;
            Linking.Message = "Data Shown Properly";
            return Linking;
        }

        public async Task<TransactionDataModel<List<DesignListOutputModel>>> GetDesignListDetails(DesignListInputModel designDetails)
        {
            TransactionDataModel<List<DesignListOutputModel>> DesignDtl = new TransactionDataModel<List<DesignListOutputModel>>();
            DesignDtl.Data = await _designRepository.GetDesignListDetails(designDetails);
            DesignDtl.ReturnCode = 0;
            DesignDtl.Message = "Data Shown Properly";
            return DesignDtl;
        }

        public async Task<TransactionDataModel<DesignModel>> GetDesignDetails(int Id)
        {
            TransactionDataModel<DesignModel> DesignDtl = new TransactionDataModel<DesignModel>();
            DesignDtl.Data = await _designRepository.GetDesignDetails(Id);
            DesignDtl.ReturnCode = 0;
            DesignDtl.Message = "Data Shown Properly";
            return DesignDtl;
        }

        public async Task<TransactionDataModel<int>> UpdateDesignDetails(DesignModel designModel)
        {
            TransactionDataModel<int> UpdateDesignDtl = new TransactionDataModel<int>();
            UpdateDesignDtl.Data = await _designRepository.UpdateDesignDetails(designModel);
            UpdateDesignDtl.ReturnCode = UpdateDesignDtl.Data;
            UpdateDesignDtl.Message = UpdateDesignDtl.ReturnCode == 0 ? "Data Update Sucessfully" : "Error Occur while Updation";
            return UpdateDesignDtl;
        }

        public async Task<TransactionDataModel<List<DesignFindingTypeModel>>> GetDesignFindingType()
        {
            TransactionDataModel<List<DesignFindingTypeModel>> DesignFindng = new TransactionDataModel<List<DesignFindingTypeModel>>();
            DesignFindng.Data = await _designRepository.GetDesignFindingType();
            DesignFindng.ReturnCode = 0;
            DesignFindng.Message = "Data Shown Properly";
            return DesignFindng;
        }
    }
}
