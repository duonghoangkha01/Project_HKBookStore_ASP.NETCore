using HKBookStore.Data.Enums;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.ViewModels.Catalog.Orders
{
    public class GetOrderViewModel
    {
        public int Id { set; get; }
        public DateTime OrderDate { set; get; }
        public string Status { set; get; }
        public List<GetOrderDetailViewModel> OrderDetails { set; get; }
        
    }
}
