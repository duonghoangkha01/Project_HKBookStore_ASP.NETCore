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
        public string Method { set; get; }
        public string Information { set; get; }
        public List<Order> Orders { set; get; }
    }
}
