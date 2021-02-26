using BusinessLogic.IServices;
using Core.CustomEntity.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerBiController : Controller
    {
        IPowerBiService _powerBiService;
        public PowerBiController(IPowerBiService powerBiService)
        {
            _powerBiService = powerBiService;
        }

        /// <summary>
        /// Get report
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("getreport")]
        public IActionResult GetReport([FromBody] PowerBiReportRequest request)
        {
            var response = _powerBiService.GetReportInfo(request);

            if(!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
