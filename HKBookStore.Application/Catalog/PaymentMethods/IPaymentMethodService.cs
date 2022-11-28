using HKBookStore.ViewModels.Catalog.Orders;
using HKBookStore.ViewModels.Catalog.PaymentMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Application.Catalog.PaymentMethods
{
    public interface IPaymentMethodService
    {
        Task<List<PaymentMethodViewModel>> GetAll();
    }
}
