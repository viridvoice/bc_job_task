using System.Text.Json.Serialization;

namespace bc_job.Models;

public class Logos
{
    public string? Promo { get; set; }
    public string? Primary { get; set; }
    
    [JsonPropertyName("thumbnail")]
    public string? Thumb { get; set; }
    
    [JsonPropertyName("betslip_carousel")]
    public string? Carousel { get; set; }
}