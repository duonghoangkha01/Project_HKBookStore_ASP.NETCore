﻿using HKBookStore.Application.Catalog.Carts;
using HKBookStore.Application.Catalog.Products;
using HKBookStore.Data.Entities;
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
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly UserManager<AppUser> _userManager;

        public CartsController(ICartService cartService, UserManager<AppUser> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }

        [HttpPut("add/{productId}")]
        [Authorize]
        public async Task<IActionResult> AddItemToCart([FromRoute] int productId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.Name);
            var user = await _userManager.FindByNameAsync(claim.Value);
            Guid userId = user.Id;
            if (claim == null)
                return BadRequest();
            else
            {
                var affectedResult = await _cartService.AddItemToCart(userId, productId);
                if (affectedResult == 0)
                    return BadRequest();
                return Ok();
            }
            
        }
    }
}
