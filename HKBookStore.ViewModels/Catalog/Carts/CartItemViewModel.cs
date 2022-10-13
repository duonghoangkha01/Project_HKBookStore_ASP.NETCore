using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.ViewModels.Catalog.Carts
{
    public class CartItemViewModel
    {
        public int Id { set; get; }
        public string ProductId { set; get; }
        public int ProductName { set; get; }
        public string ProductDescription { get; set; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }

        public string ProductImage { get; set; }
    }
}
