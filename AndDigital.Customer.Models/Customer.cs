using System;
using System.Collections.Generic;
using System.Text;

namespace AndDigital.Customer.Models
{
    public class Customer  : BaseModel
    {

      public Customer()
        {
            PhoneNumbers = new List<long>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get {
                return FirstName + "," + LastName;
            }
            private set {

            }
        }


        public List<long> PhoneNumbers { get; set; }
    }
}
