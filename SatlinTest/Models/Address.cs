using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SatlinTest.Models
{
    public class Address
    {
        public int id { get; set; }
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public int geoId { get; set; }
        public Geo geo { get; set; }
    }
}
