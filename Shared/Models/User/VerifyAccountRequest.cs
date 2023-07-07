using System.ComponentModel.DataAnnotations;

namespace OptechX.Portal.Shared.Models.User
{
	public class VerifyAccountRequest
	{
		[Required]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Token is 8 characters")]
        public string VerifyToken { get; set; } = null!;
	}
}

