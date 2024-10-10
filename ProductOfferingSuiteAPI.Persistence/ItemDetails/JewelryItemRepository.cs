using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Dapper;
using ProductOfferingSuiteAPI.Domain.ItemAttributes;
using ProductOfferingSuiteAPI.Persistence.Configuration;

namespace ProductOfferingSuiteAPI.Persistence.ItemDetails
{
    public class JewelryItemRepository : IJewelryItemRepository
    {
        private readonly ISqlConnectionProvider _connectionProvider;

        public JewelryItemRepository(ISqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<List<JewelryItemModel>> GetJewelryItemDetails(JewelryListInputModel JwlItemDetails)
        {
            var SPName = "CPLX_GetJewelleryDetails";

            var parameters = new DynamicParameters();
            parameters.Add("@FromDate", JwlItemDetails.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("@ToDate", JwlItemDetails.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("@ItemGrpId", JwlItemDetails.ItemGrpID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ArticleId", JwlItemDetails.ArticleTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@MetalId", JwlItemDetails.MetalID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ItemCode", JwlItemDetails.ItemCode, DbType.String, ParameterDirection.Input);
            parameters.Add("@DesignNo", JwlItemDetails.DesignNo, DbType.String, ParameterDirection.Input);
            parameters.Add("@PONo", JwlItemDetails.PONo, DbType.String, ParameterDirection.Input);


            using (var Conn = _connectionProvider.GetConnection)
            {
                var result = await Conn.QueryAsync<JewelryItemModel>(SPName, parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<List<POModel>> FillPO()
        {
            var SPName = "CPLX_FillCboPO";
            using (var Conn = _connectionProvider.GetConnection)
            {
                var result = await Conn.QueryAsync<POModel>(SPName, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<JewleryModel> GetJewelryDetails(int Id)
        {
            var SPName = "CPLX_GetItemMasJewelleryDetails";

            JewleryModel JM = new JewleryModel();

            var parameters = new DynamicParameters();
            parameters.Add("@ItMas_Id", Id, DbType.Int32, ParameterDirection.Input);

            using (var Conn = _connectionProvider.GetConnection)
            {
                var result = await Conn.QueryMultipleAsync(SPName, parameters, commandType: CommandType.StoredProcedure);
                var Jewel = result.Read<JewleryModel>().SingleOrDefault();
                var Studding = result.Read<JwlStuddModel>().ToList();
                var Part = result.Read<JwlPartModel>().ToList();

                JM.ItemID = Jewel.ItemID;
                JM.ItemName = Jewel.ItemName;
                JM.ItemCode = Jewel.ItemCode;
                JM.Details = Jewel.Details;
                JM.ItemGroup = Jewel.ItemGroup;
                JM.DM_Id = Jewel.DM_Id;
                JM.DesignNo = Jewel.DesignNo;
                JM.Metal = Jewel.Metal;
                JM.ArticleType = Jewel.ArticleType;
                JM.Complexity = Jewel.Complexity;
                JM.FinishType = Jewel.FinishType;
                JM.Size = Jewel.Size;
                JM.FinishWt = Jewel.FinishWt;
                JM.RawWt = Jewel.RawWt;
                JM.ImgPath = Jewel.ImgPath;
                JM.WaxTime = Jewel.WaxTime;
                JM.CastingTime = Jewel.CastingTime;
                JM.MassFinishingTime = Jewel.MassFinishingTime;
                JM.FilingTime = Jewel.FilingTime;
                JM.PolishTime = Jewel.PolishTime;
                JM.TotalPolishTime = Jewel.TotalPolishTime;
                JM.PlatingTime = Jewel.PlatingTime;
                JM.AssemblyTime = Jewel.AssemblyTime;
                JM.SettingTime = Jewel.SettingTime;

                JM.jwlStuddModels = Studding;
                JM.jwlPartModels = Part;
                return JM;
            }
        }

        public async Task<string> CalculateComplexity(List<int> ItemCode)
        {
            var SPName = "CPLX_CalculateComplexity";
            int retVal = 0;
            string CommaSepItemCodes = "";
            string Message = "";

            CommaSepItemCodes = string.Join(",", ItemCode);

            var parameters = new DynamicParameters();
            parameters.Add("@ItemCodes", CommaSepItemCodes, DbType.String, ParameterDirection.Input);
            parameters.Add("@RetVal", retVal, DbType.Int32, ParameterDirection.ReturnValue);

            using (var Conn = _connectionProvider.GetConnection)
            {
                var result = await Conn.QueryAsync<ComplexityModel>(SPName, parameters, commandType: CommandType.StoredProcedure);
                retVal = parameters.Get<int>("@RetVal");
                if (retVal == 0)
                {
                    Message = "Complexity Calculated Successfully";
                }
                else
                {
                    if (result != null)
                    {
                        Message = "List of Item Codes generated error while calculated Complexity" + Environment.NewLine;
                        foreach (var r in result)
                        {
                            Message = Message + "ItemCode : " + r.ItemCode + " Error : " + r.ErrorDesc + Environment.NewLine;
                        }
                    }
                }
                return Message;
            }
        }
    }
}
