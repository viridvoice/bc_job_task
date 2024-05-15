using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using bc_job.Services;
using bc_job.Services.Interfaces;


IHost host = Host.CreateDefaultBuilder().ConfigureServices(services =>
{

    services.AddTransient<IApiService, ApiService>();
    services.AddTransient<IDataFiltering, DataFiltering>();
    services.AddTransient<IDataGrouping, DataGrouping>();
    services.AddTransient<IDataStoring, DataStoring>();
    
    
    services.AddSingleton<IBookManaging, BookManaging>();
}).Build();

var app = host.Services.GetRequiredService<IBookManaging>();
await app.Run();