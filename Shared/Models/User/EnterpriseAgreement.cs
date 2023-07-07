using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using OptechX.Portal.Shared.Models.User.Constants;

namespace OptechX.Portal.Shared.Models.User
{
    public class EnterpriseAgreement
    {
        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }  // unique identifier of the agreement

        public ContractStatus ContractStatus { get; set; }

        [Required]
        public string? AgreementTitle { get; set; }  // title or name of the agreement

        public DateTime Generated { get; set; }
        public DateTime? LastUpdated { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Guid UserAccountId { get; set; } = Guid.Empty;

        [NotMapped]
        public List<string>? IncludedServices { get; set; } = new List<string>();

        [NotMapped]
        public List<string>? TermsAndConditions { get; set; } = new List<string>();

        public AccountTier AccountTier { get; set; }

        public SubscriptionCycle SubscriptionCycle { get; set; }

        public BillingType BillingType { get; set; }

        public GoverningLawType GoverningLaw { get; set; }

        public string? SignedBy { get; set; }

        public DateTime? Executed { get; set; }

        public string? DocumentUploadUrl { get; set; }

        public EnterpriseAgreement()
        {
            Generated = DateTime.Today;
            ContractStatus = ContractStatus.PREPARATION;
            AccountTier = AccountTier.OTHER;
            SubscriptionCycle = SubscriptionCycle.ANNUAL;
            BillingType = BillingType.NONE;
            GoverningLaw = GoverningLawType.NSW;
        }
    }
}

