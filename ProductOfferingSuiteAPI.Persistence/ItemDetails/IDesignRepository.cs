using ProductOfferingSuiteAPI.Domain.ItemAttributes;

namespace ProductOfferingSuiteAPI.Persistence.ItemDetails
{
    public interface IDesignRepository
    {
        Task<List<DesignGroupModel>> GetDesignGroup();
        Task<List<DesignListOutputModel>> GetDesignListDetails(DesignListInputModel designDetails);
        Task<DesignModel> GetDesignDetails(int Id);
        Task<List<ActivityModel>> FillActivity();
        Task<List<LinkingTypeModel>> FillLinkingType();
        Task<int> UpdateDesignDetails(DesignModel designModel);
        Task<List<DesignFindingTypeModel>> GetDesignFindingType();
    }
}