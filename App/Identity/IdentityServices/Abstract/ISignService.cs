using Shared.Models;

namespace App.Identity.IdentityServices.Abstract
{
    public interface ISignService
    {
        Task<bool> LoginAsync(LoginModel model);
        public string? Message { get; set; }
        public DateTime? ExpireDate { get; set ; }
    }
}