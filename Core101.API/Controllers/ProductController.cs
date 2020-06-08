using Core101.Model.Entity;
using Core101.Service;
using Microsoft.AspNetCore.Mvc;

namespace Core101.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        Core101ServiceFactory _service;
        public ProductController(Core101ServiceFactory service)
        {
            _service = service;
        }
        [HttpGet]
        public Product Get()
        {
            var getalldata = _service.Product().GetAllData();
            return getalldata;
        }
    }
}