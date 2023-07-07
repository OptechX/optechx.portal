using System.ComponentModel.DataAnnotations;

namespace OptechX.Portal.Shared.Models.User
{
	public class ResetPasswordRequest
	{
		[Required(ErrorMessage = "Required for password reset")]
		[EmailAddress(ErrorMessage = "Must be valid email address")]
		public string ResetEmailAddress { get; set; } = null!;
	}
}

