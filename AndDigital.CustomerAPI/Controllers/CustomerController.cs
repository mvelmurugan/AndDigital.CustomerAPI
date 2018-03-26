using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AndDigital.Customer.Components;
using AndDigital.Customer.Models;

namespace AndDigital.CustomerAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Customer")]
    public class CustomerController : Controller
    {

        CustomerComponent customerComponent;
        public CustomerController(CustomerComponent customerComponent)
        {
            this.customerComponent = customerComponent;
        }

       
        [HttpGet]
        public IEnumerable<Phone> Get()
        {
            return customerComponent.GetPhoneNumbers();
        }

        
        [HttpGet("{id}")]
        public IEnumerable<Phone> Get(long id)
        {
            return customerComponent.GetPhoneNumbers(id);
        }

        
         
        [HttpPost]
        public AndDigital.Customer.Models.Customer Post([FromForm] AndDigital.Customer.Models.Customer customer, [FromForm] string phoneNumber)
        {
            if (customer.ID.HasValue)
            {
                return customerComponent.UpdateCustomer(customer,phoneNumber);
            }
            return customerComponent.AddNewCustomer(customer, phoneNumber);           
        }
        
         
        [HttpPut]
        public Phone Put([FromForm]  string phoneNumber)
        {
            return customerComponent.Activate(phoneNumber);
        }
        
        [HttpDelete]        
        public object Delete([FromForm] long? customerId , string phoneNumber )
        {
            if(customerId != null)                
            {
                if(customerId.HasValue && customerId.Value != 0 )
                {
                    return customerComponent.DeleteCustomer(customerId.Value);
                }                

            } else if (phoneNumber.Trim() != string.Empty)
                {
                    return customerComponent.DeleteCustomerPhones(phoneNumber);
                }
            throw new InvalidOperationException("Either Customer ID or Phone Number is required");

        }
    }
}
