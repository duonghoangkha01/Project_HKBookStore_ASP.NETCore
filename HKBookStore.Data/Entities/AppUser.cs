﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Dob { get; set; }

        public string Address { set; get; }

        public List<Cart> Carts { get; set; }

        public List<Order> Orders { get; set; }

        public List<Transaction> Transactions { get; set; }
        public List<ShippingInfo> ShippingInfos { get; set; }
    }
}
