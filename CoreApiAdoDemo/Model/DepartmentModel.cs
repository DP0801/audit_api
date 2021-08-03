using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CoreApiAdoDemo.Model
{
    [DataContract]
    public class DepartmentModel
    {
        [DataMember(Name = "DepartmentId")]
        public int Id { get; set; }

        [DataMember(Name = "CompanyId")]
        public int CompanyId { get; set; }
         
        [DataMember(Name = "Code")]
        public string Code { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Description")]
        public string Description { get; set; }

        [DataMember(Name = "COMPANYNAME")]
        public string CompanyName { get; set; }
    }
}
