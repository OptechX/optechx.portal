using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Stripe
{
    public partial class Datum
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("object")]
        public string? DatumObject { get; set; }

        [JsonPropertyName("amount")]
        public int? Amount { get; set; }

        [JsonPropertyName("amount_excluding_tax")]
        public int? AmountExcludingTax { get; set; }

        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("discount_amounts")]
        public List<object>? DiscountAmounts { get; set; }

        [JsonPropertyName("discountable")]
        public bool Discountable { get; set; }

        [JsonPropertyName("discounts")]
        public List<object>? Discounts { get; set; }

        [JsonPropertyName("livemode")]
        public bool Livemode { get; set; }

        [JsonPropertyName("metadata")]
        public Metadata? Metadata { get; set; }

        [JsonPropertyName("period")]
        public Period? Period { get; set; }

        [JsonPropertyName("plan")]
        public Plan? Plan { get; set; }

        [JsonPropertyName("price")]
        public Price? Price { get; set; }

        [JsonPropertyName("proration")]
        public bool Proration { get; set; }

        [JsonPropertyName("proration_details")]
        public ProrationDetails? ProrationDetails { get; set; }

        [JsonPropertyName("quantity")]
        public int? Quantity { get; set; }

        [JsonPropertyName("subscription")]
        public string? Subscription { get; set; }

        [JsonPropertyName("subscription_item")]
        public string? SubscriptionItem { get; set; }

        [JsonPropertyName("tax_amounts")]
        public List<TaxAmount>? TaxAmounts { get; set; }

        [JsonPropertyName("tax_rates")]
        public List<object>? TaxRates { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("unit_amount_excluding_tax")]
        public string? UnitAmountExcludingTax { get; set; }
    }
}

