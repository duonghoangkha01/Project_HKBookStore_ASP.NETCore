using HKBookStore.Application.Catalog.Orders;
using HKBookStore.Data.Entities;
using HKBookStore.ViewModels.Catalog.Orders;
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
        public async Task<IActionResult> AddItemToCart([FromBody] CheckoutViewModel checkoutRequest)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.Name);
            var user = await _userManager.FindByNameAsync(claim.Value);
            Guid userId = user.Id;
            if (claim == null)
                return BadRequest();
            else
            {
                var affectedResult = await _orderService.AddOrder(userId, checkoutRequest);
                if (affectedResult == 0)
                    return BadRequest();
                return Ok();
            }

        }

        //[HttpPut("update")]
        //[Authorize]
        //public async Task<IActionResult> UpdateCart([FromQuery] int productId, [FromQuery] int quantity)
        //{
        //    var claimsIdentity = (ClaimsIdentity)User.Identity;
        //    var claim = claimsIdentity.FindFirst(ClaimTypes.Name);
        //    var user = await _userManager.FindByNameAsync(claim.Value);
        //    Guid userId = user.Id;
        //    if (claim == null)
        //        return BadRequest();
        //    else
        //    {
        //        var affectedResult = await _cartService.UpdateCart(userId, productId, quantity);
        //        if (affectedResult == 0)
        //            return BadRequest();
        //        return Ok();
        //    }

        //}
    }
}
