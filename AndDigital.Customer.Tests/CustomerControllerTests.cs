using AndDigital.Customer.Components;
using AndDigital.Customer.Data;
using AndDigital.Customer.Models;
using AndDigital.CustomerAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AndDigital.Customer.Tests {
    public class CustomerControllerTests {

        [Fact]
        public void Get_Without_CustomerId_Returns_All_Phone_Numbers() {
            var controller = GetController();
            var result = controller.Get();
            Assert.Equal(7, result.Count());
            Assert.Equal("1234567890", result.First().PhoneNumber);
        }

        [Fact]
        public void Get_With_CustomerId_Returns_Only_That_Customer_Phone_Numbers() {
            var controller = GetController();
            var result = controller.Get(4).ToList();
            Assert.Equal(3, result.Count());
            Assert.Equal("1234567890", result[0].PhoneNumber);
            Assert.Equal("9874563210", result[1].PhoneNumber);
            Assert.Equal("9632587410", result[2].PhoneNumber);
        }

        [Fact]
        public void Post_New_Customer_Should_Save_To_System() {
            var controller = GetController();
            var customer = new AndDigital.Customer.Models.Customer {
                FirstName = "FirstName", LastName = "LastName",
            };
            var result = controller.Post(customer, "12345");
            Assert.True(result.ID > 0);
        }

        [Fact]
        public void Activate_PhoneNumber_For_A_Customer_Should_Change_IsActive_To_True() {
            var controller = GetController();
            var phone = controller.Put("9874563210");
            
            Assert.True(phone.IsActive);
        }

        CustomerController GetController() {
            return new CustomerController(
                new CustomerComponent(
                    new MockCustomerRepository(),
                    new MockPhoneRepository()
                )
            );
        }


    }
}
