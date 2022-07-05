using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.Enums;
using TransportApp.Models;

namespace TransportApp.Repository
{
    public class DriverRepo
    {
        private static int count = 1;
        private static int myIndex = 1;
        Location location;
        Driver driver = new Driver();
        LocationRepo locationRepo;

        public static Driver [] drivers = new Driver [50];


        public DriverRepo()
        {
            var driver = new Driver(1, "Yasir", "Fagbolade", Gender.Male, "password", "fagbolade@", "abk", "08099229933",
            "Boss Wife", DateTime.Parse("1960-06-20"),"camp");
            drivers[0] = driver;
        }

        public void Register(string firstName, string lastName, Gender gender, string password,
       string email, string address, string phoneNo, string nextOfKin, DateTime dob,string location)
        {
            var driver = new Driver(count,firstName,lastName,gender,password,email,address,phoneNo,nextOfKin,dob,location);
            drivers[myIndex] = driver;
            Console.WriteLine($"You Have successfully created an account");
            
            count++;
            myIndex++;
        }
        public Driver Login(string email, string password)
        {
            var driver = GetDriver(email);
            if (driver != null && driver.Password == password)
            {
                return driver;
            }
            return null;
        }

        public Driver GetDriver(string email)
        {
            for (int i = 0; i < myIndex; i++)
            {
                if (drivers[i].Email == email)
                {
                    return drivers[i];
                }

            }
            return null;
        }

        public Driver GetAvailableDriver(string location)
        {
            
            for (int i = 0; i < myIndex; i++)
            {
                if (drivers[i] != null && drivers[i].DriverLocation == location && drivers[i].Status == Status.Available)
                {
                    return drivers[i];
                }
    
            }
            return null;

        }
        public Driver GetDriverById(int id)
        {
            for (int i = 0; i < myIndex; i++)
            {
                if ((drivers[i] != null) && drivers[i].Id == id)
                {
                    return drivers[i];
                }

            }
            return null;
        }

        public void GetDriverWalleBalance(Driver driver)
        {
            Console.WriteLine($" Your Wallet Balance Is {driver.Wallet}");
        }

        public void PrintDrivers(string location)
        {
           var driverProfile = GetAvailableDriver(location);
            Console.WriteLine($"{driverProfile.FullName()} + {driverProfile.Id}");
        }

        public void GetAllDrivers()
        {
            for (int i = 0; i < myIndex; i++)
            {
                if (drivers[i] != null)
                {
                    Console.WriteLine($"{drivers[i].Id} {drivers[i].FullName()} ");
                }

            }
        }


    }
}
