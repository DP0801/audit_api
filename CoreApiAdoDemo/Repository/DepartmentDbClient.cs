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
    public class DepartmentDbClient
    {

        public List<DepartmentModel> GetAllDepartments(string connString, string action)
        {
            SqlParameter[] param = {
                new SqlParameter("@ACTION", action),
                new SqlParameter("@DEPARTMENTID", 0)
            };
            return SqlHelper.ExtecuteProcedureReturnData<List<DepartmentModel>>(connString,
                "SP_145_Department_Get", r => r.TranslateAsDepartmentList(), param);
        }

        public string SaveDepartment(DepartmentModel model, string connString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.NVarChar, 20)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
                new SqlParameter("@Id",model.Id),
                new SqlParameter("@Name",model.Name),
                new SqlParameter("@EmailId",model.Code),
                new SqlParameter("@Mobile",model.Description),
                new SqlParameter("@Address",model.Code),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "SP_145_Department_InsertUpdate", param);
            return (string)outParam.Value;
        }

        public string DeleteDepartment(string connString, int updatedby)
        {
            var outParam = new SqlParameter("@DEPARTMENTID", SqlDbType.BigInt)
            {
                Direction = ParameterDirection.InputOutput
            };
            SqlParameter[] param = {
                new SqlParameter("@UPDATEDBY", updatedby),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "SP_145_Department_Delete", param);
            return (string)outParam.Value;
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
            SqlHelper.ExecuteProcedureReturnString(connString, "SP_145_Department_InsertUpdate", param);
            return (string)outParam.Value;
        }


        public string DeleteDepartment(int id, string connString)
        {
            var outParam = new SqlParameter("@DEPARTMENTID", SqlDbType.BigInt)
            {
                Direction = ParameterDirection.InputOutput,
                Value = id
            };
            SqlParameter[] param = {
                new SqlParameter("@UPDATEDBY", 1),
                outParam
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "SP_145_Department_Delete", param);
            return (string)outParam.Value;
        }
    }
}
