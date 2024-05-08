using System.Text.Json;
using bc_job.Services;
using bc_job.Models;

bool Filter = true;


// send request
Console.WriteLine("Do you want to pull the books repository? (y || yes / n || No)");
var input = Console.ReadLine();

string inp = string.IsNullOrEmpty(input) ? "" : input.ToLowerInvariant();
string[] accepted = ["y", "ye", "yes"];

// Answer accepted - continue work
if (accepted.Contains(inp)) {
    Console.WriteLine("Pulling books...");
    try {
        var response = await new ApiService().GetRequest("https://api.actionnetwork.com/web/v1/books");
        var result = JsonSerializer.Deserialize<ApiResponse>(response);

        
        // filter books
        if (result?.Books != null && Filter){
            var filtered = await new DataFiltering().FilterBooksWithWhere(result.Books);
            var filtered2 = await new DataFiltering().FilterBooksWithLoop(result.Books);
        }
    }
    catch (Exception e) {
        Console.WriteLine("An error occured:");
        Console.WriteLine(e);
        // no need to re-throw error - just exit program
    }
}

// Answer unaccepted - exit 
else { Console.WriteLine("Exiting program"); }
