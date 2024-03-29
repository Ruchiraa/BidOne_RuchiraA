﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidOne.CodeTest.Data;
using BidOne.CodeTest.Services;
using BidOne.CodeTest.Services.Interfaces;
using BidOne.CodeTest.Core.Entities;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BidOne.CodeTest.Test
{
    public class ServicesTests
    {
        private IPersonService _personService;
        private BidOne.CodeTest.Data.JsonWriter _mockJsonWriter;

        [SetUp]
        public void Setup()
        {
            _personService = new PersonService(_mockJsonWriter);
        }


        [Test]
        public void WriteNewPerson_ThrowsArgumentException()
        {
            // Arrange
            var invalidPerson = new Person
            {
                FirstName = "",
                LastName = ""
            };

            //Act
            Exception ex = Assert.Throws<Exception>(() => _personService.WriteToJsonFile(invalidPerson));

            //Assert
            Assert.That(ex.Message, Is.EqualTo("FirstName is required."));
        }

        [Test]
        public void WriteNewPerson_ThrowsFormatException()
        {
            //Arrange
            var invalidPerson = new Person
            {
                FirstName = "Nimal123",
                LastName = "Perera"
            };

            //Act
            Exception ex = Assert.Throws<Exception>(() => _personService.WriteToJsonFile(invalidPerson));

            //Assert
            Assert.That(ex.Message, Is.EqualTo("Invalid First Name"));
        }
    }
}
