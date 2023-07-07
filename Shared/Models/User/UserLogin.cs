using System.ComponentModel.DataAnnotations;

namespace OptechX.Portal.Shared.Models.User
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Valid email address requried"), EmailAddress]
        public string Email { get; set; } = null!;

        [StringLength(100, MinimumLength = 16, ErrorMessage = "Password length between 16-100 characters")]
        public string Password { get; set; } = null!;
    }
}

