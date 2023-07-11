using System.ComponentModel.DataAnnotations;

namespace OptechX.Portal.Shared.Models.User
{
    public class UserRegister
    {
        [Required(ErrorMessage = "Valid email address required"), EmailAddress]
        public string Email { get; set; } = null!;

        //[RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[a-z])(?=.*\W)[A-Za-z\d\W]{8,32}$",
        //    ErrorMessage = "Password length required 8-32 characters with at least one uppercase, lowercase, digit, and special character")]
        [RegularExpression(@"^.{8,32}$",
            ErrorMessage = "Password length must be between 6 and 32 characters")]
        public string Password { get; set; } = null!;

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "Select country from list")]
        public string Country { get; set; } = null!;

        [Range(typeof(bool), "true", "true", ErrorMessage = "Must accept Terms & Conditions")]
        public bool IsConfirmed { get; set; } = false;
    }
}

