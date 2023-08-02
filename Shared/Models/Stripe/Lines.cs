using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Stripe
{
    public partial class Lines
    {
        [JsonPropertyName("object")]
        public string? LinesObject { get; set; }

        [JsonPropertyName("data")]
        public List<Datum>? Data { get; set; }

        [JsonPropertyName("has_more")]
        public bool HasMore { get; set; }

        [JsonPropertyName("total_count")]
        public int? TotalCount { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}

