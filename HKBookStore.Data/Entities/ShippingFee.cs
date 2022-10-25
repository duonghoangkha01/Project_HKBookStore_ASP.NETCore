using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Data.Entities
{
    public class ShippingFee
    {
        public int Id { set; get; }
        public decimal Price { set; get; }

        public List<Order> Orders { get; set; }
    }
}
