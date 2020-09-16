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
                Birthday = DateTime.Now.AddYears(-20),
                Gender = "1",
                Country = "1",
                EducationCountry = "1",
                EducationCity = "1",
                EducationLevel = "6"
            }); 

            PersonRecords.Add(new PersonRecord()
            {
                FirstName = "Dürrük",
                LastName = "Körpe",
                Birthday = DateTime.Now.AddYears(30),
                Gender = "2",
                Country = "2",
                EducationCountry = "2",
                EducationCity = "6",
                EducationLevel = "6"
            });

            return PersonRecords;
        }

    }

}
