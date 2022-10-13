using HKBookStore.ViewModels.Catalog.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HKBookStore.ApiIntegration
{
    public class CartApiClient : BaseApiClient, ICartApiClient
    {
        public CartApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<bool> AddItemToCart(int productId)
        {
            return await PutAsync<bool>(@"/api/carts/add/" + productId);
        }

    }
}
