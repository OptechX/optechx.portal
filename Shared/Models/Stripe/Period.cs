using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Stripe
{
    public partial class Period
    {
        [JsonPropertyName("end")]
        public int? End { get; set; }

        [JsonPropertyName("start")]
        public int? Start { get; set; }
    }
}

