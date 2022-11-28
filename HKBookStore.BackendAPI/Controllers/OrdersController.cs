using HKBookStore.Application.Catalog.Orders;
using HKBookStore.Data.Entities;
using HKBookStore.ViewModels.Catalog.Orders;
using HKBookStore.ViewModels.Catalog.Payments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HKBookStore.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<AppUser> _userManager;

        public OrdersController(IOrderService orderService, UserManager<AppUser> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        //[HttpGet("")]
        //[Authorize]
        //public async Task<IActionResult> GetCarts()
        //{
        //    var claimsIdentity = (ClaimsIdentity)User.Identity;
        //    var claim = claimsIdentity.FindFirst(ClaimTypes.Name);
        //    var user = await _userManager.FindByNameAsync(claim.Value);
        //    Guid userId = user.Id;
        //    if (claim == null)
        //        return BadRequest();
        //    else
        //    {
        //        var carts = await _cartService.GetListCarts(userId);
        //        return Ok(carts);
        //    }

        //}

        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddOrder([FromBody] CheckoutViewModel checkoutRequest)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.Name);
            var user = await _userManager.FindByNameAsync(claim.Value);
            Guid userId = user.Id;
            if (claim == null)
                return BadRequest();
            else
            {
                var result = await _orderService.AddOrder(userId, checkoutRequest);
                if (!result.IsSuccessed)
                    return BadRequest(result);
                return Ok(result);
            }

        }

        [HttpGet("getall")]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery]string? status)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.Name);
            var user = await _userManager.FindByNameAsync(claim.Value);
            Guid userId = user.Id;
            if (claim == null)
                return BadRequest();
            else
            {
                var result = await _orderService.GetAll(userId, status);
                
                return Ok(result);
            }

        }

        [HttpGet("get")]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] int orderId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.Name);
            var user = await _userManager.FindByNameAsync(claim.Value);
            Guid userId = user.Id;
            if (claim == null)
                return BadRequest();
            else
            {
                var result = await _orderService.GetOrder(userId, orderId);

                return Ok(result);
            }

        }

        [HttpPut("updatestatuspayment")]
        [Authorize]
        public async Task<IActionResult> UpdateStatusPayment([FromBody] UpdatePaymentViewModel updatePaymentViewModel)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.Name);
            var user = await _userManager.FindByNameAsync(claim.Value);
            Guid userId = user.Id;
            if (claim == null)
                return BadRequest();
            else
            {
                var result = await _orderService.UpdateStatusPayment(userId, updatePaymentViewModel);
                if (!result.IsSuccessed)
                    return BadRequest(result);
                return Ok(result);
            }

        }
    }
}
