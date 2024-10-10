using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
using System.Reflection.Metadata;
using System.Data;
using System.Collections;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
//using DesignComplexityAPI.Domain.Global;
using ProductOfferingSuiteAPI.Domain.Login;
using ProductOfferingSuiteAPI.Persistence.Configuration;


namespace ProductOfferingSuiteAPI.Persistence.LoginDetails
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ISqlConnectionProvider _sqlConnectionProvider;

        public LoginRepository(ISqlConnectionProvider sqlConnectionProvider)
        {
            _sqlConnectionProvider = sqlConnectionProvider;
        }

        public async Task<LoginPOSModel> GetLoginDetail(LoginPOSInputModel loginPOSInput)
        {
            var SPName = "POS_Login";

            var Parameters = new DynamicParameters();
            Parameters.Add("@UserName", loginPOSInput.UserName, DbType.String, ParameterDirection.Input);
            Parameters.Add("@Password", loginPOSInput.Password, DbType.String, ParameterDirection.Input);


            using (var connection = _sqlConnectionProvider.GetConnection)
            {
                return await connection.QuerySingleOrDefaultAsync<LoginPOSModel>(SPName, Parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<LoginPOSRegModel> LoginRegistration(LoginPOSRegInputModel loginPOSReginput)
        {
            var SPName = "POS_LoginRegistration";

            var Parameters = new DynamicParameters();
            Parameters.Add("@FirstName", loginPOSReginput.FirstName, DbType.String, ParameterDirection.Input);
            Parameters.Add("@LastName", loginPOSReginput.LastName, DbType.String, ParameterDirection.Input);
            Parameters.Add("@PhoneNo", loginPOSReginput.PhoneNo, DbType.String, ParameterDirection.Input);
            Parameters.Add("@Password", loginPOSReginput.Password, DbType.String, ParameterDirection.Input);
            Parameters.Add("@Email", loginPOSReginput.Email, DbType.String, ParameterDirection.Input);

            using (var connection = _sqlConnectionProvider.GetConnection)
            {
                return await connection.QuerySingleOrDefaultAsync<LoginPOSRegModel>(SPName, Parameters, commandType: CommandType.StoredProcedure);
            }
        }


        public async Task<LoginModel> GetUserLogin(LoginModel loginmodel)
        {
            var SPName = "PMT_CheckUserPassword";

            var Parameters = new DynamicParameters();
            Parameters.Add("@UserNameV", loginmodel.UserNameV, DbType.String, ParameterDirection.Input);
            Parameters.Add("@Password", loginmodel.UserPassWord, DbType.String, ParameterDirection.Input);

            using (var connection = _sqlConnectionProvider.GetConnection)
            {
                return await connection.QuerySingleOrDefaultAsync<LoginModel>(SPName, Parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<int> UpdateLoginProfile(LoginPOSUpdateProfileInputModel updateProfile)
        {
            int RetVal = 0;
            var SPName = "POS_UpdateLoginProfile";

            var Parameters = new DynamicParameters();
            Parameters.Add("@UserID", updateProfile.UserId, DbType.Int32, ParameterDirection.Input);
            Parameters.Add("@FirstName", updateProfile.FirstName, DbType.String, ParameterDirection.Input);
            Parameters.Add("@LastName", updateProfile.LastName, DbType.String, ParameterDirection.Input);
            Parameters.Add("@PhoneNumber", updateProfile.PhoneNo, DbType.String, ParameterDirection.Input);
            Parameters.Add("@RetVal", RetVal, DbType.String, ParameterDirection.ReturnValue);

            using (var connection = _sqlConnectionProvider.GetConnection)
            {
                var result = await connection.QueryAsync<LoginPOSUpdateProfileInputModel>(SPName, Parameters, commandType: CommandType.StoredProcedure);
                RetVal = Parameters.Get<int>("@RetVal");
            }
            return RetVal;
        }

        public async Task<int> ChangePassword(LoginPOSChangePwdInputModel changePwd)
        {
            int RetVal = 0;
            var SPName = "POS_ChangeLoginPassword";

            var Parameters = new DynamicParameters();
            Parameters.Add("@UserID", changePwd.UserId, DbType.Int32, ParameterDirection.Input);
            Parameters.Add("@Password", changePwd.Password, DbType.String, ParameterDirection.Input);
            Parameters.Add("@ConfirmPassword", changePwd.ConfirmPassword, DbType.String, ParameterDirection.Input);
            Parameters.Add("@RetVal", RetVal, DbType.String, ParameterDirection.ReturnValue);

            using (var connection = _sqlConnectionProvider.GetConnection)
            {
                var result = await connection.QueryAsync<LoginPOSChangePwdInputModel>(SPName, Parameters, commandType: CommandType.StoredProcedure);
                RetVal = Parameters.Get<int>("@RetVal");
            }
            return RetVal;
        }

        public async Task<LoginPOSInputModel> ReLogin(int UserID)
        {
            var SPName = "POS_ReLogin";

            var Parameters = new DynamicParameters();
            Parameters.Add("@UserID", UserID, DbType.Int32, ParameterDirection.Input);

            using (var connection = _sqlConnectionProvider.GetConnection)
            {
                return await connection.QuerySingleOrDefaultAsync<LoginPOSInputModel>(SPName, Parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
