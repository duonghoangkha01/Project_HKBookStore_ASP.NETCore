using HKBookStore.ViewModels.Catalog.Carts;
using HKBookStore.ViewModels.Catalog.Orders;
using HKBookStore.ViewModels.Catalog.PaymentMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.ApiIntegration
{
    public class PaymentMethodApiClient : BaseApiClient, IPaymentMethodApiClient
    {
        public PaymentMethodApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<List<PaymentMethodViewModel>> GetAll()
        {
            return await GetAsync<List<PaymentMethodViewModel>>(@"/api/paymentmethods/getall");

        }
    }
}
