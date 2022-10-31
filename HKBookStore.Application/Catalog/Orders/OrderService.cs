using HKBookStore.Application.Catalog.Common;
using HKBookStore.Data.EF;
using HKBookStore.Data.Entities;
using HKBookStore.Data.Enums;
using HKBookStore.ViewModels.Catalog.Carts;
using HKBookStore.ViewModels.Catalog.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Application.Catalog.Orders
{
    public class OrderService : IOrderService
    {
        private readonly HKBookStoreDbContext _context;

        public OrderService(HKBookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddOrder(Guid userId, CheckoutViewModel checkoutRequest)
        {
            var orderDetails = new List<OrderDetail>();
            foreach(var item in checkoutRequest.CartItems)
            {
                var orderDetail = new OrderDetail();
                orderDetail.ProductId = item.ProductId;
                orderDetail.Quantity = item.Quantity;
                orderDetail.Price = item.Price;
                orderDetails.Add(orderDetail);
            }

            var shippingInfo = new ShippingInfo()
            {
                Name = checkoutRequest.ShippingInfo.Name,
                Email = checkoutRequest.ShippingInfo.Email,
                Address = checkoutRequest.ShippingInfo.Address,
                PhoneNumber = checkoutRequest.ShippingInfo.PhoneNumber,
                UserId = userId,
            };
            

            var order = new Order()
            {
                OrderDate = DateTime.Now,
                Status = OrderStatus.InProgress,
                OrderDetails = orderDetails,
                UserId = userId,
                ShippingFeeId = 1,
                PaymentId = 1,
                ShippingInfo = shippingInfo,
            };
            _context.Orders.Add(order);
            return await _context.SaveChangesAsync();
        }
    }
}
