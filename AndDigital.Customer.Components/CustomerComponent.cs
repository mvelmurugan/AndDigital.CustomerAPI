using System;
using System.Linq;
using AndDigital.Customer.Data;
using AndDigital.Customer.Models;
using System.Collections.Generic;

namespace AndDigital.Customer.Components {
    public class CustomerComponent {
        ICustomerRepository customerRepository;
        IPhoneRepository phoneRepository;


        public CustomerComponent(ICustomerRepository customerRepository, IPhoneRepository phoneRepository) {
            this.customerRepository = customerRepository;
            this.phoneRepository = phoneRepository;
        }

        public IEnumerable<Phone> GetPhoneNumbers(long customerId) {
              if (customerId == 0) throw new InvalidOperationException("In Valid Customer ID.");
            return phoneRepository.GetPhones(customerRepository.GetCustomer(customerId).PhoneNumbers);
        }


        public IEnumerable<Phone> GetPhoneNumbers() {
            return phoneRepository.GetPhones();
        }


        public Phone Activate(string phoneNumber) {            
            var phone = phoneRepository.GetPhone(phoneNumber);
            if (phone == null) throw new InvalidOperationException("In Valid Phone Number.");
            phone.IsActive = true;
            return phone;
        }


        public AndDigital.Customer.Models.Customer DeleteCustomer(long customerId) {
              if (customerId == 0) throw new InvalidOperationException("In Valid Customer ID.");
            return customerRepository.DeleteCustomer(customerId);
        }


        public Phone DeleteCustomerPhones(string phoneNumber) {            
            var phone = phoneRepository.GetPhone(phoneNumber);
            if (phone == null) throw new InvalidOperationException("In Valid Phone Number.");
            phone.IsActive = false;
            return phone;
        }


        public AndDigital.Customer.Models.Customer AddNewCustomer(AndDigital.Customer.Models.Customer customer, string phoneNumber) {
           
            if(customer == null) throw new InvalidOperationException("Object Cannot be Null");
            if(phoneNumber.Trim() == string.Empty) throw new InvalidOperationException("In Valid Phone Number.");
            int customerId = customerRepository.GetCustomers().Count();
            var phone = phoneRepository.SavePhone(phoneNumber);
            AndDigital.Customer.Models.Customer item = new Models.Customer {
                ID = customerId + 1,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                CreatedBy = 1,
                CreatedOn = DateTime.UtcNow
            };
            item.PhoneNumbers.Add(phone.ID.Value);
            return customerRepository.AddCustomer(item);
        }



        public AndDigital.Customer.Models.Customer UpdateCustomer(AndDigital.Customer.Models.Customer customer, string phoneNumber) {
             if(customer == null) throw new InvalidOperationException("Object Cannot be Null");
            if(phoneNumber.Trim() == string.Empty) throw new InvalidOperationException("In Valid Phone Number.");
            var result = customerRepository.GetCustomer(customer.ID.Value);
            result.FirstName = customer.FirstName;
            result.LastName = customer.LastName;
            result.ModifiedBy = 1;
            result.ModifiedOn = DateTime.UtcNow;
            var phones = phoneRepository.GetPhones(result.PhoneNumbers);
            if (phones.Count(p => p.PhoneNumber == phoneNumber) > 0) return result;
            result.PhoneNumbers.Add(phoneRepository.SavePhone(phoneNumber).ID.Value);
            return result;
        }


    }
}
