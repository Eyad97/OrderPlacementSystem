using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderPlacementSystem.Models.Outputs;
using OrderPlacementSystem.Helpers;

namespace OrderPlacementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private ServiceHelper _serviceHelper;

        public ServiceController() => _serviceHelper = new ServiceHelper();

        [HttpGet("GetAllServices")]
        public ResultOutput GetAllServices()
        {
            return _serviceHelper.GetAllServices();
        }
    }
}
