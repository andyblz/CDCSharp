using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TimeDisplay.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult TimeDisplay()
        {
            return View();
        }

        [HttpGet]
        [Route("/index")]
        public IActionResult Index()
        {
            return View();
        }

    }
}
