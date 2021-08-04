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

        [HttpPost]
        [Route("SaveDepartment")]
        public IActionResult SaveDepartment([FromBody]DepartmentModel model)
        {
            var msg = new Message<DepartmentModel>();
            var data = DbClientFactory<DepartmentDbClient>.Instance.SaveDepartment(model, appSettings.Value.DbConn);
            if (data != "")
            {
                msg.IsSuccess = true;
                if (model.Id == 0)
                    msg.ReturnMessage = "Department saved successfully";
                else
                    msg.ReturnMessage = "Department updated successfully";
            }

            return Ok(msg);
        }

        [HttpPost]
        [Route("UpdateDepartment")]
        public IActionResult UpdateDepartment([FromBody]DepartmentModel model)
        {
            var msg = new Message<DepartmentModel>();
            var data = DbClientFactory<DepartmentDbClient>.Instance.UpdateDepartment(model, appSettings.Value.DbConn);
            if (data != "")
            {
                msg.IsSuccess = true; 
                msg.ReturnMessage = "Department updated successfully";
            }

            return Ok(msg);
        }

        [HttpDelete]
        [Route("DeleteDeparment")]
        public IActionResult DeleteDeparment([FromBody]DepartmentModel model)
        {
            var msg = new Message<DepartmentModel>();
            var data = DbClientFactory<DepartmentDbClient>.Instance.DeleteDepartment(model.Id, appSettings.Value.DbConn);
            if (data != "")
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Department Deleted";
            }

            return Ok(msg);
        }
    }
}