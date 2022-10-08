using HKBookStore.ApiIntegration;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace HKBookStore.WebApp.Controllers.Components
{
    public class DropdownCategoryViewComponent : ViewComponent
    {
        private readonly ICategoryApiClient _categoryApiClient;

        public DropdownCategoryViewComponent(ICategoryApiClient categoryApiClient)
        {
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _categoryApiClient.GetAll();
            return View(items);
        }
    }
}
