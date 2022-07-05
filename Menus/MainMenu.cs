using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportApp.Menus
{
    public class MainMenu
    {
        CustomerMenu customerMenu = new CustomerMenu();
        StaffMenu staffMenu = new StaffMenu();
        DriverMenu driverMenu = new DriverMenu();


        public void Menu()
        {
            Welcome();
            bool exit = false;
            while (!exit)
            {
                PrintMenu();
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        customerMenu.Menu();
                        break;
                    case 2:
                        driverMenu.Menu();
                        break;
                    case 3:
                        staffMenu.Menu();
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

        public void Welcome()
        {
            Console.WriteLine("================================================");
            Console.WriteLine("================================================");
            Console.WriteLine("================================================");
            Console.WriteLine("================================================");
            Console.WriteLine("\t \t WELCOME TO TRANSPORTER APP");
            Console.WriteLine("================================================");
            Console.WriteLine("================================================");
            Console.WriteLine("================================================");
            Console.WriteLine("================================================");
        }

        private void PrintMenu()
        {
            Console.WriteLine("Enter 1 Login(Passenger) ");
            Console.WriteLine("Enter 2 Login(Driver)");
            Console.WriteLine("Enter 3 Login(Staff)");
            Console.WriteLine("Enter 0 to Exit ");
        }

        public void HookScreen()
        {
            Console.WriteLine("Invalid Input \n Kindly Enter 1,2,3 or 0");
            Console.ReadKey();
        }
    }
}
