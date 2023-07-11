using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Engine.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BuildStatus
    {
        [EnumMember(Value = "Submitted")]
        SUBMITTED,
        [EnumMember(Value = "Queued")]
        QUEUED,
        [EnumMember(Value = "Prework")]
        PREWORK,
        [EnumMember(Value = "Processing")]
        PROCESSING,
        [EnumMember(Value = "Compiling")]
        COMPILING,
        [EnumMember(Value = "Complete")]
        COMPELTE,
        [EnumMember(Value = "Deleted")]
        DELETED
    }
}

