using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Data.Entities
{
    public class Payment
    {
        public int Id { set; get; }
        public string Status { set; get; }
        public string Information { set; get; }

        public int OrderId { set; get; }
        public Order Order { set; get; }

        public int PaymentMethodId { set; get; }
        public PaymentMethod PaymentMethod { set; get; }
    }
}
