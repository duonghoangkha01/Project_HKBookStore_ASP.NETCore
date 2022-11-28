using HKBookStore.Data.Enums;
using HKBookStore.ViewModels.Catalog.Orders;
using HKBookStore.ViewModels.Catalog.PaymentMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.ApiIntegration
{
    public interface IPaymentMethodApiClient
    {
        Task<List<PaymentMethodViewModel>> GetAll();
    }
}
