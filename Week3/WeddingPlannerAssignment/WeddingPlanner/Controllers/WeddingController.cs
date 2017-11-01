using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;


namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        private HomeContext _context;

        public WeddingController(HomeContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("wedding")]
        public IActionResult WeddingIndex()
        {
            Console.WriteLine("LOGGED IN!");
            Console.WriteLine(HttpContext.Session.GetInt32("loggedUserID"));

            int? loggedUser = HttpContext.Session.GetInt32("loggedUserID");

            if (loggedUser == null)
            {
                return RedirectToAction("IndexL", "Home");
            }
            
            ViewBag.LoggedUserName = _context.users.SingleOrDefault(user => user.userId == loggedUser);

            return View();
        }

        [HttpGet]
        [Route("wedding/form")]
        public IActionResult WeddingForm()
        {
            int? loggedUser = HttpContext.Session.GetInt32("loggedUserID");

            if (loggedUser == null)
            {
                return RedirectToAction("IndexL", "Home");
            }
            
            return View();
        }

        [HttpPost]
        [Route("wedding/form/add")]
        public IActionResult AddWedding()
        {
            return View();
        }
    }
}
