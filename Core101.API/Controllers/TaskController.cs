using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core101.Model.RequestModel;
using Core101.Model.ResponseModel;
using Core101.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core101.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private Core101ServiceFactory _service;
        public TaskController(Core101ServiceFactory service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post(TaskRequestModel requestModel)
        {
            var result = _service.Task().InsertDataTask(requestModel);
            return Ok(result);
        }
    }
}
