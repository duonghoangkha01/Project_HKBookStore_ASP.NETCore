using HKBookStore.Data.Entities;
using HKBookStore.ViewModels.Catalog.Carts;
using HKBookStore.ViewModels.Catalog.Orders;
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

namespace HKBookStore.Application.Catalog.Orders
{
    public interface IOrderService
    {
        Task<int> AddOrder(Guid userId, CheckoutViewModel checkoutRequest);
        Task<List<GetOrderViewModel>> GetAll(Guid userId);
    }
}
