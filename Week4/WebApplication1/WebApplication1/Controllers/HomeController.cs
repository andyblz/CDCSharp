using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private HomeContext _context;

        public HomeController(HomeContext context)
        {
            _context = context;
        }

        // INFO: Home/index page.
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        // INFO: Register a user.
        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterView regModel)
        {
            Console.WriteLine("registering...");
            TryValidateModel(regModel);
            if (ModelState.IsValid)
            {
                Console.WriteLine("form is valid...");
                // Get any email that matches user's inputted email from database.
                User returnedEmails = _context.Users.SingleOrDefault(user => user.Email == regModel.Email);

                // If match, throw error to login.
                if (returnedEmails != null)
                {
                    ModelState.AddModelError("Email", "This email is already registered. Please log in.");
                }
                else
                {
                    Console.WriteLine("hashing password and adding user to db...");
                    // Hash the user's password.
                    PasswordHasher<RegisterView> hashedPassword = new PasswordHasher<RegisterView>();
                    regModel.Password = hashedPassword.HashPassword(regModel, regModel.Password);

                    // Save user's input in database.
                    User newUser = new User
                    {
                        Name = regModel.Name,
                        Email = regModel.Email,
                        Password = regModel.Password,
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now
                    };

                    _context.Add(newUser);
                    _context.SaveChanges();

                    HttpContext.Session.SetInt32("loggedUserID", Convert.ToInt32(newUser.UserId));

                    return RedirectToAction("Success");
                }
            }
            Console.WriteLine("form is not valid...");
            return View("Index");
        }

        // Display success page.
        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            int? loggedUserId = HttpContext.Session.GetInt32("loggedUserID");
            ViewBag.LoggedUser = _context.Users.SingleOrDefault(user => user.UserId == loggedUserId);
            return View("Success");
        }

        // INFO: Log out a user.
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
