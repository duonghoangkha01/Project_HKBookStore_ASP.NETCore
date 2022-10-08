using HKBookStore.Data.EF;
using HKBookStore.Data.Entities;
using HKBookStore.ViewModels.Catalog.Categories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly HKBookStoreDbContext _context;

        public CategoryService(HKBookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryViewModel>> GetAll()
        {
            var query = from c in _context.Categories
                        select new { c };
            return await query.Select(x => new CategoryViewModel()
            {
                Id = x.c.Id,
                Name = x.c.Name,
                ParentId = x.c.ParentId
            }).ToListAsync();
        }
    }
}
