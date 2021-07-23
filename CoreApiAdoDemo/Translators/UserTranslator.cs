using CoreApiAdoDemo.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CoreApiAdoDemo.Utility;

namespace CoreApiAdoDemo.Translators
{
    public static class UserTranslator
    {
        public static UsersModel TranslateAsUser(this SqlDataReader reader,bool isList = false)
        {
            if(!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new UsersModel();
            if (reader.IsColumnExists("USER_ID"))
                item.Id = SqlHelper.GetNullableInt32(reader, "USER_ID");

            if (reader.IsColumnExists("NAME"))
                item.Name = SqlHelper.GetNullableString(reader, "Name");

            if (reader.IsColumnExists("USERNAME"))
                item.UserName = SqlHelper.GetNullableString(reader, "USERNAME");

            if (reader.IsColumnExists("Email1"))
                item.EmailId = SqlHelper.GetNullableString(reader, "Email1");

            if (reader.IsColumnExists("Address"))
                item.Address = SqlHelper.GetNullableString(reader, "Address");
             
            return item;
        }

        public static List<UsersModel> TranslateAsUsersList(this SqlDataReader reader)
        {
            var list = new List<UsersModel>();
            while(reader.Read())
            {
                list.Add(TranslateAsUser(reader, true));
            }
            return list;
        }
    }
}
