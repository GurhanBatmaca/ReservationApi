using App.Identity.IdentityServices.Abstract;
using Microsoft.AspNetCore.Identity;
using Shared.Models;

namespace App.Identity.IdentityServices.Concrete
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public string? Message { get ; set; }

        public async Task<bool> CreateAsync(RegisterModel model)
        {

            if(await _userManager!.FindByNameAsync(model.UserName!) != null)
            {
                Message += "This username is already taken,Please choose a different one.";
                return false;
            }
            if(await _userManager.FindByEmailAsync(model.Email!) != null)
            {
                Message += "A user has already been created with this e-mail address.";
                return false;
            }

            return true;
        }
    }
}