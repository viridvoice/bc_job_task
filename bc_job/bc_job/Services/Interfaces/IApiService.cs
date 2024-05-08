namespace bc_job.Services.Interfaces;

public interface IApiService
{
    public Task<string> GetRequest(string url = "");
}