using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CpuArch
    {
        [EnumMember(Value = "x86")]
        x86,
        [EnumMember(Value = "x64")]
        x64,
        [EnumMember(Value = "aarch32")]
        aarch32,
        [EnumMember(Value = "arm64")]
        arm64
    }
}

