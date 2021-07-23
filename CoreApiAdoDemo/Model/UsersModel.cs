using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CoreApiAdoDemo.Model
{
    [DataContract]
    public class UsersModel
    {
        [DataMember(Name = "USER_ID")]
        public int Id { get; set; }

        [DataMember(Name = "USERNAME")]
        public string UserName { get; set; }

        [DataMember(Name = "NAME")]
        public string Name { get; set; }

        [DataMember(Name = "LASTNAME")]
        public string LastName { get; set; }

        [DataMember(Name = "Email1")]
        public string EmailId { get; set; }


        [DataMember(Name = "Password")]
        public string Password { get; set; }

        [DataMember(Name = "Mobile")]
        public string Mobile { get; set; }

        [DataMember(Name = "Address")]
        public string Address { get; set; }

        [DataMember(Name = "IsActive")]
        public bool IsActive { get; set; }
    }
}
