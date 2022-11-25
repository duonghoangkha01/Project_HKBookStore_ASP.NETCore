using HKBookStore.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Data.Entities
{
    public class Order
    {
        public int Id { set; get; }
        public DateTime OrderDate { set; get; }
        public Guid UserId { set; get; }
        public string Status { set; get; }

        public List<OrderDetail> OrderDetails { set; get; }

        public AppUser AppUser { get; set; }
        public Invoice Invoice { get; set; }
        
        public Payment Payment { get; set; }

        public int ShippingFeeId { get; set; }
        public ShippingFee ShippingFee { get; set; }
        public int ShippingInfoId { get; set; }
        public ShippingInfo ShippingInfo { get; set; }


    }
}
