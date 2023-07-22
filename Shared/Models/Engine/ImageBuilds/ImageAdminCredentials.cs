using System.ComponentModel.DataAnnotations;

namespace OptechX.Portal.Shared.Models.Engine.ImageBuilds
{
	public class ImageAdminCredentials
	{
        [Required, RegularExpression(@"^.{1,20}$",
            ErrorMessage = "Admin username length must be between 1 and 20 characters")]
        public string DefaultAccount { get; set; } = null!;

        [Required, RegularExpression(@"^.{8,32}$",
            ErrorMessage = "Password length must be between 6 and 32 characters")]
        public string DefaultPassword { get; set; } = null!;
    }
}

