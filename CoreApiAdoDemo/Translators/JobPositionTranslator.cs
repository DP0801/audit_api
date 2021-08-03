using CoreApiAdoDemo.Model;
using CoreApiAdoDemo.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiAdoDemo.Translators
{
    public static class JobPositionTranslator
    {
        public static JobPositionModel TranslateAsJobPosition(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new JobPositionModel();
            if (reader.IsColumnExists("JobPositionId"))
                item.Id = SqlHelper.GetNullableInt32(reader, "JobPositionId");

            if (reader.IsColumnExists("DepartmentId"))
                item.Id = SqlHelper.GetNullableInt32(reader, "DepartmentId");

            if (reader.IsColumnExists("JOBNAME"))
                item.Name = SqlHelper.GetNullableString(reader, "JOBNAME");

            if (reader.IsColumnExists("COMPANYNAME"))
                item.CompanyName = SqlHelper.GetNullableString(reader, "COMPANYNAME");

            if (reader.IsColumnExists("Code"))
                item.Code = SqlHelper.GetNullableString(reader, "Code");

            if (reader.IsColumnExists("Description"))
                item.Description = SqlHelper.GetNullableString(reader, "Description");

            if (reader.IsColumnExists("DEPARTMENTNAME"))
                item.DepartmentName = SqlHelper.GetNullableString(reader, "DEPARTMENTNAME");

            return item;
        }

        public static List<JobPositionModel> TranslateAsJobPositionList(this SqlDataReader reader)
        {
            var list = new List<JobPositionModel>();
            while (reader.Read())
            {
                list.Add(TranslateAsJobPosition(reader, true));
            }
            return list;
        }
    }
}
