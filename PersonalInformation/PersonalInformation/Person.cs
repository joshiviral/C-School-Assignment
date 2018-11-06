using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalInformation
{
    class Person
    {
        public static int personId;
        public int PersonId { get; set; }
        public string type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int roomNo { get; set; }
        public string address { get; set; }
        public string phoneNummber { get; set; }
        public string EmailAddress { get; set; }
        public string City { get; set; }
        public Person(int roomNo, string personType, string FirstName, string MiddleName, string LastName, string EmailAddress, string City,string address,string phoneNummber)
        {
            PersonId = Interlocked.Increment(ref personId);
            this.PersonId = PersonId;
            this.roomNo = roomNo;
            this.type = personType;
            this.FirstName = FirstName;
            this.phoneNummber = phoneNummber;
            this.address = address;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
            this.EmailAddress = EmailAddress;
            this.City = City;

        }
    }
}
