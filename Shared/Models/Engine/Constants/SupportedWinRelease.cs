using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Engine.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SupportedWinRelease
    {
        [EnumMember(Value = "NULL")]
        NULL,
        [EnumMember(Value = "Windows 7")]
        WIN7,
        [EnumMember(Value = "Windows 8")]
        WIN8,
        [EnumMember(Value = "Windows 8.1")]
        WIN8_1,
        [EnumMember(Value = "Windows 10")]
        WIN10,
        [EnumMember(Value = "Windows 11")]
        WIN11,
    }
}

