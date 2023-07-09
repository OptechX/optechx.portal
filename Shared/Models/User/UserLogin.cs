using System.ComponentModel.DataAnnotations;

namespace OptechX.Portal.Shared.Models.User
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Valid email address requried"), EmailAddress]
        public string Email { get; set; } = null!;

        [StringLength(32, MinimumLength = 8, ErrorMessage = "Password length between 8-32 characters")]
        public string Password { get; set; } = null!;
    }
}

