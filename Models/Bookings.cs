using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApp.Enums;

namespace TransportApp.Models
{
    public class Bookings
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public Status Status { get; set; }


    }
}
