using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Stripe
{
    public partial class Price
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("object")]
        public string? ObjectType { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("billing_scheme")]
        public string? BillingScheme { get; set; }

        [JsonPropertyName("created")]
        public int? Created { get; set; }

        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        [JsonPropertyName("custom_unit_amount")]
        public object? CustomUnitAmount { get; set; }

        [JsonPropertyName("livemode")]
        public bool Livemode { get; set; }

        [JsonPropertyName("lookup_key")]
        public object? LookupKey { get; set; }

        [JsonPropertyName("metadata")]
        public Metadata? Metadata { get; set; }

        [JsonPropertyName("nickname")]
        public object? Nickname { get; set; }

        [JsonPropertyName("product")]
        public string? Product { get; set; }

        [JsonPropertyName("recurring")]
        public Recurring? Recurring { get; set; }

        [JsonPropertyName("tax_behavior")]
        public string? TaxBehavior { get; set; }

        [JsonPropertyName("tiers_mode")]
        public object? TiersMode { get; set; }

        [JsonPropertyName("transform_quantity")]
        public object? TransformQuantity { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("unit_amount")]
        public int? UnitAmount { get; set; }

        [JsonPropertyName("unit_amount_decimal")]
        public string? UnitAmountDecimal { get; set; }
    }
}

