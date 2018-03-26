using System;
using System.Collections;


namespace AndDigital.Customer.Models
{
    /// <summary>
    /// This is Base model for the customer. We can have all the common Properties and Methods in this class.
    /// </summary>
    public class BaseModel
    {
        public long? ID { get; set; }

        public DateTime CreatedOn { get; set; }

        public long CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public long? ModifiedBy { get; set; }

    }//class
}//namespace
