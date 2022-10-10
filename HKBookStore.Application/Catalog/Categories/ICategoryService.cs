using HKBookStore.Data.Entities;
using HKBookStore.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAll();
        Task<CategoryViewModel> GetById(int id);
    }
}
