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
        [Route("rooms/{city}")]

        public async Task<IActionResult> GetRoomsByCity(string city,int page=1)
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

        [HttpGet]
        [Route("rooms/filter")]

        public async Task<IActionResult> GetRoomsByFilter(string? city,int minPrice,int maxPrice,int page=1)
        {   

            var rooms = await _roomService.GetRoomsByFilter(city,minPrice,maxPrice,page);        

            return Ok(rooms);
        }

        [HttpPost]
        [Route("rooms/search")]

        // public async Task<IActionResult> GetRoomsByModel(string? city,int minPrice,int maxPrice,DateTime inTime,DateTime outTime,int page=1)
        // {   

        public async Task<IActionResult> GetRoomsByModel([FromBody] RoomFilterModel model,int page=1)
        { 

            var rooms = await _roomService.GetRoomsByModel(model,page);  

            return Ok(rooms);
              

            
        }

    }
}