using InfluxDB.Client;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using RetailPricing.Handlers.Services;
using System;

[assembly: FunctionsStartup(typeof(RetailPricing.Handlers.Startup))]

namespace RetailPricing.Handlers
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddRefitClient<IAlbertHeijnService>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://www.ah.nl/");
            });

            builder.Services.AddSingleton(new InfluxDBClient(
                Environment.GetEnvironmentVariable("DOCKER_INFLUXDB_ENDPOINT"),
                Environment.GetEnvironmentVariable("DOCKER_INFLUXDB_TOKEN")));
        }
    }
}
