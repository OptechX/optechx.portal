using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.User.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AccountTier
    {
        /// <summary>
        /// OptechX Free Plan
        /// </summary>
        [EnumMember(Value = "Basic")]
        BASIC,

        /// <summary>
        /// OptechX Small Plan
        /// </summary>
        [EnumMember(Value = "Power User")]
        POWER_USER,

        /// <summary>
        /// OptechX Medium Plan
        /// </summary>
        [EnumMember(Value = "Professional")]
        PROFESSIONAL,

        /// <summary>
        /// OptechX Large Plan
        /// </summary>
        [EnumMember(Value = "SMB")]
        SMB,

        /// <summary>
        /// OptechX Enterprise Plan
        /// </summary>
        [EnumMember(Value = "Enterprise")]
        ENTERPRISE,

        /// <summary>
        /// OptechX 
        /// </summary>
        [EnumMember(Value = "Government")]
        GOVERNMENT,

        [EnumMember(Value = "VIP")]
        VIP,

        [EnumMember(Value = "Founder")]
        FOUNDER,

        [EnumMember(Value = "Shareholder")]
        SHAREHOLDER,

        /// <summary>
        /// Used when a payment has failed, and the account status is PAUSED until payment is received
        /// </summary>
        [EnumMember(Value = "Account Paused")]
        PAUSED,

        [EnumMember(Value = "Other")]
        OTHER,

        [EnumMember(Value = "Record Closed")]
        CLOSED
    }
}

