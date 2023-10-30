using Azure;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

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
        [Route("rooms")]

        public async Task<IActionResult> GetRooms(int page=1)
        {       

            var rooms = await _roomService.GetAllRooms(page);      

            if(rooms == null)    
            {
                return BadRequest();
            }

            return Ok(rooms);
        } 

        [HttpPost]
        [Route("rooms/search")]

        public async Task<IActionResult> GetRoomsBySearch([FromBody] RoomFilterModel model,int page=1)
        { 

            var rooms = await _roomService.GetRoomsBySearch(model,page);  

            if(rooms == null)    
            {
                return BadRequest();
            }

            return Ok(rooms);
                         
        }

    }
}