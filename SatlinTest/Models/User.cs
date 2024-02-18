using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SatlinTest.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public int addressId { get; set; }
        public Address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public int companyId { get; set; }
        public Company company { get; set; }
    }
}
