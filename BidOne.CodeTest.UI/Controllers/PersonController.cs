using Microsoft.AspNetCore.Mvc;
using BidOne.CodeTest.UI.Services;
using BidOne.CodeTest.UI.Models;
using System.Reflection;

namespace BidOne.CodeTest.UI.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonApiService _personApiService;

        public PersonController(IPersonApiService personApiService)
        {
            _personApiService = personApiService;
        }

        public IActionResult Index()
        {
            return View(new PersonModel());
        }

        [HttpPost]
        public async Task<IActionResult> WriteToJson(PersonModel person)
        {
            ResponseModel result = await _personApiService.WriteToJson(person);
            ViewBag.Message = result.Message;
            return View("Index",person);
        }
    }
}
