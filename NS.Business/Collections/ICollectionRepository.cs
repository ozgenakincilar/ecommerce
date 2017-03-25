using NS.Orm;
using System.Collections.Generic;

namespace NS.Business.Collections
{
    public interface ICollectionRepository
    {
        IList<Collection> GetActiveCollections();
    }
}
