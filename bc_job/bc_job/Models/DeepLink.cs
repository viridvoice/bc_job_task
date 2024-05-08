using System.Text.Json.Serialization;

namespace bc_job.Models;

public class DeepLink
{
    [JsonPropertyName("has_multi")]
    public bool Multi { get; set; }
    
    [JsonPropertyName("is_supported")]
    public bool Supported { get; set; }
}