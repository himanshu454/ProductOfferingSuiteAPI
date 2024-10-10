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
    public class MetalTypeService : IMetalTypeService
    {
        private readonly IMetalTypeRepository _metalTypeRepository;

        public MetalTypeService(IMetalTypeRepository metalTypeRepository)
        {
            _metalTypeRepository = metalTypeRepository;
        }

        public async Task<TransactionDataModel<List<MetalTypeModel>>> GetMetalType()
        {
            TransactionDataModel<List<MetalTypeModel>> MtlType = new TransactionDataModel<List<MetalTypeModel>>();
            MtlType.Data = await _metalTypeRepository.GetMetalTypes();
            MtlType.ReturnCode = 0;
            MtlType.Message = "Data Shown Properly";
            return MtlType;
        }
    }
}
