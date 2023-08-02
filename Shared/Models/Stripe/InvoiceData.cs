using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Stripe
{
    public partial class InvoiceData
    {
        [JsonPropertyName("object")]
        public DataObject? ObjectData { get; set; }
    }
}

