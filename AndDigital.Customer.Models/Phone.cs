using System;
using System.Collections.Generic;
using System.Text;

namespace AndDigital.Customer.Models
{
    public class Phone : BaseModel
    {

      public Phone()
        {
            
        }
       
        public bool IsActive { get; set; }       

        public string PhoneNumber { get; set; }
       
    }
}
