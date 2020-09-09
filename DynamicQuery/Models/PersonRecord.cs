using Newtonsoft.Json;
using System;

namespace DynamicQuery.Models
{
    public class PersonRecord
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

}
