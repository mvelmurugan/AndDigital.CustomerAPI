using System;
using AndDigital.Customer.Models;
using System.Collections.Generic;

namespace AndDigital.Customer.Data
{
    public interface ICustomerRepository
    {
        AndDigital.Customer.Models.Customer GetCustomer(long cusomerId);
        IEnumerable<AndDigital.Customer.Models.Customer> GetCustomers();
        AndDigital.Customer.Models.Customer SavePhone(long customerId, Phone item);
        AndDigital.Customer.Models.Customer DeleteCustomer(long customerId);
        AndDigital.Customer.Models.Customer AddCustomer(AndDigital.Customer.Models.Customer customer);
    }
}
