using Business.Abstract;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO.DTOToEntity;
using Shared.Models;

namespace App.Controllers
{

    [ApiController]
    [Route("api/admin")]
    // [Authorize(Roles = "Admin")]
    public class AdminController: ControllerBase
    {

        protected readonly IRoomService _roomService;
        public AdminController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        
        [HttpPost]
        [Route("createroom")]
        public async Task<IActionResult> CreateRoom([FromBody] RoomModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(await _roomService.CreateAsync(model))
            {
                return Ok(_roomService.Message);
            }

            return BadRequest(_roomService.Message);
            
        }


    }
    
}