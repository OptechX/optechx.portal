using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Stripe
{
    public partial class PaymentSettings
    {
        [JsonPropertyName("default_mandate")]
        public string? DefaultMandate { get; set; }

        [JsonPropertyName("payment_method_options")]
        public object? PaymentMethodOptions { get; set; }

        [JsonPropertyName("payment_method_types")]
        public List<string>? PaymentMethodTypes { get; set; }
    }
}

