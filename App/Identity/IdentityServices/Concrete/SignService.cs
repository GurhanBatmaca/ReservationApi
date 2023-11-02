using App.Identity.IdentityServices.Abstract;
using Microsoft.AspNetCore.Identity;
using Shared.Models;

namespace App.Identity.IdentityServices.Concrete
{
    public class SignService : ISignService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public SignService(SignInManager<ApplicationUser> signInManager,UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public string? Message { get; set ; }

        public async Task<bool> LoginAsync(LoginModel model)
        {

            var user = await _userManager!.FindByEmailAsync(model.Email!);

            if(user == null)
            {
                Message += "No user found with this email address.";
                return false;
            }

            if(!await _userManager.IsEmailConfirmedAsync(user))
            {
                Message += "Unconfirmed account.Please confirm your account with the link sent to your e-mail address.";
                return false;
            }

            var result = await _userManager.CheckPasswordAsync(user,model.Password!);

            if(!result)
            {
                Message += "Password is incorrect.";
                return false;
            }


            return true;
        }
    }
}