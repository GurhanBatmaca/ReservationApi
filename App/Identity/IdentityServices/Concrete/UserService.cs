using System.Text;
using App.EmailServices.Abstract;
using App.Identity.IdentityServices.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Shared.Models;

namespace App.Identity.IdentityServices.Concrete
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender? _emailSender;
        public UserService(UserManager<ApplicationUser> userManager,IEmailSender? emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
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

            var user = new ApplicationUser()
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user,model.Password!);

            if(!result.Succeeded)
            {
                Message += "Something went wrong.";
                return false;
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var validToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

            await _emailSender!.SendEmailAsync(user.Email!,"Account confirmation.",$"Please click on the link to confirm your account.<p><a href='http://localhost:5197/api/Account/confirmemail/{validToken}&{user.Id}'>Click</a></p>");

            await _userManager.AddToRoleAsync(user,"Customer");

            Message += "User created,Check your e-mail for confirmation.";

            return true;
        }


        
    }
}