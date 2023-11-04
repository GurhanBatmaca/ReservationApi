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
            var cityListDTO = await _cityService.GetAllAync();

            if(cityListDTO == null)
            {
                return BadRequest();
            }
            if(cityListDTO.Cities!.Count == 0)
            {
                return NoContent();
            }

            return Ok(cityListDTO);
        }
    }
}