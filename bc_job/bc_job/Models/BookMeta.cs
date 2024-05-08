using System.Text.Json.Serialization;

namespace bc_job.Models;

public class BookMeta
{
    [JsonPropertyName("logos")]
    public Logos Logos { get; set; } = new();
    
    [JsonPropertyName("deeplink")]
    public DeepLink DeepLink { get; set; } = new();

    [JsonPropertyName("states")] 
    public List<string> States { get; set; } = new();


    [JsonPropertyName("website")]
    public string? Website { get; set; }
    
    [JsonPropertyName("is_legal")]
    public bool Legal { get; set; }
    
    [JsonPropertyName("betsync_type")]
    public int BetSyncType { get; set; }
    
    [JsonPropertyName("is_preferred")]
    public bool Preferred { get; set; }
    
    [JsonPropertyName("is_promoted")]
    public bool Promoted { get; set; }
    
    [JsonPropertyName("primary_color")]
    public string? PrimaryColor { get; set; }
    
    [JsonPropertyName("betsync_status")]
    public int BetSyncStatus { get; set; }
    
    [JsonPropertyName("secondary_color")]
    public string? SecondaryColor { get; set; }
    
    [JsonPropertyName("provider_type_id")]
    public int ProviderTypeId { get; set; }
    
    [JsonPropertyName("is_fastbet_enabled_app")]
    public bool FastBetEnabledApp { get; set; }
    
    [JsonPropertyName("is_fastbet_enabled_web")]
    public bool FastBetEnabledWeb { get; set; }
}