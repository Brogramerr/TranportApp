using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.Enums;
using TransportApp.Repository;

namespace TransportApp.Menus
{
    public class StaffMenu
    {
        StaffRepo staffRepo = new StaffRepo() ;
        DriverRepo driverRepo = new DriverRepo() ;  
        LocationRepo locationRepo = new LocationRepo(); 


        public void Menu()
        {
            StaffLogin();
           

        }
        public void ManagerMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Enter 1 To Add New Staff");
                Console.WriteLine("Enter 2 to Check Company Acccount");
                Console.WriteLine("Enter 3 To Check List of all drivers");
                Console.WriteLine("Enter 4 To Check List of all drivers");
                Console.WriteLine("Enter 5 To Delete A Staff: ");
                Console.WriteLine("Enter 6 To Delete A Driver: ");
                Console.WriteLine("Enter 0 To Logout: ");

                int op = int.Parse(Console.ReadLine());
                switch (op)
                {

                    case 1:
                        AddStaff();
                        break;
                    case 2:
                        staffRepo.GetCompanyWalletBalance();
                        break;
                    case 3:
                        driverRepo.GetAllDrivers();
                        break;
                    case 0:
                        exit = false;
                        break;


                    default:

                        break;
                }
            }
        }

        public void StaffLogin()
        {
            Console.WriteLine("Enter Your Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Your Password: ");
            string password = Console.ReadLine();
            var staff = staffRepo.Login(email, password);
            if (staff != null && staff.Role == Role.Manager)
            {
                ManagerMenu();
            }
            else if (staff != null && staff.Role == Role.Receptionist)
            {
                ;
            }
            else
                Console.WriteLine($"invalid email or password\nEnter any key to continue");
            Console.ReadKey();
        }


        public void AddStaff()
        {
            Console.WriteLine("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last Name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Your Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Your  Gender: 1 for Male\t2 for Female\t3 for i don't know ");
            int gender;
            while (!int.TryParse(Console.ReadLine(), out gender) && gender > 3 || gender < 1)
            {
                Console.WriteLine("Invalid input enter 1, 2 or 3");
            }

            Console.WriteLine("Enter  Password");
            string password = Console.ReadLine();
            Console.WriteLine("Enter Your Email");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Your Phone Number");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Your Next Of Kin");
            string nextOfKin = Console.ReadLine();
            Console.WriteLine("Enter Your Date Of Birth");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Role: ");
            int role;
            while (!int.TryParse(Console.ReadLine(), out role) && role > 2 || role < 1)
            {
                Console.WriteLine("Invalid input enter 1, 2 or 3");
            }


            staffRepo.AddNewStaff(firstName, lastName, email, (Gender)gender, date, address, phoneNumber, password,
            nextOfKin, (Role)role);




        }
        public void AddLocation()
        {
            Console.WriteLine("Enter Location Name: ");
            string name = Console.ReadLine();
            locationRepo.AddLocation(name);
            Console.WriteLine($"You Have Successfully Created A Location Route ");

        }
    }
}
