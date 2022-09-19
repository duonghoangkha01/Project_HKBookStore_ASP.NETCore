using HKBookStore.Application.Catalog.Dtos;
using HKBookStore.Application.Catalog.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductEditRequest request);

        Task<int> Delete(int productId);

        Task<List<ProductViewModel>> GetAll();

        Task<PagedViewModel<ProductViewModel>> GetAllPaging(string keyword, int pageIndex, int pageSize);
    }
}
