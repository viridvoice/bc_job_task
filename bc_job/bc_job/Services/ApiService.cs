using bc_job.Services.Interfaces;

namespace bc_job.Services;

public class ApiService : IApiService
{
    private static readonly HttpClient Client = new();
    
    public async Task<string> GetRequest(string url)
    {
        if (string.IsNullOrEmpty(url)) { throw new Exception("URL is empty"); }
        return await Client.GetStringAsync(url);
    }
}