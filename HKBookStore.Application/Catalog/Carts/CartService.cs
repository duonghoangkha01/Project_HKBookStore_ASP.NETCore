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

        public async Task<List<CartItemViewModel>> GetListCarts(Guid userId)
        {
            var query = from c in _context.Carts
                        join p in _context.Products on c.ProductId equals p.Id
                        join pi in _context.ProductImages on p.Id equals pi.ProductId into ppi
                        from pi in ppi.DefaultIfEmpty()
                        where c.UserId == userId && (pi == null || pi.IsDefault == true)
                        select new {c, p, pi};
                
            var data = await query.OrderByDescending(x => x.c.DateCreated)
                .Select(x => new CartItemViewModel()
                {
                    Id = x.c.Id,
                    ProductId = x.c.ProductId,
                    ProductName = x.p.Name,
                    ProductDescription = x.p.Description,
                    Quantity = x.c.Quantity,
                    Price = x.c.Price,
                    ProductImage = x.pi.ImagePath,
                })
                .ToListAsync();
            return data;
        }

        public async Task<int> UpdateCart(Guid userId, int productId, int quantity)
        {
            var cartFromDb = await _context.Carts.Where(c => c.UserId == userId && c.ProductId == productId).FirstOrDefaultAsync();

            if (cartFromDb != null)
            {
                if (quantity == 0)
                {
                    _context.Carts.Remove(cartFromDb);
                }
                else
                {
                    cartFromDb.Quantity = quantity;
                }
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAllCarts(Guid userId)
        {
            var cartFromDb = await _context.Carts.Where(c => c.UserId == userId).ToListAsync();

            if (cartFromDb != null)
            {
                _context.Carts.RemoveRange(cartFromDb);
            }
            return await _context.SaveChangesAsync();
        }
    }
}
