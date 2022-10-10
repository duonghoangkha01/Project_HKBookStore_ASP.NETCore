using HKBookStore.ViewModels.Catalog.Categories;

namespace HKBookStore.ApiIntegration
{
    public interface ICategoryApiClient
    {
        Task<List<CategoryViewModel>> GetAll();
        Task<CategoryViewModel> GetById(int id);
    }
}
