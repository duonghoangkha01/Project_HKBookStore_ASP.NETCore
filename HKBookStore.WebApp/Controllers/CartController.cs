using HKBookStore.ApiIntegration;
using HKBookStore.Data.Enums;
using HKBookStore.ViewModels.Catalog.Carts;
using HKBookStore.ViewModels.Catalog.Orders;
using HKBookStore.ViewModels.Catalog.Payments;
using HKBookStore.WebApp.Models;
using HKBookStore.WebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HKBookStore.WebApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartApiClient _cartApiClient;
        private readonly IOrderApiClient _orderApiClient;
        private readonly IVnPayService _vnPayService;
        private readonly IPaymentMethodApiClient _paymentMethodApiClient;

        public CartController(ICartApiClient cartApiClient, IOrderApiClient orderApiClient, IPaymentMethodApiClient paymentMethodApiClient, IVnPayService vnPayService)
        {
            _cartApiClient = cartApiClient;
            _orderApiClient = orderApiClient;
            _vnPayService = vnPayService;
            _paymentMethodApiClient = paymentMethodApiClient;
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
                PaymentMethodId = 0,
                PaymentMethodViewModels = await _paymentMethodApiClient.GetAll(),
            };
            checkoutViewModel.Total = checkoutViewModel.CartItems.Sum(x => x.Quantity * x.Price);
            return View(checkoutViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel checkoutViewModel)
        {
            checkoutViewModel.CartItems = await _cartApiClient.GetCarts();
            checkoutViewModel.Total = checkoutViewModel.CartItems.Sum(x => x.Quantity * x.Price);
            var result = await _orderApiClient.AddOrder(checkoutViewModel);
            if (result.IsSuccessed == false)
                return View(checkoutViewModel);
            if(checkoutViewModel.PaymentMethodId == 1)
            {
                return RedirectToAction("OrderSuccess", new { OrderId = result.ResultObj });
            }
            else
            {
                PaymentInformationModel model = new PaymentInformationModel()
                {
                    OrderType = "",
                    Amount = Decimal.ToDouble(checkoutViewModel.Total),
                    OrderDescription = "",
                    Name = "", 
                    OrderId = result.ResultObj
                };
                var url = _vnPayService.CreatePaymentUrl(model, HttpContext);

            return Redirect(url);
            }
        }

        public ActionResult PaymentConfirm()
        {
            var response = _vnPayService.PaymentExecute(Request.Query);
            if (response.Success)
            {
                var updatePaymentViewModel = new UpdatePaymentViewModel()
                {
                    OrderId = Convert.ToInt32(response.OrderId),
                    Status = PaymentStatus.PaymentStatusPaid
                };
                var result = _orderApiClient.UpdateStatusPayment(updatePaymentViewModel);
                return View(response);
            }
            else
            {
                return View(response);
            }
                
            
        }


        public ActionResult OrderSuccess(int OrderId)
        {
            return View(OrderId);
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
