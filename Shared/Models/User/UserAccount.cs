using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using OptechX.Portal.Shared.Models.User.Constants;

namespace OptechX.Portal.Shared.Models.User
{
    public class UserAccount
    {
        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }  // Change the type to Guid
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;
        public string? Password { get; set; }  // password is optional, in case it's created from Stripe directly
        public string? Password2 { get; set; }  // salt
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
        public bool IsAcceptTerms { get; set; }
        public Role Role { get; set; }
        public string? VerificationToken { get; set; }
        public DateTime? Verified { get; set; }
        public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;  // determines whether the user account is considered verified based on the presence of a value in either the Verified or PasswordReset property
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? PasswordReset { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public EnterpriseAgreement? EnterpriseAgreement { get; set; }
        public string? MicrosoftEnterpriseAgreementNumber { get; set; }

        public BillingType BillingType { get; set; }
        public AccountTier AccountTier { get; set; }

        public int ImagesRemaining { get; set; }
        public int AppLockerStorageAvailable { get; set; }
        public int AppLockerStorageUsed { get; set; }

        public bool AccountNotifications { get; set; }

        public StripeSubscriptionDetail? StripeSubscriptionDetail { get; set; }

        public DateTime? SubscriptionStartDate { get; set; }
        public DateTime? SubscriptionExpireDate { get; set; }

        public UserAccount()
        {
            IsAcceptTerms = true;
            Role = Role.USER;
            BillingType = BillingType.NONE;
            AccountTier = AccountTier.BASIC;
            ImagesRemaining = 0;
            AppLockerStorageAvailable = 0;
            AppLockerStorageUsed = 0;
            Created = DateTime.UtcNow;
        }
    }
}

