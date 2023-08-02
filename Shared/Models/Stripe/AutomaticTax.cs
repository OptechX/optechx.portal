using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Stripe
{
    public partial class AutomaticTax
    {
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }
    }
}

