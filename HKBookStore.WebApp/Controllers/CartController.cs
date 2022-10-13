using HKBookStore.ApiIntegration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HKBookStore.WebApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartApiClient _cartApiClient;


        public CartController(ICartApiClient cartApiClient)
        {
            _cartApiClient = cartApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> AddToCart(int productId)
        {
            _cartApiClient.AddItemToCart(productId);
            return Ok();
        }
    }
}
