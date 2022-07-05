using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.Enums;
using TransportApp.Models;

namespace TransportApp.Repository
{
    public class CustomerRepo
    {
        public static int myindex = 1;
        private static int count = 1;
        public static Customer[] customers = new Customer[50];


        public CustomerRepo()
        {
            var customer = new Customer(1, "Yasir", "Fagbolade", Gender.Male, "password", "fagbolade@", "abk", "08099229933",
            "Boss Wife", DateTime.Parse("1960-06-20"));
            customers[0] = customer;
        }
        

        public void Register(string firstName, string lastName, Gender gender, string password,
        string email, string address, string phoneNo, string nextOfKin, DateTime dob)
        {
            var customer = new Customer(count, firstName, lastName, gender, password, email, address, phoneNo, nextOfKin, dob);
            customers[myindex] = customer;
            Console.WriteLine($"You Have successfully created an account and your customer number is {customer.CustomerNo}");
            //Console.WriteLine($"You Have Been Given a bonus of {customer.Wallet}");
            count++;
            myindex++;
        }

        public Customer Login(string email, string password)
        {
            var customer = GetCustomer(email);
            if (customer != null && customer.Password == password)
            {
                return customer;
            }
            return null;
        }
        public Customer GetCustomer(string email)
        {
            for (int i = 0; i < myindex; i++)
            {
                if (customers[i].Email == email)
                {
                    return customers[i];
                }

            }
            return null;
        }

        public void FundWallet(Customer customer)
        {
            Console.Write("Enter Amount you want to credit");
            decimal amount = decimal.Parse(Console.ReadLine());
            customer.Wallet += amount;
            Console.WriteLine($"You Have Successfully Funded Yoor Wallet And Your Balance is {customer.Wallet}");
        }

    }
}
