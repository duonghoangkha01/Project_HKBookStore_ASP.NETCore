using HKBookStore.ViewModels.Catalog.Products;
using HKBookStore.ViewModels.Common;

namespace HKBookStore.ApiIntegration
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductViewModel>> GetPagings(GetManageProductPagingRequest request);
        Task<bool> CreateProduct(ProductCreateRequest request);
        Task<bool> UpdateProduct(ProductUpdateRequest request);
        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);
        Task<ProductViewModel> GetById(int id);
        Task<List<ProductViewModel>> GetFeaturedProducts(int take);
        Task<List<ProductViewModel>> GetLatestProducts(int take);
    }
}
