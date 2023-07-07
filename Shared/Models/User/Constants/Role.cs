using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.User.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        [EnumMember(Value = "Admin")]
        ADMIN,
        [EnumMember(Value = "User")]
        USER
    }
}

