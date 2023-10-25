using Business.Abstract;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class HotelController: ControllerBase
    {
        protected readonly IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        [Route("hotels")]

        public async Task<IActionResult> GetHotel(int page=1)
        {
            var pageSize = 3;

            var hotels = await _hotelService.GetHomePageHotels(page,pageSize);

            return Ok(hotels);
        }
    }
}