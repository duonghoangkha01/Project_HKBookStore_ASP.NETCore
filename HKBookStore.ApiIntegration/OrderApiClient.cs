﻿using HKBookStore.ViewModels.Catalog.Carts;
using HKBookStore.ViewModels.Catalog.Orders;
using HKBookStore.ViewModels.Catalog.Payments;
using HKBookStore.ViewModels.Common;
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

        public async Task<ApiResult<int>> AddOrder(CheckoutViewModel checkoutRequest)
        {
            var json = JsonConvert.SerializeObject(checkoutRequest);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            return await PostAsync2<ApiResult<int>>(@"api/orders/add", httpContent);
        }

        public async Task<List<GetOrderViewModel>> GetAll(string status)
        {
            return await GetAsync<List<GetOrderViewModel>>(@"/api/orders/getall?status=" + status);

        }

        public async Task<GetDetailOrderViewModel> Get(int orderId)
        {
            return await GetAsync<GetDetailOrderViewModel>(@"/api/orders/get?orderId=" + orderId);

        }

        public async Task<ApiResult<bool>> UpdateStatusPayment(UpdatePaymentViewModel updatePaymentViewModel)
        {
            var json = JsonConvert.SerializeObject(updatePaymentViewModel);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            return await PutAsync2<ApiResult<bool>>(@"api/orders/updatestatuspayment", httpContent);
        }
    }
}