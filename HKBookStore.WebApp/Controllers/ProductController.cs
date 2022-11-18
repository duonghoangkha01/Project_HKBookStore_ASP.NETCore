using HKBookStore.ApiIntegration;
using HKBookStore.Data.Entities;
using HKBookStore.ViewModels.Catalog.Products;
using HKBookStore.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HKBookStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly ICategoryApiClient _categoryApiClient;

        public ProductController(IProductApiClient productApiClient, ICategoryApiClient categoryApiClient)
        {
            _productApiClient = productApiClient;
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IActionResult> Detail(int id)
        {
            var product = await _productApiClient.GetById(id);
            var images = await _productApiClient.GetImagesOfProduct(id);
            return View(new ProductDetailViewModel()
            {
                Product = product,
                ProductImages = images
            }); ;
        }

        public async Task<IActionResult> Category(int id, int page = 1)
        {
            var products = await _productApiClient.GetPagings(new GetManageProductPagingRequest()
            {
                CategoryId = id,
                PageIndex = page,
                PageSize = 10
            });
            return View(new ProductCategoryViewModel()
            {
                Category = await _categoryApiClient.GetById(id),
                Products = products
            }); ;
        }
    }
}
