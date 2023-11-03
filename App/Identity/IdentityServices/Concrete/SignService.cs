using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using App.Identity.IdentityServices.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Shared.Models;

namespace App.Identity.IdentityServices.Concrete
{
    public class SignService : ISignService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        public SignService(SignInManager<ApplicationUser> signInManager,UserManager<ApplicationUser> userManager,IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }
        public string? Message { get; set ; }
        public DateTime? ExpireDate { get; set ; }

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

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>()
            {
                new Claim("Email",model.Password!),
                new Claim(ClaimTypes.NameIdentifier,user.Id)             
            };

            foreach (var role in roles)
            {
                claims.Add( new Claim(ClaimTypes.Role,role) );
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration!["AuthSettings:Key"]!));

            var token = new JwtSecurityToken(
                issuer: _configuration!["AuthSettings:Issuer"],
                audience: _configuration!["AuthSettings:Audince"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key,SecurityAlgorithms.HmacSha256)
            );

            var stringToken = new JwtSecurityTokenHandler().WriteToken(token);
            Message += stringToken;
            ExpireDate = token.ValidTo;

            return true;
        }
    }
}