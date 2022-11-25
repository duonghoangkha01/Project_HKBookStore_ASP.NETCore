using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Data.Entities
{
    public class PaymentMethod
    {
        public int Id { set; get; }
        public string Method { set; get; }
        public string Description { set; get; }
        public List<Payment> Payments { set; get; }
    }
}
