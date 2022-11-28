using HKBookStore.Application.Catalog.Carts;
using HKBookStore.Data.EF;
using HKBookStore.ViewModels.Catalog.Orders;
using HKBookStore.ViewModels.Catalog.PaymentMethods;
using HKBookStore.ViewModels.Catalog.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Application.Catalog.PaymentMethods
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly HKBookStoreDbContext _context;

        public PaymentMethodService(HKBookStoreDbContext context)
        {
            _context = context;
        }
        public async Task<List<PaymentMethodViewModel>> GetAll()
        {
            var query = from pm in _context.PaymentMethods
                        select new { pm };

            var data = await query
                .Select(x => new PaymentMethodViewModel()
                {
                    Id = x.pm.Id,
                    Description = x.pm.Description,
                }).ToListAsync();
            return data;
        }
    }
}
