using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SatlinFunctions.Back.Data;
using SatlinFunctions.Back.Repositories;
using SatlinFunctions.Services;
using System;

[assembly: FunctionsStartup(typeof(SatlinFunctions.Startup))]
namespace SatlinFunctions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string urlApi = Environment.GetEnvironmentVariable("Api");

            builder.Services.AddTransient(x => new ServiceApi(urlApi));
                                  
            String cadena = Environment.GetEnvironmentVariable("DBConnection");
            builder.Services.AddTransient<UserRepo>();
            builder.Services.AddTransient<AddressRepo>();
            builder.Services.AddTransient<GeoRepo>();
            builder.Services.AddTransient<CompanyRepo>();
            builder.Services.AddDbContext<BackContext>(options => options.UseSqlServer(cadena));

            builder.Services.AddHttpClient();
        }
    }
}
