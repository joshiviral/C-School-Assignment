using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalInformation
{
    class Personal: Person
    {
        public Personal(int roomNo,string personType, string FirstName, string MiddleName, string LastName, string EmailAddress, string City,string address, string phonenumber) : base(roomNo,personType, FirstName, MiddleName, LastName, EmailAddress, City,address, phonenumber) { }
    }
}
