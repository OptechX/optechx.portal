namespace OptechX.Portal.Shared.Models.User
{
    public class UserData
    {
        public string Id { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string? Company { get; set; }
        public string? TaxId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? UserIcon { get; set; }
    }
}

//public Role Role { get; set; }

//public EnterpriseAgreement? EnterpriseAgreement { get; set; }
//public string? MicrosoftEnterpriseAgreementNumber { get; set; }

//public BillingType BillingType { get; set; }
//public AccountTier AccountTier { get; set; }

//public int ImagesRemaining { get; set; }
//public int AppLockerStorageAvailable { get; set; }
//public int AppLockerStorageUsed { get; set; }

//public bool AccountNotifications { get; set; }

//public StripeSubscriptionDetail? StripeSubscriptionDetail { get; set; }