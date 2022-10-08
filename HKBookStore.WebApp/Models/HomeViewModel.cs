using HKBookStore.ViewModels.Catalog.Products;
using HKBookStore.ViewModels.Utilities.Slides;

namespace HKBookStore.WebApp.Models
{
    public class HomeViewModel
    {
        public List<SlideViewModel> Slides { get; set; }

        public List<ProductViewModel> FeaturedProducts { get; set; }

        public List<ProductViewModel> LatestProducts { get; set; }
    }
}
