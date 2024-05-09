using System.Text.Json;
using bc_job.Models;
using bc_job.Services.Interfaces;

namespace bc_job.Services;

public class BookManaging(IApiService apiService, IDataFiltering dataFiltering, IDataGrouping dataGrouping, IDataStoring dataStoring) : IBookManaging
{
    private static readonly string Endpoint = "https://api.actionnetwork.com/web/v1/books";
    private static readonly bool Filter = true;
    private static readonly bool Group = true;
    private static readonly bool StoreToFile = true;
    private static readonly string[] AcceptedAnswers = ["y", "ye", "yes"];

    private async Task<bool> StartProgram() {

        // send request
        Console.WriteLine("Do you want to pull the books repository? (y || yes / n || No)");
        var input = Console.ReadLine();

        string inp = string.IsNullOrEmpty(input) ? "" : input.ToLowerInvariant();
        
        // Answer accepted - continue work
        if (AcceptedAnswers.Contains(inp)) {
            Console.WriteLine("Pulling books...");
            return true;
        }

        // Answer unaccepted - exit
        Console.WriteLine("Command accepted.");
        Console.WriteLine("Exiting program");

        await Task.CompletedTask;
        
        return false;
    }

    private async Task<List<Book>> Filtering(List<Book>? source, int method = 1) {
        List<Book> result = new List<Book>();
        if (source != null && Filter) {
            result = method == 1 ? 
                await dataFiltering.FilterBooksWithWhere(source) : 
                await dataFiltering.FilterBooksWithLoop(source);
        }
        return result;
    }
    
    
    public async Task Run() {
        if (!await StartProgram()) { return; }
        
        try {
            var response = await apiService.GetRequest(Endpoint);
            var result = JsonSerializer.Deserialize<ApiResponse>(response);

            // filter books
            List<Book> filtered = await Filtering(result?.Books);
            

            // group books
            if (Group && result?.Books != null) {
                var grouped = await dataGrouping.GroupData(result.Books);

                if (StoreToFile) {
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