using System.ComponentModel.DataAnnotations;

namespace OptechX.Portal.Shared
{
	public class UserLogin
	{
		[Required(ErrorMessage = "Username or email is required")]
		public string Username { get; set; } = null!;

		[Required(ErrorMessage = "Password is required")]
		public string Password { get; set; } = null!;
	}
}

