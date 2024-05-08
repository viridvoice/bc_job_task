using System.Text.Json.Serialization;

namespace bc_job.Models;

public class Logos
{
    [JsonPropertyName("promo")]
    public string? Promo { get; set; }
    [JsonPropertyName("primary")]
    public string? Primary { get; set; }

    [JsonPropertyName("thumbnail")]
    public string? Thumb { get; set; }

    [JsonPropertyName("brand_dark")]
    public string? Dark { get; set; }

    [JsonPropertyName("brand_light")]
    public string? Light { get; set; }

    [JsonPropertyName("betslip_carousel")]
    public string? Carousel { get; set; }
}