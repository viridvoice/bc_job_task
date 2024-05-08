﻿using System.Text.Json;
using bc_job.Services;
using bc_job.Models;

// send request
Console.WriteLine("Do you want to pull the books repository? (y || yes / n || No)");
var input = Console.ReadLine();

string inp = string.IsNullOrEmpty(input) ? "" : input.ToLowerInvariant();
string[] truthy = { "y", "ye", "yes" };

// Answer accepted - continue work
if (truthy.Contains(inp)) {
    Console.WriteLine("Pulling books...");
    try {
        var response = await new ApiService().GetRequest("https://api.actionnetwork.com/web/v1/books");
        var result = JsonSerializer.Deserialize<ApiResponse>(response);

    }
    catch (Exception e) {
        Console.WriteLine("An error occured:");
        Console.WriteLine(e);
        // no need to re-throw error - just exit program
    }
}

// Answer unaccepted - exit 
else { Console.WriteLine("Exiting program"); }
