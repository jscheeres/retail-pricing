using System.Text.Json.Serialization;

namespace RetailPricing.Handlers.Models.AlbertHeijn
{
    public class Price
    {
        [JsonPropertyName("now")]
        public decimal Now { get; set; }
    }
}