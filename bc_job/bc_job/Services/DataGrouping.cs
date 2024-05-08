using bc_job.Models;
using bc_job.Services.Interfaces;

namespace bc_job.Services;

public class DataGrouping : IDataGrouping
{
    public async Task<List<Book>> GroupData(List<Book> source)
    {
        var grouped = source.GroupBy(x => x.ParentName);
        
        await Task.CompletedTask;
        return new List<Book>();
    }
}