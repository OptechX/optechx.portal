using OptechX.Portal.Shared.Models.User.Constants;

namespace OptechX.Portal.Shared.Models.User
{
	public class UserLoginResponse
	{
        public string JWT { get; set; } = null!;
        public string Id { get; set; } = null!;
        public string? Company { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? UserIcon { get; set; }

        public string? BillingType { get; set; }
        public string? AccountTier { get; set; }

        public int ImagesRemaining { get; set; }
        public int AppLockerStorageAvailable { get; set; }
        public int AppLockerStorageUsed { get; set; }

        public bool AccountNotifications { get; set; }
    }
}

