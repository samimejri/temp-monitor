using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TempMonitorDAL;

namespace TempMonitorApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TempController : ControllerBase
    {
        private readonly ILogger<TempController> _logger;

        public TempController(ILogger<TempController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public TempMeasure GetCPUTemp()
        {
            return null;
        }

        [HttpGet]
        public IEnumerable<TempMeasure> Get()
        {
            return null;
        }
    }
}
