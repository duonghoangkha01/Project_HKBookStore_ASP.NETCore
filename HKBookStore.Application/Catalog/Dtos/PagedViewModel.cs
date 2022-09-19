using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBookStore.Application.Catalog.Dtos
{
    public class PagedViewModel<T>
    {
        public List<T> Items { set; get; }
        public int TotalRecord { set; get; }
    }
}
