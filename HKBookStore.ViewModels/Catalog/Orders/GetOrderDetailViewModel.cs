using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.ViewModels.Catalog.Orders
{
    public class GetOrderDetailViewModel
    {
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public  string ProductName { set; get; }
    }
}
