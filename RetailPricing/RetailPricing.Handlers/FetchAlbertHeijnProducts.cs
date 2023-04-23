using InfluxDB.Client;
using InfluxDB.Client.Writes;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using RetailPricing.Handlers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailPricing.Handlers
{
    public class FetchAlbertHeijnProducts
    {
        private readonly ILogger _logger;
        private readonly IAlbertHeijnService _albertHeijnService;
        private readonly InfluxDBClient _influxDbClient;

        public FetchAlbertHeijnProducts(
            ILogger<FetchAlbertHeijnProducts> logger,
            IAlbertHeijnService albertHeijnService,
            InfluxDBClient influxDbClient)
        {
            _logger = logger;
            _albertHeijnService = albertHeijnService;
            _influxDbClient = influxDbClient;
        }

        [FunctionName("FetchAlbertHeijnProducts")]
        public async Task Run([TimerTrigger("0 0 0 * * *", RunOnStartup = true)] TimerInfo myTimer)
        {
            _logger.LogInformation($"FetchAlbertHeijnProducts");

            var retailerReponse = await _albertHeijnService.GetProductAsync("548562");

            var point = PointData.Measurement("price")
                .Tag("retailer", "albertheijn")
                .Tag("id", retailerReponse.Card.Products.First().Id.ToString())
                .Field("value", retailerReponse.Card.Products.First().Price.Now)
                .Timestamp(DateTime.UtcNow, InfluxDB.Client.Api.Domain.WritePrecision.Ns);

            using var writeApi = _influxDbClient.GetWriteApi();
            writeApi.WritePoint(point, "pricing", "retail");
        }
    }
}
