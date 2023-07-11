using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Engine.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ImageOutputFormat
    {
        [EnumMember(Value = "WIM")]
        WIM,
        [EnumMember(Value = "ISO")]
        ISO,
        [EnumMember(Value = "VHD")]
        VHD,
        [EnumMember(Value = "VHDX")]
        VHDX,
        [EnumMember(Value = "ZIP")]
        ZIP
    }
}

