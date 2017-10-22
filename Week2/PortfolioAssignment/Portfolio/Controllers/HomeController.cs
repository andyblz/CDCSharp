using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/project")]
        public IActionResult Project()
        {
            return View();
        }

        [HttpGet]
        [Route("/contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
