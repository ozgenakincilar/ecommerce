using NS.Orm;
using System.Collections.Generic;

namespace NS.Business.Suppliers
{
    public interface ISupplierRepository
    {
        IList<Supplier> List();
    }
}
