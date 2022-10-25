using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Data.Entities
{
    public class Invoice
    {
        public int Id { set; get; }
        public DateTime DateCreated { set; get; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
