using System;
using System.Collections.Generic;
using System.Linq;

namespace Connections
{
    public class SupplierService : ServiceBase, ISupplierService
    {
        public SupplierResponse SaveSupplier(SupplierRequest request)
        {
            var response = new SupplierResponse();
            var supplier = request.Supplier;

            var isCodeExists = DbContext.Suppliers.Any(x => x.SupplierCode == supplier.SupplierCode);
            var isVatExists = DbContext.Suppliers.Any(x => x.VATNumber == supplier.VATNumber);
            var isCstExists = DbContext.Suppliers.Any(x => x.CSTNumber == supplier.CSTNumber);

            if (supplier.SupplierId == 0)
            {
                if (isCodeExists)
                    response.AddValidationError("SupplierCode", "Supplier code already exists!");

                if (isVatExists || isCstExists)
                    response.AddValidationError("VATNumber", "VAT/ CST number already exists!");

                var next = DbContext.Suppliers.Max(x => (int?)x.SupplierId) ?? 0;

                supplier.SupplierCode = String.Concat(Constants.SUPPLIERMASTERPREFIX, ++next);
            }
            else
            {
                var OriginalValue = GetOriginalRecord(supplier);

                if (supplier.SupplierCode != (String)OriginalValue["SupplierCode"] && isCodeExists)
                    response.AddValidationError("SupplierCode", "Supplier code already exists!");

                if ((supplier.VATNumber != (String)OriginalValue["VATNumber"] && isVatExists)
                    ||
                    (supplier.CSTNumber != (String)OriginalValue["CSTNumber"] && isCstExists)
                    )
                    response.AddValidationError("VATNumber", "VAT/ CST number already exists!");
            }

            if (response.IsValid == false)
                return response;

            supplier.AccessedBy = LocalStore.CurrentUser.UserId;
            supplier.AccessedDate = DateTime.Now;

            if (supplier.SupplierId == 0)
                DbContext.Suppliers.AddObject(supplier);

            // Save user
            DbContext.SaveChanges();

            return response;
        }

        public Supplier GetSupplierByCode(String code)
        {
            return DbContext.Suppliers.SingleOrDefault(x => x.SupplierCode == code);
        }

        public IQueryable<Supplier> GetAllSuppliers()
        {
            return DbContext.Suppliers;
        }

        public IQueryable<Supplier> GetActiveSuppliers()
        {
            return DbContext.Suppliers.Where(x=>x.SupplierStatus_Enum == (short)SupplierStatus.Active);
        }

        public IList<SupplierItem> GetSuppliersList()
        {
            IList<SupplierItem> supplierList = new List<SupplierItem>();
            var suppliers = DbContext.Suppliers.Select(su => new { su.SupplierCode, su.ContactName }).ToList();

            supplierList.Add(new SupplierItem { SupplierCode = "0", ContactName = "-----Select All Suppliers-----" });
            foreach (var sup in suppliers)
            {
                supplierList.Add(new SupplierItem { SupplierCode = sup.SupplierCode, ContactName = sup.ContactName });
            }

            return supplierList;
        }
    }
}
