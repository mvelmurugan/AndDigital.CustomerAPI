using System;
using System.Collections.Generic;
using System.Text;
using AndDigital.Customer.Models;
using System.Linq;

namespace AndDigital.Customer.Data
{
    public class MockCustomerRepository : ICustomerRepository
    {
        static List<AndDigital.Customer.Models.Customer> items;

        static MockCustomerRepository()
        {
            items = new List<AndDigital.Customer.Models.Customer> {
            new AndDigital.Customer.Models.Customer { ID = 1, FirstName = "Mark", LastName = "Simon", CreatedBy = 1, CreatedOn = DateTime.UtcNow ,
                PhoneNumbers = new List<long> {1}
            },

             new AndDigital.Customer.Models.Customer { ID = 2, FirstName = "Tom", LastName = "Will", CreatedBy = 1, CreatedOn = DateTime.UtcNow ,
                PhoneNumbers = new List<long> {2}
            },

              new AndDigital.Customer.Models.Customer { ID = 3, FirstName = "James", LastName = "Steen", CreatedBy = 1, CreatedOn = DateTime.UtcNow ,
                PhoneNumbers = new List<long> {3 }
            },

              new AndDigital.Customer.Models.Customer { ID = 4, FirstName = "Richard", LastName = "Philips", CreatedBy = 1, CreatedOn = DateTime.UtcNow ,
                PhoneNumbers = new List<long> {4, 5, 6}
            },

                new AndDigital.Customer.Models.Customer { ID = 5, FirstName = "Bill", LastName = "R", CreatedBy = 1, CreatedOn = DateTime.UtcNow ,
                PhoneNumbers = new List<long> { 7 }
            },
                new AndDigital.Customer.Models.Customer { ID = 6, FirstName = "Bill", LastName = "R", CreatedBy = 1, CreatedOn = DateTime.UtcNow      }

            };
        }


        public AndDigital.Customer.Models.Customer SavePhone(long customerId, Phone item)
        {
            var customer = GetCustomer(customerId);
            customer.PhoneNumbers.Add(item.ID.Value);
            return customer;
        }


        public AndDigital.Customer.Models.Customer GetCustomer(long cusomerId)
        {
            return items
                    .Where(customer => customer.ID == cusomerId)
                    .FirstOrDefault();
        }

        public IEnumerable<AndDigital.Customer.Models.Customer> GetCustomers()
        {
            return items;                    
                   
        }

        public AndDigital.Customer.Models.Customer DeleteCustomer(long customerId)
        {
            var customers = GetCustomers();
            customers.ToList().RemoveAll(p => p.ID == customerId);             
            return new AndDigital.Customer.Models.Customer();
        }

        public AndDigital.Customer.Models.Customer AddCustomer(AndDigital.Customer.Models.Customer customer)
        {
            items.Add(customer);
            return customer;
        }


    }
}
