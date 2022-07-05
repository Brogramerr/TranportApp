using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.Models;
using TransportApp.Enums;

namespace TransportApp.Repository
{
    public class BookingRepo
    {
        LocationRepo locationRepo;
        Customer customer = new Customer();
        DriverRepo driverRepo = new DriverRepo();
        CustomerRepo customerRepo = new CustomerRepo();
        Driver driver = new Driver();
        StaffRepo staffRepo = new StaffRepo();
        TripRepo tripRepo = new TripRepo();
        int count = 0;
        //Trip trip = new Trip();

        public Trip OrderRide(string startingLocation, string stopLocation, Customer customer)
        {

            driverRepo.GetAvailableDriver(startingLocation);
            driverRepo.PrintDrivers(startingLocation);
            var referenceNo = $"REF{Guid.NewGuid().ToString().Replace("-", " ").Substring(0, 5).ToUpper()}";
            Console.WriteLine("Enter Driver Id");
            var id = int.Parse(Console.ReadLine());
            var driver = driverRepo.GetDriverById(id);
            if (driver != null)
            {
                var startTime = DateTime.Now;
                //var startTime = time.TimeOfDay;
                driver.Status = Status.NotAvailable;
                Console.WriteLine($"You Have Successfully Ordered a ride of Ref {referenceNo}");
                tripRepo.AddTrip(count, startTime, driver, customer, startingLocation, stopLocation, referenceNo);
                count++;
                
                //return new Trip();
               
            }
            return null;
        }

        public void OnArrival(string tripId)
        {
            //Trip trip = new Trip();
            var trip = tripRepo.GetTripByReference(tripId);
            trip.EndTime = DateTime.Now;
            var price = trip.GetPrice();
            
            while (customer.Wallet < price)
            {
                Console.WriteLine("Insuficient fund \n Kindly fund your wallet");
                customerRepo.FundWallet(customer);
            }
            customer.Wallet -= price;
            var charges = 0.02m * price;
            driver.Wallet += price - charges;
            staffRepo.CompanyWallet += charges;
            Console.WriteLine($" Passenger Has successfully paid for Their ride \n Your Current Account Balance is {driver.Wallet}");
            driver.DriverLocation = trip.EndLocation;
            driver.Status = Status.Available;
            
        }

       



    }
}
