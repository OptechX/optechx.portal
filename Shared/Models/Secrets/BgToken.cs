using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Secrets;

public class BgToken
{
    [JsonPropertyName("token")]
	public string Token { get; set; } = null!;
}

