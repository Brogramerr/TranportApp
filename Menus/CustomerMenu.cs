using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.Repository;
using TransportApp.Enums;

namespace TransportApp.Menus
{

    public class CustomerMenu
    {
        CustomerRepo customerRepo = new CustomerRepo();
        BookingRepo bookingRepo = new BookingRepo();


        public void Menu()
        {
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
            Console.WriteLine("Enter 0 To Go Back: ");
        }

        

        private void RegistrationMenu()
        {
            Console.WriteLine("Enter Your First Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Your Last Name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Your  Gender: 1 for Male\t2 for Female\t3 for i don't know ");
            int gender;
            while (!int.TryParse(Console.ReadLine(), out gender))
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
            customerRepo.Register(firstName, lastName, (Gender)gender, password, email, address, phoneNumber, nextOfKin, dateOfBirth);
        }

        private void LoginMenu()
        {
            Console.WriteLine("Enter Your Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Your Password: ");
            string password = Console.ReadLine();
            var customer = customerRepo.Login(email, password);
            if(customer != null)
            {
                bool exit = false;
                while (!exit)
                {
                    PrintSubMenu();
                    int op = int.Parse(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            Console.WriteLine("Enter Starting Location");
                            string startingLocation = Console.ReadLine();
                            Console.WriteLine("Enter Stoping Location");
                            string stopingLocation = Console.ReadLine();
                            bookingRepo.OrderRide(startingLocation, stopingLocation, customer);
                            
                            break;
                        case 2:
                            customerRepo.FundWallet(customer);
                            break;
                        case 0:
                            exit = true;
                            break;
                        default:
                            exit = true;
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
            Console.WriteLine("Enter 1 To Order a ride: ");
            Console.WriteLine("Enter 2 fund your wallet: ");
            Console.WriteLine("Enter 0 To Go Back To The Previous Menu: ");
        }


        public void HookScreen()
        {
            Console.WriteLine("Invalid input, Enter any key to write again: ");
            Console.ReadKey();
        }
    }
}
