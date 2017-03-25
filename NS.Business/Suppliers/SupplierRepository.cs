using System.Collections.Generic;
using NS.Orm;
using System.Linq;

namespace NS.Business.Suppliers
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly NorthwindEntities _northwindEntityDataModel;
        public SupplierRepository(NorthwindEntities northwindEntityDataModel)
        {
            _northwindEntityDataModel = northwindEntityDataModel;
        }

        public IList<Supplier> List()
        {
            return _northwindEntityDataModel.Suppliers.ToList();
        }
    }
}
