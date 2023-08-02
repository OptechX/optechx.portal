using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.User.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StripeBgTaskStatus
	{
        /// <summary>
        /// Queued to process
        /// </summary>
        [EnumMember(Value = "Queued")]
        QUEUED,

        /// <summary>
        /// Processed, no futher action
        /// </summary>
        [EnumMember(Value = "Processed")]
        PROCESSED,

        /// <summary>
        /// Error has occured
        /// </summary>
        [EnumMember(Value = "Error")]
        ERROR,

        /// <summary>
        /// Manual task to be reviewed
        /// </summary>
        [EnumMember(Value = "Action Required")]
        INTERVENE
    }
}

