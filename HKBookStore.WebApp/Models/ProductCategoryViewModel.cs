using HKBookStore.ViewModels.Catalog.Categories;
using HKBookStore.ViewModels.Catalog.Products;
using HKBookStore.ViewModels.Common;

namespace HKBookStore.WebApp.Models
{
    public class ProductCategoryViewModel
    {
        public CategoryViewModel Category { get; set; }

        public PagedResult<ProductViewModel> Products { get; set; }
    }
}
