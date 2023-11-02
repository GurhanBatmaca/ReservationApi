using App.Identity.IdentityServices.Abstract;
using Microsoft.AspNetCore.Mvc;

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
    }
}