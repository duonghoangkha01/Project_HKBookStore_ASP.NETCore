using HKBookStore.Data.Entities;
using HKBookStore.ViewModels.Catalog.Carts;
using HKBookStore.ViewModels.Catalog.ProductImages;
using HKBookStore.ViewModels.Catalog.Products;
using HKBookStore.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Application.Catalog.Carts
{
    public interface ICartService
    {
        Task<int> AddItemToCart(Guid userId, int productId);
        Task<List<CartItemViewModel>> GetListCarts(Guid userId);
        Task<int> UpdateCart(Guid userId, int productId, int quantity);
    }
}
