using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SupportedWin11Version
    {
        [EnumMember(Value = "NULL")]
        NULL,
        [EnumMember(Value = "21H1")]
        v21H1,
        [EnumMember(Value = "22H2")]
        v21H2
    }
}

