using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestProject.Models.Request;
using TestProject.Services;
using TestProject.Services.Models;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarageController: ControllerBase
    {
        private readonly IGarageService _garageService;
        public GarageController(IGarageService garageService)
        {
            _garageService = garageService;
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> Get([FromRoute]long id)
        {
            Garage garage = await _garageService.GetAsync(id);

            if (garage == null)
                return NotFound();

            return Ok(garage);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateGarageModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var garage = Mapper.Map<Garage>(model);
            var newGarage = await _garageService.CreateAsync(garage);

            if (newGarage == null)
                return BadRequest();

            return Ok(newGarage);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody]UpdateGarageModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var garage = Mapper.Map<Garage>(model);
            var updated = await _garageService.UpdateAsync(garage);

            if (!updated)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute]long id)
        {
            var deleted = await _garageService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return Ok();
        }
    }
}
