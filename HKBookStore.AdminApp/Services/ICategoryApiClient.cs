using HKBookStore.ViewModels.Catalog.Categories;

namespace HKBookStore.AdminApp.Services
{
    public interface ICategoryApiClient
    {
        Task<List<CategoryViewModel>> GetAll();
    }
}
