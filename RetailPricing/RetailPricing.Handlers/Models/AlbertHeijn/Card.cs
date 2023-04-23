using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RetailPricing.Handlers.Models.AlbertHeijn
{
    public class Card
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }
    }

}
