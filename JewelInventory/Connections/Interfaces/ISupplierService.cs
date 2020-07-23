using System;
using System.Collections.Generic;
using System.Linq;

namespace Connections
{
    public interface ISupplierService
    {
        SupplierResponse SaveSupplier(SupplierRequest request);
        Supplier GetSupplierByCode(String code);
        IQueryable<Supplier> GetAllSuppliers();
        IQueryable<Supplier> GetActiveSuppliers();
        IList<SupplierItem> GetSuppliersList();
    }
}