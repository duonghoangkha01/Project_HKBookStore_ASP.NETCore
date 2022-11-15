using HKBookStore.ApiIntegration;
using HKBookStore.Data.Entities;
using HKBookStore.Data.Enums;
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

        public async Task<IActionResult> GetAll(string status)
        
        {
            List<GetOrderViewModel> orders;
            switch (status)
            {
                case "pending":
                    orders = await _orderApiClient.GetAll(OrderStatus.Pending);
                    break;
                case "approved":
                    orders = await _orderApiClient.GetAll(OrderStatus.Approved);
                    break;
                case "progressing":
                    orders = await _orderApiClient.GetAll(OrderStatus.Progressing);
                    break;
                case "shipped":
                    orders = await _orderApiClient.GetAll(OrderStatus.Shipped);
                    break;
                case "cancelled":
                    orders = await _orderApiClient.GetAll(OrderStatus.Cancelled);
                    break;
                case "refunded":
                    orders = await _orderApiClient.GetAll(OrderStatus.Refunded);
                    break;
                default:
                    orders = await _orderApiClient.GetAll(null);
                    break;
            }
            return Json(new { data = orders });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
