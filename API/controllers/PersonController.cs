using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.controllers
{
    public class PersonController :  BaseApiController
    {
        private static readonly string[] person = new[] { 
            "Chirag", "Arvindbhai", "Amit",
        };
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Person
            {
                Name = person[rng.Next(person.Length)],
                Age = rng.Next(30, 60),
                Gender = "Male"
            })
            .ToArray();
        }
       
    }
}