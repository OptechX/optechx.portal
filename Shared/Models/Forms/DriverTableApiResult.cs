using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Forms
{
    public class DriverTableApiResult
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Uid { get; set; }
        public string? Oem { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}

