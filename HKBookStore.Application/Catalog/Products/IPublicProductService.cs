using HKBookStore.Application.Catalog.Dtos;
using HKBookStore.Application.Catalog.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        PagedViewModel<ProductViewModel> GetAllByCategoryId(int categoryId, int pageIndex, int pageSize);
    }
}
