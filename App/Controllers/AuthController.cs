using App.Identity.IdentityServices.Abstract;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace App.Controllers
{
    [ApiController]
    [Route("api/")]
    public class AuthController: ControllerBase
    {
        protected readonly IUserService _userService;
        protected readonly ISignService _signService;
        public AuthController(IUserService userService,ISignService signService)
        {
            _userService = userService;
            _signService = signService;
        }

        [HttpPost]
        [Route("auth/register")]

        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if(await _userService.CreateAsync(model))
            {
                return Ok(new { message = _userService.Message });
            }

            return BadRequest(new { error = _userService.Message });
        }
    }
}