using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportApp.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Driver driver;
        public Customer Customer;
        public decimal Price { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public string Reference { get; set; }

        //int [] trips = new Trip[20];

        public Trip()
        {

        }

        public Trip(int id,DateTime startTime, Driver driver, Customer customer, string startLocation, string endLocation,string reference)
        {
            Id = id;
            StartTime = startTime;
            Customer = customer; 
            StartLocation = startLocation;
            EndLocation = endLocation;
            Reference = reference;
            //Price = price;
        }

        public decimal GetPrice()
        {
            return (EndTime.Ticks - StartTime.Ticks) * (0.01m) ;
        }

        
    }
}
