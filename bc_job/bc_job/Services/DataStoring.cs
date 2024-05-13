using bc_job.Models;
using bc_job.Services.Interfaces;

namespace bc_job.Services;

public class DataStoring : IDataStoring
{
    public async Task<bool> StoreToFile(List<List<Book>> source) {
        string content = string.Empty;
        
        foreach (var collection in source) {
            content += collection.FirstOrDefault()?.ParentName + Environment.NewLine;
            
            foreach (var item in collection) {
                content += item.Name + " " + string.Join(",", item.BookMeta.States) + Environment.NewLine;
            }
        }
        
        string? path = Parameters.RootUrl + "//result.txt";
        if (File.Exists(path)) { File.Delete(path); }

        await using StreamWriter sw = File.CreateText(path);
        await sw.WriteAsync(content);
        return true;
    }
}