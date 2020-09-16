using Newtonsoft.Json;
using System;

namespace DynamicQuery.Models
{
    public class PersonRecord
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Country { get; set; }
        public string EducationCountry { get; set; }
        public string EducationCity { get; set; }
        public string EducationLevel { get; set; }
    }

}
