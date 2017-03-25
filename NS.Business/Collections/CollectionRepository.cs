using System.Collections.Generic;
using System.Linq;
using NS.Orm;

namespace NS.Business.Collections
{
    public class CollectionRepository : ICollectionRepository
    {
        private readonly NorthwindEntities _northwindEntityDataModel;
        public CollectionRepository(NorthwindEntities northwindEntityDataModel)
        {
            _northwindEntityDataModel = northwindEntityDataModel;
        }
        public IList<Collection> GetActiveCollections()
        {
            return _northwindEntityDataModel.Collections.Where(x => x.IsActive).ToList();
        }
    }
}
