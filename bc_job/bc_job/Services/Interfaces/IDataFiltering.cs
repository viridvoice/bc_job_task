using bc_job.Models;

namespace bc_job.Services.Interfaces;

public interface IDataFiltering
{
    Task<List<Book>?> FilterBooksWithWhere(List<Book> source);
    Task<List<Book>?> FilterBooksWithLoop(List<Book> source);
}