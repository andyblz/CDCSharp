using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Errors = new List<string>();
            return View();
        }

        [HttpPost]
        [Route("/result")]
        public IActionResult Result(string name, string dojo_location, string fav_lang, string comment)
        {
            ViewBag.Errors = new List<string>();

            if (name == null)
            {
                ViewBag.Errors.Add("Name is required.");
            }

            if (dojo_location == null)
            {
                ViewBag.Errors.Add("Please select a location.");
            }

            if (fav_lang == null)
            {
                ViewBag.Errors.Add("Please select a language.");
            }

            if (comment == null)
            {
                comment = "";
            }

            if (ViewBag.Errors.Count > 0)
            {
                return View("Index");
            }
            
            ViewBag.Name = name;
            ViewBag.Dojo = dojo_location;
            ViewBag.Lang = fav_lang;
            ViewBag.Comment = comment;
            return View();
        }
    }
}
