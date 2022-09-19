using HKBookStore.Application.Catalog.Dtos;
using HKBookStore.Application.Catalog.Products.Dtos;
using HKBookStore.Application.Catalog.Products.Dtos.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request);
    }
}
