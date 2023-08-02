using OptechX.Portal.Shared.Models.User.Constants;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.User
{
    public class StripeSubscriptionDetail
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public Guid UserAccountId { get; set; }

        public string SubscriptionId { get; set; } = null!;
        public string? StripeCustomerId { get; set; }
        public string? StripeProductId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Expires { get; set; }
        public int ServiceLevelResponseMinutes { get; set; }
        public AccountTier AccountTier { get; set; }
        public int ImagesRemaining { get; set; }
        public int AppLockerStorageAvailable { get; set; }
        public string SubscriptionName { get; set; } = null!;

        public StripeSubscriptionDetail()
        {
            UserAccountId = Guid.Empty;
            AccountTier = AccountTier.BASIC;
        }
    }
}

