using Bogus;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Data.Controllers
{
    [ApiController]
    [Route("names")]
    public class NamesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get() => 
            new Faker<Person>()
                .RuleFor(o => o.First, f => f.Name.FirstName())
                .RuleFor(o => o.Last, f => f.Name.FirstName())
                .Generate(50)
                .Select(p => $"{p.First} {p.Last}");
    }

    internal class Person
    {
        public string First { get; set; }

        public string Last { get; set; }
    }
}