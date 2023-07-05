using System.ComponentModel.DataAnnotations;

namespace OptechX.Portal.Shared
{
	public class UserRegister
	{
		[Required, EmailAddress]
		public string Email { get; set; } = null!;

        [StringLength(16, ErrorMessage = "Your username is too long, 16 chars max")]
		public string Username { get; set; } = null!;

        [Required, StringLength(100, MinimumLength = 6)]
		public string Password { get; set; } = null!;

        [Compare("Password", ErrorMessage = "Passwords do not match")]
		public string ConfirmPassword { get; set; } = null!;

        public int StartUnitId { get; set; } = 1;

		[Range(0, 1000, ErrorMessage = "Choose between 0-1000")]
		public int Bananas { get; set; } = 100;

		[Range(typeof(bool), "true", "true", ErrorMessage = "Only confirmed users can play")]
		public bool IsConfirmed { get; set; } = true;
	}
}

