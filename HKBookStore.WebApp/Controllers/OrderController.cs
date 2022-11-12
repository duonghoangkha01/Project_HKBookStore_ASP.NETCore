using HKBookStore.ApiIntegration;
using HKBookStore.ViewModels.Catalog.Carts;
using HKBookStore.ViewModels.Catalog.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HKBookStore.WebApp.Controllers
{
    public class OrderController : Controller
    {

        private readonly IOrderApiClient _orderApiClient;

        public OrderController(IOrderApiClient orderApiClient)
        {
            _orderApiClient = orderApiClient;
        }

        public async Task<IActionResult> GetAllOrders()
        
        {
            List<GetOrderViewModel> orders = await _orderApiClient.GetAll();
            return Ok(orders);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
