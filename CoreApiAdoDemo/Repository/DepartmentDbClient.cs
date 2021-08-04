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

        public DepartmentModel GetDepartmentById(string connString, string action, Int32 id)
        {
            SqlParameter[] param = {
                new SqlParameter("@ACTION", action),
                new SqlParameter("@DEPARTMENTID", id)
            };
            return SqlHelper.ExtecuteProcedureReturnData<DepartmentModel>(connString,
                "SP_145_Department_Get", r => r.TranslateAsDepartment(), param);
        }

        public string SaveDepartment(DepartmentModel model, string connString)
        {
            var outParam = new SqlParameter("@DEPARTMENTID", SqlDbType.BigInt)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
                outParam,
                new SqlParameter("@COMPANYID",model.CompanyId),
                new SqlParameter("@CODE",model.Code),
                new SqlParameter("@NAME",model.Name),
                new SqlParameter("@DESCRIPTION",model.Description),
                new SqlParameter("@CREATED_BY", 1)
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "SP_145_Department_InsertUpdate", param);
            return Convert.ToString(outParam.Value);
        }

        public string UpdateDepartment(DepartmentModel model, string connString)
        {
            var deptModel = new DepartmentModel();
            deptModel = GetDepartmentById(connString, "GETFORID", model.Id);

            deptModel.Code = model.Code;
            deptModel.Name = model.Name;
            deptModel.Description = model.Description;

            var outParam = new SqlParameter("@DEPARTMENTID", SqlDbType.BigInt)
            {
                Value = model.Id,
                Direction = ParameterDirection.InputOutput
            };
            SqlParameter[] param = {
                outParam,
                new SqlParameter("@COMPANYID",deptModel.CompanyId),
                new SqlParameter("@CODE",deptModel.Code),
                new SqlParameter("@NAME",deptModel.Name),
                new SqlParameter("@DESCRIPTION",deptModel.Description),
                new SqlParameter("@CREATED_BY", 1)
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "SP_145_Department_InsertUpdate", param);
            return Convert.ToString(outParam.Value);
        }
         
        public string DeleteDepartment(int id, string connString)
        {
            var outParam = new SqlParameter("@DEPARTMENTID", SqlDbType.BigInt)
            {
                Direction = ParameterDirection.InputOutput,
                Value = id
            };
            SqlParameter[] param = {
                outParam,
                new SqlParameter("@UPDATEDBY", 1)                
            };
            SqlHelper.ExecuteProcedureReturnString(connString, "SP_145_Department_Delete", param);
            return Convert.ToString(outParam.Value);
        }
    }
}
