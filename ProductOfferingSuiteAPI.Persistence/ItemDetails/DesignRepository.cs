using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ProductOfferingSuiteAPI.Domain.ItemAttributes;
using ProductOfferingSuiteAPI.Persistence.Configuration;

namespace ProductOfferingSuiteAPI.Persistence.ItemDetails
{
    public class DesignRepository : IDesignRepository
    {
        private readonly ISqlConnectionProvider _sqlConnectionProvider;

        public DesignRepository(ISqlConnectionProvider sqlConnectionProvider)
        {
            _sqlConnectionProvider = sqlConnectionProvider;
        }

        public async Task<List<DesignGroupModel>> GetDesignGroup()
        {
            var SPName = "FillCboDesignGrp_Mas";

            using (var Conn = _sqlConnectionProvider.GetConnection)
            {
                var result = await Conn.QueryAsync<DesignGroupModel>(SPName, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<List<ActivityModel>> FillActivity()
        {
            var SPName = "CPLX_FillCboActivity";

            using (var Conn = _sqlConnectionProvider.GetConnection)
            {
                var result = await Conn.QueryAsync<ActivityModel>(SPName, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<List<LinkingTypeModel>> FillLinkingType()
        {
            var SPName = "CPLX_FillCboLinkingType";

            using (var Conn = _sqlConnectionProvider.GetConnection)
            {
                var result = await Conn.QueryAsync<LinkingTypeModel>(SPName, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<List<DesignListOutputModel>> GetDesignListDetails(DesignListInputModel designDetails)
        {
            var SPName = "CPLX_DesignList";

            var parameters = new DynamicParameters();
            parameters.Add("@FromDate", designDetails.FromDate, DbType.String, ParameterDirection.Input);
            parameters.Add("@ToDate", designDetails.ToDate, DbType.String, ParameterDirection.Input);
            parameters.Add("@DesignGrpId", designDetails.DesignGrpID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@ArticleTypeId", designDetails.ArticleTypeId, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@DesignNo", designDetails.DesignNo, DbType.String, ParameterDirection.Input);
            parameters.Add("@TempNo", designDetails.TempNo, DbType.String, ParameterDirection.Input);
            parameters.Add("@PONo", designDetails.PONo, DbType.String, ParameterDirection.Input);

            using (var Conn = _sqlConnectionProvider.GetConnection)
            {
                var result = await Conn.QueryAsync<DesignListOutputModel>(SPName, parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<DesignModel> GetDesignDetails(int Id)
        {
            var SPName = "CPLX_GetDesignDetails";

            DesignModel DM = new DesignModel();

            var parameters = new DynamicParameters();
            parameters.Add("@DMID", Id, DbType.Int32, ParameterDirection.Input);

            using (var Conn = _sqlConnectionProvider.GetConnection)
            {
                var result = await Conn.QueryMultipleAsync(SPName, parameters, commandType: CommandType.StoredProcedure);
                var Design = result.Read<DesignModel>().SingleOrDefault();
                var Studding = result.Read<DesignStuddingModel>().ToList();
                var Part = result.Read<DesignPartModel>().ToList();

                DM.DM_ID = Design.DM_ID;
                DM.DesignNo = Design.DesignNo;
                DM.CreationDate = Design.CreationDate;
                DM.ArticleType = Design.ArticleType;
                DM.TempNo = Design.TempNo;
                DM.ConstructionType = Design.ConstructionType;
                DM.WaxWt = Design.WaxWt;
                DM.ModelWt = Design.ModelWt;
                DM.Size = Design.Size;
                DM.SurfaceArea = Design.SurfaceArea;
                DM.JBackFitting = Design.JBackFitting;
                DM.ImagePath = Design.ImagePath;
                DM.ArticleAvgSurfaceArea = Design.ArticleAvgSurfaceArea;
                DM.JBackPolish = Design.JBackPolish;
                DM.JBackPolishCount = Design.JBackPolishCount;
                DM.DhagaPolish = Design.DhagaPolish;
                DM.DhagaPolishCount = Design.DhagaPolishCount;

                DM.DesignStudding = Studding;
                DM.DesignPart = Part;
                return DM;
            }
        }

        public async Task<int> UpdateDesignDetails(DesignModel designModel)
        {
            string StuddingXML = "", PartXML = "", MainXML = "";
            int retVal = 0;

            if (designModel != null)
            {
                MainXML = "<Main>";
                MainXML = MainXML + "<Detail>";
                MainXML = MainXML + "<SurfaceArea>" + designModel.SurfaceArea + "</SurfaceArea>";
                MainXML = MainXML + "<JBackFitting>" + designModel.JBackFitting + "</JBackFitting>";
                MainXML = MainXML + "<ImagePath>" + designModel.ImagePath + "</ImagePath>";
                MainXML = MainXML + "<JBackPolish>" + designModel.JBackPolish + "</JBackPolish>";
                MainXML = MainXML + "<JBackPolishCount>" + designModel.JBackPolishCount + "</JBackPolishCount>";
                MainXML = MainXML + "<DhagaPolish>" + designModel.DhagaPolish + "</DhagaPolish>";
                MainXML = MainXML + "<DhagaPolishCount>" + designModel.DhagaPolishCount + "</DhagaPolishCount>";
                MainXML = MainXML + "</Detail>";
                MainXML = MainXML + "</Main>";
            }


            var Studding = designModel.DesignStudding;
            if (Studding != null)
            {
                StuddingXML = "<Main>";
                foreach (var _Studding in Studding)
                {
                    StuddingXML = StuddingXML + "<Detail>";
                    StuddingXML = StuddingXML + "<DDID>" + _Studding.DD_Id.ToString() + "</DDID>";
                    StuddingXML = StuddingXML + "<ActivityID>" + _Studding.ActivityID.ToString() + "</ActivityID>";
                    StuddingXML = StuddingXML + "</Detail>";
                }
                StuddingXML = StuddingXML + "</Main>";
            }

            var Part = designModel.DesignPart;
            if (Part != null)
            {
                PartXML = "<Main>";
                foreach (var _Part in Part)
                {
                    PartXML = PartXML + "<Detail>";
                    PartXML = PartXML + "<DPDID>" + _Part.DPD_Id.ToString() + "</DPDID>";
                    PartXML = PartXML + "<AssemblyCount>" + _Part.AssemblyCount.ToString() + "</AssemblyCount>";
                    PartXML = PartXML + "<LinkingTypeID>" + _Part.LinkingTypeID.ToString() + "</LinkingTypeID>";
                    PartXML = PartXML + "<FindingTypeID>" + _Part.FindingTypeID.ToString() + "</FindingTypeID>";
                    PartXML = PartXML + "</Detail>";
                }
                PartXML = PartXML + "</Main>";
            }

            var SPName = "CPLX_UpdateDesignDetails";

            var parameters = new DynamicParameters();
            parameters.Add("@DesignID", designModel.DM_ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@MainXML", MainXML, DbType.String, ParameterDirection.Input);
            parameters.Add("@StuddingXML", StuddingXML, DbType.String, ParameterDirection.Input);
            parameters.Add("@PartXML", PartXML, DbType.String, ParameterDirection.Input);
            parameters.Add("@RetVal", retVal, DbType.Int32, ParameterDirection.ReturnValue);

            using (var connection = _sqlConnectionProvider.GetConnection)
            {
                var resut = await connection.ExecuteAsync(SPName, parameters, commandType: CommandType.StoredProcedure);
                retVal = parameters.Get<int>("@RetVal");
                return retVal;
            }

        }

        public async Task<List<DesignFindingTypeModel>> GetDesignFindingType()
        {
            var SPName = "FillCboDesignFindingType";

            using (var Conn = _sqlConnectionProvider.GetConnection)
            {
                var result = await Conn.QueryAsync<DesignFindingTypeModel>(SPName, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
