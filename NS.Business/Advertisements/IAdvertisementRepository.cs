using NS.Orm;
using System.Collections.Generic;

namespace NS.Business.Advertisements
{
    public interface IAdvertisementRepository
    {
        IList<Advertisement> GetActiveAdvertisements();
    }
}
