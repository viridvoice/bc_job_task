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

    public async Task Run() {
        
        // send request
        Console.WriteLine("Do you want to pull the books repository? (y || yes / n || No)");
        var input = Console.ReadLine();

        string inp = string.IsNullOrEmpty(input) ? "" : input.ToLowerInvariant();

        // Answer accepted - continue work
        if (AcceptedAnswers.Contains(inp)) {
            
            Console.WriteLine("Pulling books...");
            try {
                var response = await apiService.GetRequest(Endpoint);
                var result = JsonSerializer.Deserialize<ApiResponse>(response);


                // filter books
                if (result?.Books != null && Filter) {
                    var filtered = await dataFiltering.FilterBooksWithWhere(result.Books);
                    var filtered2 = await dataFiltering.FilterBooksWithLoop(result.Books);
                }

                // group books
                if (Group && result?.Books != null) {
                    var grouped = await dataGrouping.GroupData(result.Books);

                    if (StoreToFile) {
                        string stored = await dataStoring.StoreToFile(grouped) ? "Data stored to file" : "Data storing failed";
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

        // Answer unaccepted - exit 
        else {
            Console.WriteLine("Exiting program");
        }
    }
}