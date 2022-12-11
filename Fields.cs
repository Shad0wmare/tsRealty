using System.Text.Json.Serialization;

namespace tsRealty;

public class Fields
{
    [JsonPropertyName("type")] public string? Type { get; set; }
    [JsonPropertyName("title")] public string? Title { get; set; }
}
