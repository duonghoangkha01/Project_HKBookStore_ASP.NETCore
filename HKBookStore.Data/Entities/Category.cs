using HKBookStore.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Data.Entities
{
    public class Category
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int SortOrder { set; get; }
        public bool IsShowOnHome { set; get; }
        public Status Status { set; get; }

        public int? ParentId { set; get; }
        public Category? ParentCategory { set; get; }


        public List<Category> ChildCategories { set; get; }
        public List<ProductInCategory> ProductInCategories { set; get; }
    }
}
