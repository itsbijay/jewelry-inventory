using System;
using System.Collections.Generic;
using System.Linq;

namespace Connections
{
    public interface ICustomerService
    {
        CustomerResponse SaveCustomer(CustomerRequest newCustomer);
        Customer GetCustomerByCode(String customerId);
        IQueryable<Customer> GetAllCustomers();
        IList<CustomerItem> GetCustomersList();
        IQueryable<Customer> GetActiveCustomers();
        IList<TransactionLookup> MemoLookupByCustomer(string customerId);
    }
}