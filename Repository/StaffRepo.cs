using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.Enums;
using TransportApp.Models;

namespace TransportApp.Repository
{
    public class StaffRepo
    {
        private static int count = 1;
        private static int Myindex = 1;
        public static Staff[] staffs = new Staff[50];
        public  decimal CompanyWallet = 0;

        public StaffRepo()
        {
            var staff = new Staff(1, "Yasir", "Fagbolade", Gender.Male, "password", "fagbolade@gmail.com", "abk", "08099229933",
            "Boss Wife", DateTime.Parse("1960-06-20"), Role.Manager);
            staffs[0] = staff;
        }
        public void AddNewStaff(string fName, string lName, string email, Gender gender, DateTime dateOfBirth,
        string address, string phone, string password, string nextOfKin, Role role)
        {
            int id = ++count;
            Staff staff = new Staff(id, fName, lName, gender, password, email, address, phone, nextOfKin, dateOfBirth, role);
            staffs[Myindex] = staff;
            Myindex++;

        }

        public Staff Login(string email, string password)
        {
            var staff = GetStaff(email);
            if (staff != null && staff.Password == password)
            { 
                return staff;
            }
            return null;
        }

        public Staff GetStaff(string email)
        {
            for (int i = 0; i < Myindex; i++)
            {
                if (staffs[i].Email == email)
                {
                    return staffs[i];
                }

            }
            return null;
        }

        public void GetCompanyWalletBalance()
        {
            Console.WriteLine($"The Amount in the company walllet is {CompanyWallet}") ;
        }
    }
}
