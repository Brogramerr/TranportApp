using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.Enums;
using TransportApp.Models;
using TransportApp.Repository;


namespace TransportApp.Menus
{
    public class DriverMenu
    {
        DriverRepo driverRepo = new DriverRepo();
        LocationRepo locationRepo = new LocationRepo();
        Location location;
        Driver driver;
        BookingRepo bookingRepo = new BookingRepo();
        Trip trip;
        TripRepo tripRepo = new TripRepo();


        public void Menu()
        {
            //PrintMenu();
            bool exit = false;
            while (!exit)
            {
                PrintMenu();
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        RegistrationMenu();
                        break;
                    case 2:
                       LoginMenu();
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        exit = false;
                        break;
                }
            }
        }

        public void PrintMenu()
        {
            Console.WriteLine("Enter 1 To  Register: ");
            Console.WriteLine("Enter 2 to Login: ");
            Console.WriteLine("Enter 0 To Go Back To Main Menu: ");
        }

        private void RegistrationMenu()
        {
            Console.WriteLine("Enter Your First Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Your Last Name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Your  Gender: 1 for Male\t2 for Female\t3 for i don't know ");
            int gender;
            while (!int.TryParse(Console.ReadLine(), out gender) && gender > 4 || gender < 1)
            {
                Console.WriteLine("Invalid input enter 1, 2 or 3");
            }

            Console.WriteLine("Enter  Password");
            string password = Console.ReadLine();
            Console.WriteLine("Enter Your Email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Your Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Your Phone Number");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Your Next Of Kin");
            string nextOfKin = Console.ReadLine();
            Console.WriteLine("Enter Your Date Of Birth (YYYY-MM-DD)");
            DateTime dateOfBirth;
            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
            {
                Console.WriteLine("Invalid Format enter (YYYY-MM-DD) ");
            }
            Console.WriteLine("Enter Your Location");
            string location = Console.ReadLine();
            locationRepo.AddLocation(location);
            
            driverRepo.Register(firstName, lastName, (Gender)gender, password, email, address, phoneNumber, nextOfKin, dateOfBirth,location);
        }

        private void LoginMenu()
        {
            Console.WriteLine("Enter Your Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Your Password: ");
            string password = Console.ReadLine();
            var driver = driverRepo.Login(email, password);
            if (driver != null)
            {
                bool exit = false;
                while (!exit)
                {
                    PrintSubMenu();
                    int op = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            Console.WriteLine("Enter Trip Reference Number: ");
                            string referenceNumber = Console.ReadLine();
                            bookingRepo.OnArrival(referenceNumber);
                            Menu();
                            break;
                        case 2:
                            driverRepo.GetDriverWalleBalance(driver);
                            Menu();
                            break;
                        case 0:
                            exit = true;
                            break;
                        default:
                            HookScreen();
                            break;
                    }
                }
            }
            else
                Console.WriteLine($"invalid email or password\nEnter any key to continue");
            Console.ReadKey();
        }

        public void PrintSubMenu()
        {
            Console.WriteLine("Enter 1 To End A ride: ");
            Console.WriteLine("Enter 2 to check your Wallet balance: ");
            Console.WriteLine("Enter 0 To Go Back To LogOut: ");
        }

        public void HookScreen()
        {
            Console.WriteLine("Invalid Input \n Enter Any Key to Continue");
            Console.ReadLine();
        }

    }
}
