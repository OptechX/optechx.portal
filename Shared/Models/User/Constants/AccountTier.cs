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
        /// OptechX Enterprise Plan - assigned through admin/reseller only
        /// </summary>
        [EnumMember(Value = "Enterprise")]
        ENTERPRISE,

        /// <summary>
        /// OptechX Government Plan - assigned through admin only
        /// </summary>
        [EnumMember(Value = "Government")]
        GOVERNMENT,

        /// <summary>
        /// VIP User - assigned manually
        /// </summary>
        [EnumMember(Value = "VIP")]
        VIP,

        /// <summary>
        /// Founder User - assigned manually
        /// </summary>
        [EnumMember(Value = "Founder")]
        FOUNDER,

        /// <summary>
        /// Shareholder Class - assigned manually
        /// </summary>
        [EnumMember(Value = "Shareholder")]
        SHAREHOLDER,

        /// <summary>
        /// Used when a payment has failed, and the account status is PAUSED until payment is received
        /// </summary>
        [EnumMember(Value = "Account Paused")]
        PAUSED,

        /// <summary>
        /// For special use only
        /// </summary>
        [EnumMember(Value = "Other")]
        OTHER,

        /// <summary>
        /// Account has been deleted
        /// </summary>
        [EnumMember(Value = "Record Closed")]
        CLOSED
    }
}

