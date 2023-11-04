using Azure;
using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
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
        [Route("rooms/details/{id}")]

        public async Task<IActionResult> Room(int id)
        {       

            var entity = await _roomService.GetByIdAsync(id);
            if(entity == null)    
            {
                return BadRequest(new {error = "Room not found."});
            }

            var roomDTO = await _roomService.GetRoomDetails(id);

            return Ok(roomDTO);
        }

        [HttpGet]
        [Route("rooms")]

        public async Task<IActionResult> Rooms(int page=1)
        {       

            var roomListDTO = await _roomService.GetAllRooms(page);      

            if(roomListDTO == null)    
            {
                return BadRequest();
            }

            if(roomListDTO.Rooms!.Count == 0)
            {
                return NoContent();
            }

            return Ok(roomListDTO);
        } 

        [HttpPost]
        [Route("rooms/search")]

        public async Task<IActionResult> RoomsBySearch([FromBody] RoomFilterModel model,int page=1)
        { 

            var roomListDTO = await _roomService.GetRoomsBySearch(model,page);  

            if(roomListDTO == null)    
            {
                return BadRequest();
            }
            if(roomListDTO.Rooms!.Count == 0)
            {
                return NoContent();
            }

            return Ok(roomListDTO);
                         
        }

    }
}