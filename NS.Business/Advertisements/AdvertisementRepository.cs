using System.Collections.Generic;
using System.Linq;
using NS.Orm;

namespace NS.Business.Advertisements
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly NorthwindEntities _northwindEntityDataModel;
        public AdvertisementRepository(NorthwindEntities northwindEntityDataModel)
        {
            _northwindEntityDataModel = northwindEntityDataModel;
        }
        public IList<Advertisement> GetActiveAdvertisements()
        {
            return _northwindEntityDataModel.Advertisements.Where(x => x.IsActive).ToList();
        }
    }
}
