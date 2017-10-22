using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// Added this from the CD Platform > C#/.NET Core > ASP.NET Core I > ASP.NET Core > Controllers.
using Microsoft.AspNetCore.Http;


namespace CallingCardAssignment.Controllers
{
    public class HomeController : Controller
    {
        // For the Calling Card assignment.
        [HttpGet]
        [Route("/{firstName}/{lastName}/{age}/{favColor}")]
        public JsonResult CallCard(string firstName, string lastName, int age, string favColor)
        {
            var contact = new {
                firstName = firstName,
                lastName = lastName,
                age = age,
                favColor = favColor,
            };

            return Json(contact);
        }

        // Added this from the CD Platform > C#/.NET Core > ASP.NET Core I > ASP.NET Core > Controllers.
        [HttpGet]
        [Route("index")]
        // OR a route that accepts parameters:
        // [Route("template/{Name}")]
        public string Index()
        {
            return "HELLO HELLO WORLD!";
        }

        // public IActionResult Index()
        // {
        //     return View();
        // }

        // Added this from the CD Platform > C#/.NET Core > ASP.NET Core I > ASP.NET Core > Controllers.
        [HttpPost]
        [Route("")]
        public IActionResult Other()
        {
            return null;
        }

        // Added this from the CD Platform > C#/.NET Core > ASP.NET Core I > ASP.NET Core > Returning JSON.
        [HttpGet]
        [Route("displayint")]
        public JsonResult DisplayInt()
        {
            var AnonObject = new {
                FirstName = "Jennifer",
                LastName = "Feng",
                Age = 27
            };

            return Json(AnonObject);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
