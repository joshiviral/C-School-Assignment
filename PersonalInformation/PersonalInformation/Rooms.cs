using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalInformation
{
    class Rooms
    {
        public static int roomID;
        public int rID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public string EmailAddress { get; set; }
        public string City { get; set; }
        public Rooms(string FirstName, string MiddleName, string LastName, string EmailAddress, string City)
        {
            rID = Interlocked.Increment(ref roomID);
            this.rID = rID;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
            this.EmailAddress = EmailAddress;
            this.City = City;
        }
    }
}