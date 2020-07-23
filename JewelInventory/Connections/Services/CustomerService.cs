using System;
using System.Collections.Generic;
using System.Linq;

namespace Connections
{
    public class CustomerService : ServiceBase, ICustomerService
    {
        public CustomerResponse SaveCustomer(CustomerRequest addCustomerRequest)
        {
            var customerResponse = new CustomerResponse();

            Customer customer = addCustomerRequest.Customer;
            var next = 0;

            var isCustomerCodeExists = DbContext.Customers.Any(c => c.CustomersCode == customer.CustomersCode);
            var isVATNoExists = DbContext.Customers.Any(c => c.VATNumber == customer.VATNumber);

            if (customer.CustomersId == 0)
            {
                if (isCustomerCodeExists)
                    customerResponse.AddValidationError("CustomerCode", "Customer Code already exists!");

                if (isVATNoExists)
                    customerResponse.AddValidationError("VATNumber", "VAT Number already exists!");

                if (DbContext.Customers.Count() != 0)
                {
                    next = DbContext.Customers.Max(x => x.CustomersId);
                }

                ++next;

                customer.CustomersCode = String.Concat(Constants.CUSTOMERMASTERPREFIX, next);
            }
            else
            {
                var OriginalValue = GetOriginalRecord(customer);

                if (customer.CustomersCode != (String)OriginalValue["CustomersCode"] && isCustomerCodeExists)
                    customerResponse.AddValidationError("CustomerCode", "Customer Code already exists!");

                if (customer.VATNumber != (String)OriginalValue["VATNumber"] && isVATNoExists)
                    customerResponse.AddValidationError("VATNumber", "VAT Number already exists!");
            }

            if (customerResponse.IsValid == false)
                return customerResponse;

            customer.AccessedBy = LocalStore.CurrentUser.UserId;
            customer.AccessedDate = DateTime.Now;

            if (customer.CustomersId == 0)
            {
                DbContext.Customers.AddObject(customer);
            }
            // Save user
            DbContext.SaveChanges();

            return customerResponse;
        }

        public Customer GetCustomerByCode(String customerCode)
        {
            Customer customer = DbContext.Customers.SingleOrDefault(x => x.CustomersCode == customerCode);
            return customer;
        }

        public IQueryable<Customer> GetAllCustomers()
        {
            return DbContext.Customers;
        }

        public IQueryable<Customer> GetActiveCustomers()
        {
            return DbContext.Customers
                .Where(x=>x.CustomesStatus_Enum == (short)CustomesStatus.Active);
        }

        public IList<CustomerItem> GetCustomersList()
        {
            IList<CustomerItem> customerList = new List<CustomerItem>();
            var customers = DbContext.Customers.Select(cu => new { cu.CustomersCode, cu.ContactName }).ToList();

            customerList.Add(new CustomerItem { CustomerCode = "0", ContactName = "-----Select All Customers-----" });
            foreach (var cust in customers)
            {
                customerList.Add(new CustomerItem { CustomerCode = cust.CustomersCode, ContactName = cust.ContactName });
            }

            return customerList;
        }

        public IList<TransactionLookup> MemoLookupByCustomer(string customerId)
        {
            return DbContext.TransactionLookups.Where(x => x.TransactionPartyRef == customerId
                            &&
                            (
                            x.TransactionType_Enum == (short)TransactionType.ApprovalTransaction
                            &&
                            x.JewelTransactions.Any(j => DbContext.JewelStockLedgers
                                                   .Any(l => l.JewelNumber == j.JewelNumber && l.StockStatus_Enum == (int)StockStatus.ItemOutOfStock && l.JewelState_Enum == (int)JewelState.OnApproval))
                            )
                            ).ToList();
        }
    }
}
