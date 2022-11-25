using HKBookStore.Application.Catalog.Carts;
using HKBookStore.Application.Catalog.Common;
using HKBookStore.Data.EF;
using HKBookStore.Data.Entities;
using HKBookStore.Data.Enums;
using HKBookStore.ViewModels.Catalog.Carts;
using HKBookStore.ViewModels.Catalog.Orders;
using HKBookStore.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Application.Catalog.Orders
{
    public class OrderService : IOrderService
    {
        private readonly HKBookStoreDbContext _context;
        private readonly ICartService _cartService;

        public OrderService(HKBookStoreDbContext context, ICartService cartService)
        {
            _context = context;
            _cartService = cartService;
        }

        public async Task<List<GetOrderViewModel>> GetAll(Guid userId, string? status)
        {
            //var query = from o in _context.Orders
            //            join od in _context.OrderDetails on o.Id equals od.OrderId
            //            join p in _context.Products on od.ProductId equals p.Id
            //            where o.UserId == userId
            //            select new { o, od, p };
            

            var query = _context.Orders.Include(x => x.OrderDetails).ThenInclude(x => x.Product).Where(x => x.UserId == userId).OrderByDescending(x => x.OrderDate).ToList();
            if (status != null)
                query = query.Where(x => x.Status == status).ToList();
            var data = new List<GetOrderViewModel>();
            foreach (var item in query)
            {
                var order = new GetOrderViewModel()
                {
                    Id = item.Id,
                    OrderDate = item.OrderDate,
                    Status = item.Status,
                    OrderDetails = new List<GetOrderDetailViewModel>(),
                };
                foreach (var item2 in item.OrderDetails)
                {
                    var orderDetail = new GetOrderDetailViewModel()
                    {
                        ProductName = item2.Product.Name,
                        Quantity = item2.Quantity,
                        Price = item2.Price,
                    };
                    order.OrderDetails.Add(orderDetail);

                }
                data.Add(order);
            }

            return data;
        }

        public async Task<GetDetailOrderViewModel> GetOrder(Guid userId, int orderId)
        {


            var query = await _context.Orders.Include(x => x.OrderDetails).ThenInclude(x => x.Product).Include(x => x.ShippingInfo).Where(x => x.UserId == userId && x.Id == orderId).FirstOrDefaultAsync();
            var order = new GetDetailOrderViewModel();


            order.Id = query.Id;
            order.OrderDate = query.OrderDate;
            order.Status = query.Status;
            order.OrderDetails = new List<GetOrderDetailViewModel>();
                
            foreach (var item in query.OrderDetails)
            {
                var orderDetail = new GetOrderDetailViewModel()
                {
                    ProductName = item.Product.Name,
                    Quantity = item.Quantity,
                    Price = item.Price,
                };
            order.OrderDetails.Add(orderDetail);

            }

            order.ShippingInfo = new ShippingInfoViewModel()
            {
                Name = query.ShippingInfo.Name,
                Address = query.ShippingInfo.Address,
                Email = query.ShippingInfo.Email,
                PhoneNumber = query.ShippingInfo.PhoneNumber    
            };
           

            return order;
        }

        public async Task<ApiResult<bool>> AddOrder(Guid userId, CheckoutViewModel checkoutRequest)
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
                Status = OrderStatus.Pending,
                OrderDetails = orderDetails,
                UserId = userId,
                ShippingFeeId = 1,
                //PaymentId = 1,
                ShippingInfo = shippingInfo,
            };
            _context.Orders.Add(order);
            

            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                await _cartService.DeleteAllCarts(userId);
                return new ApiSuccessResult<bool>();
            }    
                
            return new ApiErrorResult<bool>("Đặt hàng không thành công");
        }
    }
}
