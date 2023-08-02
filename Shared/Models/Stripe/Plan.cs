using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Stripe
{
    public partial class Plan
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("object")]
        public string? ObjectType { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("aggregate_usage")]
        public object? AggregateUsage { get; set; }

        [JsonPropertyName("amount")]
        public int? Amount { get; set; }

        [JsonPropertyName("amount_decimal")]
        public string? AmountDecimal { get; set; }

        [JsonPropertyName("billing_scheme")]
        public string? BillingScheme { get; set; }

        [JsonPropertyName("created")]
        public int? Created { get; set; }

        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        [JsonPropertyName("interval")]
        public string? Interval { get; set; }

        [JsonPropertyName("interval_count")]
        public int? IntervalCount { get; set; }

        [JsonPropertyName("livemode")]
        public bool Livemode { get; set; }

        [JsonPropertyName("metadata")]
        public Metadata? Metadata { get; set; }

        [JsonPropertyName("nickname")]
        public object? Nickname { get; set; }

        [JsonPropertyName("product")]
        public string? Product { get; set; }

        [JsonPropertyName("tiers_mode")]
        public object? TiersMode { get; set; }

        [JsonPropertyName("transform_usage")]
        public object? TransformUsage { get; set; }

        [JsonPropertyName("trial_period_days")]
        public object? TrialPeriodDays { get; set; }

        [JsonPropertyName("usage_type")]
        public string? UsageType { get; set; }
    }
}

