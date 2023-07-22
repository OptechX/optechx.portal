using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Forms
{
	public class ApplicationTableApiResult
	{
        [JsonIgnore]
        public int Id { get; set; }
        public string? Uid { get; set; }
        public string? Publisher { get; set; }
        public string? Name { get; set; }
        public string? Version { get; set; }
        public string? Icon { get; set; }
        public string? Docs { get; set; }
        public string? LastUpdated { get; set; }
        public string? Category { get; set; }
    }
}

