using Refit;
using RetailPricing.Handlers.Models.AlbertHeijn;
using System.Threading.Tasks;

namespace RetailPricing.Handlers.Services
{
    public interface IAlbertHeijnService
    {
        [Get("/zoeken/api/products/product?webshopId={id}")]
        Task<GetProductResponse> GetProductAsync(string id);
    }
}
