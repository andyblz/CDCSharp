using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/ajax")]
        public JsonResult Ajax()
        {
            int? Count = HttpContext.Session.GetInt32("Count");
            if (Count == null)
            {
                Count = 0;
            }
            Count += 1;

            string possibleChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string passcode = "";
            Random rand = new Random();

            for (int i = 0; i < 14; i++)
            {
                passcode = passcode + possibleChar[rand.Next(0, possibleChar.Length)];
            }

            HttpContext.Session.SetInt32("Count", (int)Count);

            var result = new {passcode = passcode, Count = Count};

            return Json(result);
        }
    }
}
