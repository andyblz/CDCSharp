using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TheDojoLeague.Models;
using TheDojoLeague.Factories;


namespace TheDojoLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly NinjaFactory ninjaFactory;
        private readonly DojoFactory dojoFactory;
        public HomeController()
        {
            ninjaFactory = new NinjaFactory();
            dojoFactory = new DojoFactory();
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Ninjas = ninjaFactory.ShowAllNinjas();
            ViewBag.Dojos = dojoFactory.ShowAllDojos();
            return View();
        }

        [HttpGet]
        [Route("/dojos")]
        public IActionResult Dojos()
        {
            ViewBag.Dojos = dojoFactory.ShowAllDojos();
            return View();
        }

        [HttpPost]
        [Route("/register/ninja")]
        public IActionResult RegisterNinja(NinjaView model)
        {
            if (ModelState.IsValid)
            {
                Ninja ninja = new Ninja
                {
                    name = model.name,
                    level = model.level,
                    dojo_id = model.dojo_id
                };

                ninjaFactory.AddNewNinja(ninja);
                return RedirectToAction("Index");   
            }
            return View(model);
        }

        // [HttpPost]
        // [Route("/register/dojo")]
        // public IActionResult RegisterDojo(Dojo model)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         dojoFactory.RegisterDojo(dojo);
        //         return RedirectToAction("Dojos"); 
        //     }
        //     return View(model);        
        // }
    }
}
