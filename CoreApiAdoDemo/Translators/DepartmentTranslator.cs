using CoreApiAdoDemo.Model;
using CoreApiAdoDemo.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiAdoDemo.Translators
{
    public static class DepartmentTranslator
    {
        public static DepartmentModel TranslateAsDepartment(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new DepartmentModel();
            if (reader.IsColumnExists("DepartmentId"))
                item.Id = SqlHelper.GetNullableInt32(reader, "DepartmentId");

            if (reader.IsColumnExists("DEPARTMENTNAME"))
                item.Name = SqlHelper.GetNullableString(reader, "DEPARTMENTNAME");

            if (reader.IsColumnExists("COMPANYID"))
                item.CompanyId = SqlHelper.GetNullableInt32(reader, "COMPANYID");

            if (reader.IsColumnExists("COMPANYNAME"))
                item.CompanyName = SqlHelper.GetNullableString(reader, "COMPANYNAME");

            if (reader.IsColumnExists("Code"))
                item.Code = SqlHelper.GetNullableString(reader, "Code");

            if (reader.IsColumnExists("Description"))
                item.Description = SqlHelper.GetNullableString(reader, "Description");

            return item;
        }

        public static List<DepartmentModel> TranslateAsDepartmentList(this SqlDataReader reader)
        {
            var list = new List<DepartmentModel>();
            while (reader.Read())
            {
                list.Add(TranslateAsDepartment(reader, true));
            }
            return list;
        }
    }
}
