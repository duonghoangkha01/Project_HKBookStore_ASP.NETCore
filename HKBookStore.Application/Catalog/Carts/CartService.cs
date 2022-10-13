using HKBookStore.Application.Catalog.Common;
using HKBookStore.Data.EF;
using HKBookStore.Data.Entities;
using HKBookStore.ViewModels.Catalog.Carts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Application.Catalog.Carts
{
    public class CartService : ICartService
    {
        private readonly HKBookStoreDbContext _context;

        public CartService(HKBookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddItemToCart(Guid userId, int productId)
        {
            var cartFromDb = await _context.Carts.Where(c => c.UserId == userId && c.ProductId == productId).FirstOrDefaultAsync();

            if (cartFromDb == null)
            {
                var product = await _context.Products.FindAsync(productId);
                var cartItem = new Cart()
                {
                    ProductId = productId,
                    Quantity = 1,
                    Price = product.Price,
                    UserId = userId,
                    DateCreated = DateTime.Now,
                };
                _context.Carts.Add(cartItem);
            }
            else
            {
                cartFromDb.Quantity++;
            }
            return await _context.SaveChangesAsync();
        }
    }
}
