using bc_job.Models;

namespace bc_job.Services.Interfaces;

public interface IDataStoring
{
    Task<bool> StoreToFile(List<List<Book>> source);
}