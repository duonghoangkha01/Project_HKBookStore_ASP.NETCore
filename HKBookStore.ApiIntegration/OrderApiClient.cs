using HKBookStore.ViewModels.Catalog.Carts;
using HKBookStore.ViewModels.Catalog.Orders;
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
    public class OrderApiClient : BaseApiClient, IOrderApiClient
    {
        public OrderApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<bool> AddOrder(CheckoutViewModel checkoutRequest)
        {
            var json = JsonConvert.SerializeObject(checkoutRequest);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            return await PostAsync<bool>(@"api/orders/add", httpContent);
        }

        public async Task<List<GetOrderViewModel>> GetAll(string status)
        {
            return await GetAsync<List<GetOrderViewModel>>(@"/api/orders?status="+status);

        }
    }
}
