using System.Text.Json.Serialization;

namespace bc_job.Models;

public class Book
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    
    [JsonPropertyName("display_name")]
    public string? Name { get; set; }

    [JsonPropertyName("abbr")]
    public string? Abbreviation { get; set; }

    [JsonPropertyName("source_name")]
    public string? Source { get; set; }

    [JsonPropertyName("meta")]
    public BookMeta BookMeta { get; set; } = new();

    [JsonPropertyName("parent_name")]
    public string? ParentName { get; set; }

    [JsonPropertyName("book_parent_id")]
    public int? ParentId { get; set; }

    [JsonPropertyName("affiliate_id")]
    public int? AffiliateId { get; set; }
  
}