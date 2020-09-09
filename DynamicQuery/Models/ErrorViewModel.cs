using System;
using System.Collections.Generic;

namespace DynamicQuery.Models
{
    public static class PersonBuilder
    {
        public static List<PersonRecord> GetPeople()
        {
            List<PersonRecord> PersonRecords = new List<PersonRecord>();
            PersonRecords.Add(new PersonRecord()
            {
                FirstName = "Burak",
                LastName = "Enal",
                Address = "asdasdasdasd",
                Age = "25",
                Birthday = DateTime.Now,
                City = "Ankara",
                Gender = "1",
                State = "asdas",
                ZipCode = "06620"

            }); ;

            PersonRecords.Add(new PersonRecord()
            {
                FirstName = "Dürrük",
                LastName = "Körpe",
                Address = "asdasdasdasd",
                Age = "25",
                Birthday = DateTime.Now,
                City = "Ankara",
                Gender = "2",
                State = "asdas",
                ZipCode = "06620"
            });

            return PersonRecords;
        }

    }
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

}
