using System.Text.Json.Serialization;

namespace RetailPricing.Handlers.Models.AlbertHeijn
{
    public class Product
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("price")]
        public Price Price { get; set; }
        [JsonPropertyName("brand")]
        public string Brand { get; set; }
        [JsonPropertyName("category")]
        public string Category { get; set; }
    }
}
