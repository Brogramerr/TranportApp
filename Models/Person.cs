using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.Enums;

namespace TransportApp.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; }
        public string NextOfKin { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Person()
        {

        }

        public Person(int id, string firstName, string lastName, Gender gender, string password, string email, string address, string phoneNo, string nextOfKin, DateTime dob)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Email = email;
            Address = address;
            Password = password;
            PhoneNo = phoneNo;
            DateOfBirth = dob;
        }

        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
