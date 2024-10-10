using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductOfferingSuiteAPI.Domain.Global;
using ProductOfferingSuiteAPI.Domain.ItemAttributes;
using ProductOfferingSuiteAPI.Persistence.ItemDetails;

namespace DesignComplexityAPI.Services.ItemDetails
{
    public class SettingTypeService : ISettingTypeService
    {
        private readonly ISettingTypeRepository _settingTypeRepository;

        public SettingTypeService(ISettingTypeRepository settingTypeRepository)
        {
            _settingTypeRepository = settingTypeRepository;
        }

        public async Task<TransactionDataModel<List<SettingTypeModel>>> GetSettingType()
        {
            TransactionDataModel<List<SettingTypeModel>> SettingType = new TransactionDataModel<List<SettingTypeModel>>();
            SettingType.Data = await _settingTypeRepository.GetSettingTypes();
            SettingType.ReturnCode = 0;
            SettingType.Message = "Data Shown Properly";
            return SettingType;
        }
    }
}
