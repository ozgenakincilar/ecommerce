using System.Collections.Generic;

namespace NS.Infrastructure.Paging
{
    public class PagedSearchList<T>
    {
        public int TotalItemCount { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public List<T> SearchList { get; set; }
    }
}
