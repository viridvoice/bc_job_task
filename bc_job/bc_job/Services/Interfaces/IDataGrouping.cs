using bc_job.Models;

namespace bc_job.Services.Interfaces;

public interface IDataGrouping
{
    Task<List<Book>> GroupData(List<Book> source);
}