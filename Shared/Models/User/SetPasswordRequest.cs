using System.ComponentModel.DataAnnotations;

namespace OptechX.Portal.Shared.Models.User
{
	public class SetPasswordRequest
	{
		[Required(ErrorMessage = "Password reset token required")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Password reset token is 8 characters")]
        public string PasswordResetToken { get; set; } = null!;

        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[a-z])(?=.*\W)[A-Za-z\d\W]{16,100}$",
            ErrorMessage = "Password length required 16-100 characters with at least one uppercase, lowercase, digit, and special character")]
        public string Password { get; set; } = null!;

        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = null!;
    }
}

