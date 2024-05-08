using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using bc_job.Services;
using bc_job.Services.Interfaces;


IHost _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
{

    services.AddTransient<IApiService, ApiService>();
    services.AddTransient<IDataFiltering, DataFiltering>();
    services.AddTransient<IDataGrouping, DataGrouping>();
    
    
    services.AddSingleton<IBookManaging, BookManaging>();
}).Build();

var app = _host.Services.GetRequiredService<IBookManaging>();
await app.Run();