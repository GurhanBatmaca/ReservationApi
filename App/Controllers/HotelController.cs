using Business.Abstract;
using Entity;
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
            

            return Ok();
        }

        [HttpGet]
        [Route("homepagehotels")]

        public async Task<IActionResult> HomePageHotels(int page=1)
        {
            var hotels = await _hotelService.GetHomePageHotels(page);
            
            if(hotels == null)
            {
                return BadRequest();
            }

            return Ok(hotels);
        }
    }
}