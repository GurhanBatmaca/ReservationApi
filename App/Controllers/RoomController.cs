using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{

    [ApiController]
    [Route("api/")]
    public class RoomController: ControllerBase
    {        
        protected readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        [Route("rooms/{city}")]

        public async Task<IActionResult> GetRoomByCity(string city,int page=1)
        {
            if(string.IsNullOrEmpty(city))
            {
                return BadRequest();
            }
            var rooms = await _roomService.GetRoomsByCity(city,page);

            if(rooms == null)
            {
                return BadRequest();
            }

            return Ok(rooms);
        }

    }
}