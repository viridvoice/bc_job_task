using bc_job.Models;
using bc_job.Services.Interfaces;

namespace bc_job.Services;

public class DataGrouping : IDataGrouping
{
    public async Task<List<List<Book>>?> GroupData(List<Book> source)
    {
        List<List<Book>> result = new List<List<Book>>();
        var grouped = source.GroupBy(x => x.ParentName).OrderBy(x=>x.Key);
        foreach (var group in grouped) {
            result.Add(group.ToList());
        }
        await Task.CompletedTask;
        return result.Any() ? result : null;
    }
}