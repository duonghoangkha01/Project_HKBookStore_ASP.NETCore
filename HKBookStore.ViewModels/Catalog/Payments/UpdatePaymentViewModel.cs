using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.ViewModels.Catalog.Payments
{
    public class UpdatePaymentViewModel
    {
        public int OrderId { get; set; }
        public string Status { get; set; }
    }
}
