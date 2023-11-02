using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class RegisterModel
    {
        [Required]
        [StringLength(15,MinimumLength =3)]
        public string? UserName { get; set; }

        [Required]
        [StringLength(20,MinimumLength =2)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(20,MinimumLength =2)]
        public string? LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}