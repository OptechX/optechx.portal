using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Lcid
    {
        [EnumMember(Value = "MUI")]
        MUI,
        [EnumMember(Value = "en-US")]
        EN_US
    }
}

