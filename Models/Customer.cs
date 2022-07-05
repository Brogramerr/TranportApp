using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.Enums;

namespace TransportApp.Models
{

    
    public class Customer:Person
    {

        public string CustomerNo { get; set; }
        public decimal Wallet { get; set; }

        public Customer()
        {

        }

        public Customer(int id, string firstName, string lastName, Gender gender, string password, string email, string address, string phoneNo, string nextOfKin, DateTime dob) :
        base(id, firstName, lastName, gender, password, email, address, phoneNo, nextOfKin, dob)
        {
            CustomerNo = $"CUS{Guid.NewGuid().ToString().Replace("-", " ").Substring(0, 5).ToUpper()}";
            Wallet = 0m;
        }


    }
}
