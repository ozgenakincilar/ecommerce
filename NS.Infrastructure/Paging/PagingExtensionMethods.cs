using System.Collections.Generic;
using System.Linq;

namespace NS.Infrastructure.Paging
{
    public static  class PagingExtensionMethods
    {
        public static PagedSearchList<T> ToPage<T>(this IEnumerable<T> collection, PagedBase pagedBase)
        {
            PagedSearchList<T> pagedSearchList = new PagedSearchList<T>();
            pagedSearchList.PageIndex = pagedBase.PageIndex;
            pagedSearchList.PageSize = pagedBase.PageSize;

            var enumerable = collection as T[] ?? collection.ToArray();
            pagedSearchList.TotalItemCount = enumerable.Count();
            pagedSearchList.SearchList =
            enumerable.Skip((pagedBase.PageIndex - 1) * pagedBase.PageSize)
                    .Take(pagedBase.PageSize)
                    .ToList();

            return pagedSearchList;
        } 
    }
}
