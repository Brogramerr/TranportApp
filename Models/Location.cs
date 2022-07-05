using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportApp.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; } 

        public Location(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
