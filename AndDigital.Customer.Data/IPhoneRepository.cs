using System;
using AndDigital.Customer.Models;
using System.Collections.Generic;

namespace AndDigital.Customer.Data
{
    public interface IPhoneRepository
    {
        IEnumerable<Phone> GetPhones();

        Phone GetPhone(string phoneNumber);

        IEnumerable<Phone> GetPhones(List<long> ids);

        Phone SavePhone(string phoneNumber);
    }
}
