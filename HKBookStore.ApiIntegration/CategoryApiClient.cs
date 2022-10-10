using HKBookStore.ViewModels.Catalog.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace HKBookStore.ApiIntegration
{
    public class CategoryApiClient : BaseApiClient, ICategoryApiClient
    {
        public CategoryApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<List<CategoryViewModel>> GetAll()
        {
            return await GetListAsync<CategoryViewModel>("/api/categories");
        }

        public async Task<CategoryViewModel> GetById( int id)
        {
            return await GetAsync<CategoryViewModel>($"/api/categories/{id}");
        }
    }
}
