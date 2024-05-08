using System.Text.Json.Serialization;

namespace bc_job.Models;

public class ApiResponse
{
    [JsonPropertyName("books")]
    public List<Book> Books { get; set; } = new();
}