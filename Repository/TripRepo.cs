using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.Enums;
using TransportApp.Models;

namespace TransportApp.Repository
{
    public class TripRepo
    {
        private  int count = 1;
        private  int myIndex = 1;
        Location location;

        public Trip[] trips = new Trip[10];

        public TripRepo()
        {
            var trip = new Trip(1, DateTime.Now, new Driver(1, "Yasir", "Fagbolade", Gender.Male, "password", "fagbolade@", "abk", "08099229933",
            "Boss Wife", DateTime.Parse("1960-06-20"), "camp"), new Customer(1, "Yasir", "Fagbolade", Gender.Male, "password", "fagbolade@", "abk", "08099229933",
            "Boss Wife", DateTime.Parse("1960-06-20")), "camp", "asero", "101");
            trips[0] = trip;
        }

        public void AddTrip(int id, DateTime startTime, Driver driver, Customer customer, 
            string startLocation, string endLocation, string reference)
        {
            var trip = new Trip(count, startTime, driver, customer, startLocation, endLocation, reference);
            
            trips[myIndex] = trip;
            myIndex++;
            count++;

        }

        public Trip GetTripByReference(string referenceNum)
        {
            for(int i = 0; i < myIndex; i++)
            {
                if (trips[i].Reference == referenceNum)
                {
                    return trips[i];
                }
            }
            return null;
        }



    }
}
