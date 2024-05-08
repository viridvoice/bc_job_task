using bc_job.Models;
using bc_job.Services.Interfaces;

namespace bc_job.Services;

public class DataFiltering : IDataFiltering
{
    public async Task<List<Book>> FilterBooksWithWhere(List<Book> source) {
        List<Book> result = source
            .Where(x=>x.BookMeta.States.Contains("NJ") || x.BookMeta.States.Contains("CO"))
            .Where(x => x.ParentName != null).ToList();
        await Task.CompletedTask;
        return result;
    }

    public async Task<List<Book>> FilterBooksWithLoop(List<Book> source) {
        List<Book> result = new List<Book>();
        foreach (Book book in source) {
            if ((book.BookMeta.States.Contains("CO") || book.BookMeta.States.Contains("NJ")) && !string.IsNullOrEmpty(book.ParentName)) {
                result.Add(book);
            }
        }
        await Task.CompletedTask;
        return result;
    }
}