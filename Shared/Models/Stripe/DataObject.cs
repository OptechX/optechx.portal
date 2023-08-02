using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Stripe
{
    public partial class DataObject
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("object")]
        public string? ObjectType { get; set; }

        [JsonPropertyName("account_country")]
        public string? AccountCountry { get; set; }

        [JsonPropertyName("account_name")]
        public string? AccountName { get; set; }

        [JsonPropertyName("account_tax_ids")]
        public List<AccountTaxId>? AccountTaxIds { get; set; }

        [JsonPropertyName("amount_due")]
        public int? AmountDue { get; set; }

        [JsonPropertyName("amount_paid")]
        public int? AmountPaid { get; set; }

        [JsonPropertyName("amount_remaining")]
        public int? AmountRemaining { get; set; }

        [JsonPropertyName("amount_shipping")]
        public int? AmountShipping { get; set; }

        [JsonPropertyName("application")]
        public object? Application { get; set; }

        [JsonPropertyName("application_fee_amount")]
        public int? ApplicationFeeAmount { get; set; }

        [JsonPropertyName("attempt_count")]
        public int? AttemptCount { get; set; }

        [JsonPropertyName("attempted")]
        public bool Attempted { get; set; }

        [JsonPropertyName("auto_advance")]
        public bool AutoAdvance { get; set; }

        [JsonPropertyName("automatic_tax")]
        public AutomaticTax? AutomaticTax { get; set; }

        [JsonPropertyName("billing_reason")]
        public string? BillingReason { get; set; }

        [JsonPropertyName("charge")]
        public string? Charge { get; set; }

        [JsonPropertyName("collection_method")]
        public string? CollectionMethod { get; set; }

        [JsonPropertyName("created")]
        public int? Created { get; set; }

        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        [JsonPropertyName("custom_fields")]
        public object? CustomFields { get; set; }

        [JsonPropertyName("customer")]
        public string? Customer { get; set; }

        [JsonPropertyName("customer_address")]
        public CustomerAddress? CustomerAddress { get; set; }

        [JsonPropertyName("customer_email")]
        public string? CustomerEmail { get; set; }

        [JsonPropertyName("customer_name")]
        public string? CustomerName { get; set; }

        [JsonPropertyName("customer_phone")]
        public string? CustomerPhone { get; set; }

        [JsonPropertyName("customer_shipping")]
        public object? CustomerShipping { get; set; }

        [JsonPropertyName("customer_tax_exempt")]
        public string? CustomerTaxExempt { get; set; }

        [JsonPropertyName("customer_tax_ids")]
        public List<CustomerTaxId>? CustomerTaxIds { get; set; }

        [JsonPropertyName("default_payment_method")]
        public object? DefaultPaymentMethod { get; set; }

        [JsonPropertyName("default_source")]
        public object? DefaultSource { get; set; }

        [JsonPropertyName("default_tax_rates")]
        public List<object>? DefaultTaxRates { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("discount")]
        public object? Discount { get; set; }

        [JsonPropertyName("discounts")]
        public List<object>? Discounts { get; set; }

        [JsonPropertyName("due_date")]
        public int? DueDate { get; set; }

        [JsonPropertyName("effective_at")]
        public int? EffectiveAt { get; set; }

        [JsonPropertyName("ending_balance")]
        public int? EndingBalance { get; set; }

        [JsonPropertyName("footer")]
        public string? Footer { get; set; }

        [JsonPropertyName("from_invoice")]
        public object? FromInvoice { get; set; }

        [JsonPropertyName("hosted_invoice_url")]
        public string? HostedInvoiceUrl { get; set; }

        [JsonPropertyName("invoice_pdf")]
        public string? InvoicePdf { get; set; }

        [JsonPropertyName("last_finalization_error")]
        public object? LastFinalizationError { get; set; }

        [JsonPropertyName("latest_revision")]
        public object? LatestRevision { get; set; }

        [JsonPropertyName("lines")]
        public Lines? Lines { get; set; }

        [JsonPropertyName("livemode")]
        public bool Livemode { get; set; }

        [JsonPropertyName("metadata")]
        public Metadata? Metadata { get; set; }

        [JsonPropertyName("next_payment_attempt")]
        public int? NextPaymentAttempt { get; set; }

        [JsonPropertyName("number")]
        public string? Number { get; set; }

        [JsonPropertyName("on_behalf_of")]
        public object? OnBehalfOf { get; set; }

        [JsonPropertyName("paid")]
        public bool Paid { get; set; }

        [JsonPropertyName("paid_out_of_band")]
        public bool PaidOutOfBand { get; set; }

        [JsonPropertyName("payment_intent")]
        public string? PaymentIntent { get; set; }

        [JsonPropertyName("payment_settings")]
        public PaymentSettings? PaymentSettings { get; set; }

        [JsonPropertyName("period_end")]
        public int? PeriodEnd { get; set; }

        [JsonPropertyName("period_start")]
        public int? PeriodStart { get; set; }

        [JsonPropertyName("post_payment_credit_notes_amount")]
        public int? PostPaymentCreditNotesAmount { get; set; }

        [JsonPropertyName("pre_payment_credit_notes_amount")]
        public int? PrePaymentCreditNotesAmount { get; set; }

        [JsonPropertyName("quote")]
        public object? Quote { get; set; }

        [JsonPropertyName("receipt_number")]
        public string? ReceiptNumber { get; set; }

        [JsonPropertyName("rendering_options")]
        public object? RenderingOptions { get; set; }

        [JsonPropertyName("shipping_cost")]
        public object? ShippingCost { get; set; }

        [JsonPropertyName("shipping_details")]
        public object? ShippingDetails { get; set; }

        [JsonPropertyName("starting_balance")]
        public int? StartingBalance { get; set; }

        [JsonPropertyName("statement_descriptor")]
        public string? StatementDescriptor { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("status_transitions")]
        public StatusTransitions? StatusTransitions { get; set; }

        [JsonPropertyName("subscription")]
        public string? Subscription { get; set; }

        [JsonPropertyName("subtotal")]
        public int? Subtotal { get; set; }

        [JsonPropertyName("subtotal_excluding_tax")]
        public int? SubtotalExcludingTax { get; set; }

        [JsonPropertyName("tax")]
        public int? Tax { get; set; }

        [JsonPropertyName("test_clock")]
        public object? TestClock { get; set; }

        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("total_discount_amounts")]
        public List<object>? TotalDiscountAmounts { get; set; }

        [JsonPropertyName("total_excluding_tax")]
        public int? TotalExcludingTax { get; set; }

        [JsonPropertyName("total_tax_amounts")]
        public List<TaxAmount>? TotalTaxAmounts { get; set; }

        [JsonPropertyName("transfer_data")]
        public object? TransferData { get; set; }

        [JsonPropertyName("webhooks_delivered_at")]
        public object? WebhooksDeliveredAt { get; set; }
    }
}

