using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SupportedWin10Version
    {
        [EnumMember(Value = "NULL")]
        NULL,
        [EnumMember(Value = "1507")]
        v1507,
        [EnumMember(Value = "1511")]
        v1511,
        [EnumMember(Value = "1607")]
        v1607,
        [EnumMember(Value = "1703")]
        v1703,
        [EnumMember(Value = "1709")]
        v1709,
        [EnumMember(Value = "1803")]
        v1803,
        [EnumMember(Value = "1809")]
        v1809,
        [EnumMember(Value = "1903")]
        v1903,
        [EnumMember(Value = "1909")]
        v1909,
        [EnumMember(Value = "2004")]
        v2004,
        [EnumMember(Value = "19H1")]
        v19H1,
        [EnumMember(Value = "19H2")]
        v19H2,
        [EnumMember(Value = "20H1")]
        v20H1,
        [EnumMember(Value = "20H2")]
        v20H2,
        [EnumMember(Value = "21H1")]
        v21H1,
        [EnumMember(Value = "21H2")]
        v21H2
    }
}

