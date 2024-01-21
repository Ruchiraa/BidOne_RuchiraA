using BidOne.CodeTest.Core.Entities;
using BidOne.CodeTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidOne.CodeTest.Data;
using System.Text.RegularExpressions;

namespace BidOne.CodeTest.Services
{
    public class PersonService : IPersonService
    {
        private readonly JsonWriter _jsonWriter;

        public PersonService(JsonWriter jsonWriter) 
        { 
            _jsonWriter = jsonWriter;
        }
        public bool WriteToJsonFile(Person person)
        {
            try
            {
                Validate(person);
               return _jsonWriter.WriteToFile(person, "Jsons\\Person.json");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private void Validate(Person validPerson)
        {
            if (string.IsNullOrWhiteSpace(validPerson.FirstName))
            {
                throw new ArgumentException("FirstName is required.");
            }

            if (string.IsNullOrWhiteSpace(validPerson.LastName))
            {
                throw new ArgumentException("LastName is required.");
            }

            //Invalid format
            Regex regex = new Regex(@"^[a-zA-Z]+$");
            Match match = regex.Match(validPerson.FirstName);
            if (!match.Success)
            {
                throw new FormatException("Invalid First Name");
            }

            regex = new Regex(@"^[a-zA-Z]+$");
            match = regex.Match(validPerson.LastName);
            if (!match.Success)
            {
                throw new FormatException("Invalid Last Name");
            }
        }
    }
}
