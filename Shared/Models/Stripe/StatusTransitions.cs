using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Stripe
{
    public partial class StatusTransitions
    {
        [JsonPropertyName("finalized_at")]
        public int? FinalizedAt { get; set; }

        [JsonPropertyName("marked_uncollectible_at")]
        public int? MarkedUncollectibleAt { get; set; }

        [JsonPropertyName("paid_at")]
        public int? PaidAt { get; set; }

        [JsonPropertyName("voided_at")]
        public int? VoidedAt { get; set; }
    }
}

