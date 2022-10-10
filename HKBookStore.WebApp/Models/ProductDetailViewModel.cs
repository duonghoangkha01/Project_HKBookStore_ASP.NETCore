using HKBookStore.ViewModels.Catalog.Categories;
using HKBookStore.ViewModels.Catalog.ProductImages;
using HKBookStore.ViewModels.Catalog.Products;

namespace HKBookStore.WebApp.Models
{
    public class ProductDetailViewModel
    {
        public CategoryViewModel Category { get; set; }

        public ProductViewModel Product { get; set; }

        public List<ProductViewModel> RelatedProducts { get; set; }

        public List<ProductImageViewModel> ProductImages { get; set; }
    }
}
