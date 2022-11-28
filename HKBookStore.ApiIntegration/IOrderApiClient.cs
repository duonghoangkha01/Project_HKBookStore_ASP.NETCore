using HKBookStore.Data.Enums;
using HKBookStore.ViewModels.Catalog.Orders;
using HKBookStore.ViewModels.Catalog.Payments;
using HKBookStore.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.ApiIntegration
{
    public interface IOrderApiClient
    {
        Task<ApiResult<int>> AddOrder(CheckoutViewModel checkoutRequest);
        Task<List<GetOrderViewModel>> GetAll(string? status);
        Task<GetDetailOrderViewModel> Get(int orderId);
        Task<ApiResult<bool>> UpdateStatusPayment(UpdatePaymentViewModel updatePaymentViewModel);
    }
}
