using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.User.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SubscriptionCycle
    {
        [EnumMember(Value = "Monthly")]
        MONTHLY,
        [EnumMember(Value = "Bi-Monthly")]
        BI_MONTHLY,
        [EnumMember(Value = "Quarterly")]
        QUARTERLY,
        [EnumMember(Value = "Semi-Annual")]
        SEMI_ANNUAL,
        [EnumMember(Value = "Annual")]
        ANNUAL
    }
}

