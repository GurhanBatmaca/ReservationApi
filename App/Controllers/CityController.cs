using Business.Abstract;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CityController: ControllerBase
    {
        protected readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        [Route("cities")]
        public async Task<IActionResult> Cities()
        {
            var cities = await _cityService.GetAllAync();

            return Ok(cities);
        }
    }
}