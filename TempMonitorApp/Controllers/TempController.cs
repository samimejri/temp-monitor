using System.Collections.Generic;
using System.IO;
using LiteDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TempMonitorDAL;
using Microsoft.AspNetCore.SignalR;

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
        public IEnumerable<TempMeasure> Get()
        {
            DBLiteDatabaseManager dbManager = DBLiteDatabaseManager.GetInstance($"{Path.GetTempPath()}\\TempMonitor\\TempMonitor.db");
            List<TempMeasure> temps = new List<TempMeasure>();

            temps.Add(dbManager.CPUTempMeasures.FindOne(Query.All(Query.Descending)));
            temps.Add(dbManager.GPUTempMeasures.FindOne(Query.All(Query.Descending)));

            return temps;
        }
    }
}
