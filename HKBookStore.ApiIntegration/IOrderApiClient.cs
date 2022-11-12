using HKBookStore.ViewModels.Catalog.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.ApiIntegration
{
    public interface IOrderApiClient
    {
        Task<bool> AddOrder(CheckoutViewModel checkoutRequest);
        Task<List<GetOrderViewModel>> GetAll();
    }
}
