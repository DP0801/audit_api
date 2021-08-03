using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiAdoDemo.Model;
using CoreApiAdoDemo.Repository;
using CoreApiAdoDemo.Utility;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CoreApiAdoDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/JobPosition")]
    [EnableCors("MyPolicy")]
    public class JobPositionController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;

        public JobPositionController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
        }


        [HttpGet]
        [Route("GetAllJobPositions")]
        public IActionResult GetAllJobPositions()
        {
            var data = DbClientFactory<JobPositionDbClient>.Instance.GetAllJobPositions(appSettings.Value.DbConn, "ALL");
            return Ok(data);
        }
    }
}