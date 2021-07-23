using CoreApiAdoDemo.Model;
using CoreApiAdoDemo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiAdoDemo.Translators;
using System.Data.SqlClient;
using System.Data;

namespace CoreApiAdoDemo.Repository
{
    public class UserDbClient
    {
        public UsersModel GetCreadentialData(UsersModel model, string connString)
        {
            SqlParameter[] param = {
                new SqlParameter("@UserName",model.UserName),
                new SqlParameter("@Password",model.Password)
            };

            return SqlHelper.ExtecuteProcedureReturnData<UsersModel>(connString,
                "SP_145_User_GetCreadential", r => r.TranslateAsUser(), param);
        }

        public List<UsersModel> GetAllUsers(string connString)
        {
            SqlParameter[] param = {
                new SqlParameter("@COMPANYID", 1),
                new SqlParameter("@Status", 1)
            };
            return SqlHelper.ExtecuteProcedureReturnData<List<UsersModel>>(connString,
                "SP_145_User_GetByCompanyId", r => r.TranslateAsUsersList(), param);
        }

        public string SaveUser(UsersModel model, string connString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
                new SqlParameter("@Id",model.Id),
                new SqlParameter("@Name",model.Name),
                new SqlParameter("@EmailId",model.EmailId),
                new SqlParameter("@Mobile",model.Mobile),
                new SqlParameter("@Address",model.Address),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "SaveUser", param);
            return (string)outParam.Value;
        }

        public string DeleteUser(int id,string connString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
                new SqlParameter("@Id",id),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "DeleteUser", param);
            return (string)outParam.Value;
        }
    }
}
