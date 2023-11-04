using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("api/")]
    public class HotelController: ControllerBase
    {
        protected readonly IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        [Route("hotels")]

        public async Task<IActionResult> Hotels(int page=1)
        {

            var hotelListDTO = await _hotelService.GetAllHotels(page);
            
            if(hotelListDTO == null)
            {
                return BadRequest();
            }
            if(hotelListDTO.Hotels!.Count == 0)
            {
                return NoContent();
            }

            return Ok(hotelListDTO);
        }

        [HttpGet]
        [Route("homepagehotels")]

        public async Task<IActionResult> HomePageHotels(int page=1)
        {
            var hotelListDTO = await _hotelService.GetHomePageHotels(page);
            
            if(hotelListDTO == null)
            {
                return BadRequest();
            }
            if(hotelListDTO.Hotels!.Count == 0)
            {
                return NoContent();
            }

            return Ok(hotelListDTO);
        }
    }
}