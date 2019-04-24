using System.Collections.Generic;

namespace Models
{
    public class Page<TData>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<TData> Records { get; set; }
        public int TotalPages { get; set; }
    }
}
