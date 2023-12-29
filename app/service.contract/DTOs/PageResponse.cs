using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service.contract.DTOs
{
    public class PageResponse<T>
    {
        public PageResponse()
        {
            Items = Enumerable.Empty<T>();
        }
        public long TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
