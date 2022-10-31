using HKBookStore.ApiIntegration;
using HKBookStore.ViewModels.Catalog.Carts;
using HKBookStore.ViewModels.Catalog.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HKBookStore.WebApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartApiClient _cartApiClient;
        private readonly IOrderApiClient _orderApiClient;

        public CartController(ICartApiClient cartApiClient, IOrderApiClient orderApiClient)
        {
            _cartApiClient = cartApiClient;
            _orderApiClient = orderApiClient;
        }
        public async Task<IActionResult> Index()
        {
            List<CartItemViewModel> carts = await _cartApiClient.GetCarts();
            return View(carts);
        }

        public async Task<IActionResult> Checkout()
        {
            CheckoutViewModel checkoutViewModel = new CheckoutViewModel()
            {
                CartItems = await _cartApiClient.GetCarts(),
                ShippingInfo = new ShippingInfoViewModel(),
            };
            return View(checkoutViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel checkoutViewModel)
        {
            checkoutViewModel.CartItems = await _cartApiClient.GetCarts();
            await _orderApiClient.AddOrder(checkoutViewModel);
            return View(checkoutViewModel);
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
