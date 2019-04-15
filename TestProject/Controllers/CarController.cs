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
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> Get([FromRoute]long id)
        {
            var car = await _carService.GetAsync(id);

            if (car == null)
                return NotFound();

            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateCarModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var car = Mapper.Map<Car>(model);
            var newCar = await _carService.CreateAsync(car);

            if (newCar == null)
                return BadRequest();

            return Ok(newCar);
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody]UpdateCarModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var car = Mapper.Map<Car>(model);
            var updated = await _carService.UpdateAsync(car);

            if (!updated)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute]long id)
        {
            var deleted = await _carService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return Ok();
        }
    }
}