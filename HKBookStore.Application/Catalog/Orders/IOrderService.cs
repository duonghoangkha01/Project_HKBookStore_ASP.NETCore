using HKBookStore.Data.Entities;
using HKBookStore.ViewModels.Catalog.Carts;
using HKBookStore.ViewModels.Catalog.Orders;
using HKBookStore.ViewModels.Catalog.Payments;
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
        Task<ApiResult<int>> AddOrder(Guid userId, CheckoutViewModel checkoutRequest);
        Task<List<GetOrderViewModel>> GetAll(Guid userId, string? status);
        Task<GetDetailOrderViewModel> GetOrder(Guid userId, int orderId);
        Task<ApiResult<bool>> UpdateStatusPayment(Guid userId, UpdatePaymentViewModel updatePaymentViewModel);
    }
}
