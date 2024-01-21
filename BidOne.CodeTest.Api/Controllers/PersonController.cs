using Microsoft.AspNetCore.Mvc;
using BidOne.CodeTest.Api.Models;
using BidOne.CodeTest.Services.Interfaces;

namespace BidOne.CodeTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly PersonConvertion _personConvertion=new PersonConvertion();
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost("/api/persons")]
        public IActionResult CreatePerson([FromBody] PersonRequest request)
        {
            try
            {
                bool response = false;
                BidOne.CodeTest.Core.Entities.Person person = _personConvertion.ConvertToPersonRequest(request);
                response = _personService.WriteToJsonFile(person);
                if (response)
                {
                    return Ok("Successfully inserted");
                }
                else
                {
                    return BadRequest("Person is not created");
                }
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
            
        }
    }
}
