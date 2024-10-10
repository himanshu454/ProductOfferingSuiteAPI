using System.Threading.Tasks;
using ProductOfferingSuiteAPI.Domain.Global;
using ProductOfferingSuiteAPI.Domain.ItemAttributes;

namespace ProductOfferingSuiteAPI.Services.ItemDetails
{
    public interface IDesignService
    {
        Task<TransactionDataModel<List<DesignGroupModel>>> GetDesignGroup();
        Task<TransactionDataModel<List<DesignListOutputModel>>> GetDesignListDetails(DesignListInputModel designDetails);
        Task<TransactionDataModel<DesignModel>> GetDesignDetails(int Id);
        Task<TransactionDataModel<List<ActivityModel>>> FillActivity();
        Task<TransactionDataModel<List<LinkingTypeModel>>> FillLinking();
        Task<TransactionDataModel<int>> UpdateDesignDetails(DesignModel designModel);
        Task<TransactionDataModel<List<DesignFindingTypeModel>>> GetDesignFindingType();
    }
}