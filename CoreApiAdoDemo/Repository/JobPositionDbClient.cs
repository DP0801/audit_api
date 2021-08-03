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
    public class JobPositionDbClient
    {
        public List<JobPositionModel> GetAllJobPositions(string connString, string action)
        {
            SqlParameter[] param = {
                new SqlParameter("@ACTION", action),
                new SqlParameter("@JOBPOSITIONID", 0)
            };
            return SqlHelper.ExtecuteProcedureReturnData<List<JobPositionModel>>(connString,
                "SP_145_JobPosition_Get", r => r.TranslateAsJobPositionList(), param);
        }
    }
}
