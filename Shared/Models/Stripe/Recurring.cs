using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Stripe
{
    public partial class Recurring
    {
        [JsonPropertyName("aggregate_usage")]
        public object? AggregateUsage { get; set; }

        [JsonPropertyName("interval")]
        public string? Interval { get; set; }

        [JsonPropertyName("interval_count")]
        public int? IntervalCount { get; set; }

        [JsonPropertyName("trial_period_days")]
        public object? TrialPeriodDays { get; set; }

        [JsonPropertyName("usage_type")]
        public string? UsageType { get; set; }
    }
}

