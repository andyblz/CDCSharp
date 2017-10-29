using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LostInTheWoods.Models;
using LostInTheWoods.Factories;

namespace LostInTheWoods.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrailFactory trailFactory;
 
        public HomeController(TrailFactory connect)
        {
            trailFactory = connect;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.AllTrails = trailFactory.GetAllTrails();
            return View();
        }

        [HttpGet]
        [Route("/add")]
        public IActionResult AddTrail()
        {
            return View();
        }

        [HttpPost]
        [Route("/add/trail")]
        public IActionResult Add(Trail trail)
        {
            trailFactory.AddNewTrail(trail);
            return RedirectToAction("Index");
        }

    }
}
