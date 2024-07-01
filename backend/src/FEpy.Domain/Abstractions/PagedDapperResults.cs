using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEpy.Domain.Abstractions
{
    public class PagedDapperResults<T>
    {
        public PagedDapperResults(
            int totalItems,
            int pageNumber = 1,
            int pageSize = 10)
        {
            var mod = totalItems % pageSize;
            var totalPages = (totalItems / pageSize) + (mod == 0 ? 0 : 1);
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItems = totalItems;
            TotalPages = totalPages;
        }
        public IEnumerable<T>? Items { get; set; }
        public int TotalItems { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10; 
        public int TotalPages { get; set; }
    }
}
