using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.Models;

namespace TransportApp.Repository
{
    public class LocationRepo
    {
        private static int count = 0;
        private static int myIndex = 0;
        public static Location [] locations = new Location[50];


        public void AddLocation(string name)
        {
            int id = count++;
            Location location = new Location(id, name);
            locations[myIndex] = location;
            myIndex++;
            
        }


        public void GetLocation(string location)
        {
            for (int i = 0; i < myIndex; i++)
            {
                if (location == null)
                {
                    Console.WriteLine("The Location Entered is not Available \n Kindly Enter Another Location");
                }
                else Console.WriteLine("You Have Successfully picked a location");

            }
        }

    }
}
