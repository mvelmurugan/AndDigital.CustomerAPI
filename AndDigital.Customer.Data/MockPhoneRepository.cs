using System;
using System.Collections.Generic;
using System.Text;
using AndDigital.Customer.Models;
using System.Linq;

namespace AndDigital.Customer.Data {
    public class MockPhoneRepository : IPhoneRepository {
        static List<AndDigital.Customer.Models.Phone> items;

        static MockPhoneRepository() {
            items = new List<Phone> {
                new Phone { ID = 1, PhoneNumber = "1234567890", IsActive=true , CreatedBy = 1, CreatedOn = DateTime.UtcNow },
                new Phone { ID = 2, PhoneNumber = "98745632", IsActive=true , CreatedBy = 1, CreatedOn = DateTime.UtcNow },
                new Phone {ID = 3, PhoneNumber = "1654564546", IsActive=true , CreatedBy = 1, CreatedOn = DateTime.UtcNow},
                new Phone{ ID = 4, PhoneNumber = "1234567890", IsActive=true , CreatedBy = 1, CreatedOn = DateTime.UtcNow },
                new Phone{ID = 5, PhoneNumber = "9874563210", IsActive=false , CreatedBy = 1, CreatedOn = DateTime.UtcNow},
                new Phone{ID = 6, PhoneNumber = "9632587410", IsActive=true , CreatedBy = 1, CreatedOn = DateTime.UtcNow },
                new Phone{ID = 7, PhoneNumber = "65415641654", IsActive=true , CreatedBy = 1, CreatedOn = DateTime.UtcNow}
            };
        }

        public IEnumerable<Phone> GetPhones() {
            return items;
        }

        public IEnumerable<Phone> GetPhones(List<long> ids) {
            return items.Where(item => ids.Contains(item.ID.Value));
        }

        public Phone GetPhone(string phoneNumber) {
            return items.FirstOrDefault(p => p.PhoneNumber == phoneNumber);
        }

        public Phone SavePhone(string phoneNumber) {
            var result = new Phone { ID = items.Count + 1, IsActive = false, PhoneNumber = phoneNumber };
            items.Add(result);
            return result;
        }

    }
}
