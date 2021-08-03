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
    [Route("api/Department")]
    [EnableCors("MyPolicy")]
    public class DepartmentController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;

        public DepartmentController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
        }


        [HttpGet]
        [Route("GetAllDeparments")]
        public IActionResult GetAllDeparments()
        {
            var data = DbClientFactory<DepartmentDbClient>.Instance.GetAllDepartments(appSettings.Value.DbConn, "ALL");
            return Ok(data);
        }
    }
}