using HKBookStore.ViewModels.Catalog.Carts;
using HKBookStore.ViewModels.Catalog.PaymentMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.ViewModels.Catalog.Orders
{
    public class CheckoutViewModel
    {
        public List<CartItemViewModel> CartItems { get; set; }
        public ShippingInfoViewModel ShippingInfo { get; set; }
        public int PaymentMethodId { get; set; }
        public List<PaymentMethodViewModel>? PaymentMethodViewModels { get; set; }
        public decimal Total { get; set; }

    }
}
