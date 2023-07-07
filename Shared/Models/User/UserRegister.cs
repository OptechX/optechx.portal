using System.ComponentModel.DataAnnotations;

namespace OptechX.Portal.Shared.Models.User
{
    public class UserRegister
    {
        [Required(ErrorMessage = "Valid email address requried"), EmailAddress]
        public string Email { get; set; } = null!;

        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[a-z])(?=.*\W)[A-Za-z\d\W]{16,100}$",
            ErrorMessage = "Password length required 16-100 characters with at least one uppercase, lowercase, digit, and special character")]
        public string Password { get; set; } = null!;

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "Select country from list")]
        public string Country { get; set; } = null!;

        [Range(typeof(bool), "true", "true", ErrorMessage = "Must accept Terms & Conditions")]
        public bool IsConfirmed { get; set; } = false;
    }
}

