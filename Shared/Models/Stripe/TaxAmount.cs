using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Stripe
{
    public partial class TaxAmount
    {
        [JsonPropertyName("amount")]
        public int? Amount { get; set; }

        [JsonPropertyName("inclusive")]
        public bool Inclusive { get; set; }

        [JsonPropertyName("tax_rate")]
        public string? TaxRate { get; set; }

        [JsonPropertyName("taxability_reason")]
        public string? TaxabilityReason { get; set; }

        [JsonPropertyName("taxable_amount")]
        public int? TaxableAmount { get; set; }
    }
}

