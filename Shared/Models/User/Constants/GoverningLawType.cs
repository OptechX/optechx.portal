using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.User.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GoverningLawType
    {
        [EnumMember(Value = "New South Wales")]
        NSW,
        [EnumMember(Value = "Australia")]
        AU,
    }
}

