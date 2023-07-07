using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.User.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BillingType
    {
        [EnumMember(Value = "None")]
        NONE,
        [EnumMember(Value = "Stripe")]
        STRIPE,
        [EnumMember(Value = "PayPal")]
        PAYPAL,
        [EnumMember(Value = "Direct Debit")]
        DIRECTDEBIT,
        [EnumMember(Value = "7 Day Account")]
        ACCOUNT_7_DAYS,
        [EnumMember(Value = "14 Day Account")]
        ACCOUNT_14_DAYS,
        [EnumMember(Value = "30 Day Account")]
        ACCOUNT_30_DAYS,
        [EnumMember(Value = "Invoice")]
        INVOICE,
        [EnumMember(Value = "Gratis Service")]
        GRATIS,
        [EnumMember(Value = "Trial")]
        TRIAL
    }
}

