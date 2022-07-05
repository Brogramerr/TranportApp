using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.Enums;

namespace TransportApp.Models
{
    public class Staff:Person
    {
        public string StaffNo { get; set; }
        public Role Role { get; set; }

        public Staff(int id, string firstName, string lastName, Gender gender, string password, string email, string address, string phoneNo, string nextOfKin, DateTime dob, Role role) :
       base(id, firstName, lastName, gender, password, email, address, phoneNo, nextOfKin, dob)
        {
            StaffNo = $"ST{Guid.NewGuid().ToString().Replace("-", " ").Substring(0, 5).ToUpper()}";
            Role = role;
        }
    }
}
