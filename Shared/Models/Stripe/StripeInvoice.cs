using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Stripe
{
    public partial class StripeInvoice
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("object")]
        public string? ObjectType { get; set; }

        [JsonPropertyName("api_version")]
        public string? ApiVersion { get; set; }

        [JsonPropertyName("created")]
        public int? Created { get; set; }

        [JsonPropertyName("data")]
        public InvoiceData? Data { get; set; }

        [JsonPropertyName("livemode")]
        public bool Livemode { get; set; }

        [JsonPropertyName("pending_webhooks")]
        public int? PendingWebhooks { get; set; }

        [JsonPropertyName("request")]
        public Request? Request { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}

