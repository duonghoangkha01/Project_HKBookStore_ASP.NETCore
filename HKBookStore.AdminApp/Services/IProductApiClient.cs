using HKBookStore.ViewModels.Catalog.Products;
using HKBookStore.ViewModels.Common;

namespace HKBookStore.AdminApp.Services
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductViewModel>> GetPagings(GetManageProductPagingRequest request);
        Task<bool> CreateProduct(ProductCreateRequest request);
    }
}
