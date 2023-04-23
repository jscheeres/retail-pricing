using System.Text.Json.Serialization;

namespace RetailPricing.Handlers.Models.AlbertHeijn
{
    public class GetProductResponse
    {
        [JsonPropertyName("card")]
        public Card Card { get; set; }
    }
}
