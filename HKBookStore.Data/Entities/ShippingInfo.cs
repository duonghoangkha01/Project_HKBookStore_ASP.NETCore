using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Data.Entities
{
    public class ShippingInfo
    {
        public int Id { set; get; }
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string Address { set; get; }

        public List<Order> Orders { get; set; }

        public Guid UserId { set; get; }
        public  AppUser AppUser { get; set; }
    }
}
