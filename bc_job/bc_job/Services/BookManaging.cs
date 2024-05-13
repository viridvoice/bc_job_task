using System.Text.Json;
using bc_job.Models;
using bc_job.Services.Interfaces;

namespace bc_job.Services;

public class BookManaging(IApiService apiService, IDataFiltering dataFiltering, IDataGrouping dataGrouping, IDataStoring dataStoring) : IBookManaging
{
    private async Task<bool> StartProgram() {
        bool status = false;
        
        // send request
        Console.WriteLine("Do you want to pull the books repository? (y || ye || yes)");
        var input = Console.ReadLine();
        Console.WriteLine("Command accepted.");
        string inp = string.IsNullOrEmpty(input) ? "" : input.ToLowerInvariant();
        
        // Answer accepted - continue work
        if (Parameters.AcceptedAnswers.Contains(inp)) {
            Console.WriteLine("Pulling books...");
            status = true;
        }
        
        // Answer not accepted - exit
        else {
            Console.WriteLine("Exiting program");
        }

        await Task.CompletedTask;
        return status;
    }

    private async Task<List<Book>> Filtering(List<Book>? source, int method = 1) {
        List<Book> result = new List<Book>();
        if (source != null && Parameters.Filter) {
            result = method == 1 ? 
                await dataFiltering.FilterBooksWithWhere(source) : 
                await dataFiltering.FilterBooksWithLoop(source);
        }
        return result;
    }
    
    public async Task Run() {
        if (!await StartProgram()) { return; }
        
        try {
            var response = await apiService.GetRequest(Parameters.FeedUrl);
            var result = JsonSerializer.Deserialize<ApiResponse>(response);

            // filter books
            List<Book> filtered = await Filtering(result?.Books);
            

            // group books
            if (Parameters.Group && result?.Books != null) {
                var grouped = await dataGrouping.GroupData(result.Books);

                if (Parameters.StoreToFile) {
                    string stored = await dataStoring.StoreToFile(grouped)
                        ? "Data stored to file"
                        : "Data storing failed";
                    Console.WriteLine(stored);
                }
            }
        }
        catch (Exception e) {
            Console.WriteLine("An error occured:");
            Console.WriteLine(e);
            // no need to re-throw error - just exit program
        }
    }
}