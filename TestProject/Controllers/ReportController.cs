using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TestProject.Models.Request;
using TestProject.Services;
using TestProject.Services.Models;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("areas")]
        public ActionResult<List<Area>> GetAllAreas()
        {
            var areas = _reportService.GetAreas();

            if (areas == null)
                return NotFound();

            return Ok(areas);
        }

        [HttpGet("reports/{id:long}")]
        public ActionResult<Dictionary<string, List<Report>>> Get([FromRoute]long id)
        {
            var reports = _reportService.GetReportsByArea(id);

            if (reports == null)
                return NotFound();

            return Ok(reports);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateReportModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var report = Mapper.Map<Report>(model);
            var newReport = await _reportService.CreateAsync(report);

            if (newReport == null)
                return BadRequest();

            return Ok(newReport);
        }
    }
}
