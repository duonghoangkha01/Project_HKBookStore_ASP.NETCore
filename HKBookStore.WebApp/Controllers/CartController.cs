using HKBookStore.ApiIntegration;
using HKBookStore.ViewModels.Catalog.Carts;
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
        public async Task<IActionResult> Index()
        {
            List<CartItemViewModel> carts = await _cartApiClient.GetCarts();
            return View(carts);
        }

        public async Task<IActionResult> GetListItems()
        {
            List<CartItemViewModel> carts = await _cartApiClient.GetCarts();
            return Ok(carts);
        }


        public async Task<IActionResult> AddToCart(int productId)
        {
            await _cartApiClient.AddItemToCart(productId);
            List<CartItemViewModel> carts = await _cartApiClient.GetCarts();
            return Ok(carts);
        }

        public async Task<IActionResult> UpdateCart(int productId, int quantity)
        {
            var result = await _cartApiClient.UpdateCart(productId, quantity);
            if(result==false)
                return BadRequest();
            return Ok();
        }
    }
}
