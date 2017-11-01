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
    public class HomeController : Controller
    {
        private HomeContext _context;

        public HomeController(HomeContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("")]
        public IActionResult IndexR()
        {
            return View();
        }

        [HttpGet]
        [Route("indexL")]
        public IActionResult IndexL()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterView regModel)
        {
            TryValidateModel(regModel);
            if (ModelState.IsValid)
            {
                // Get any email that matches user's inputted email from database.
                User returnedEmails = _context.users.SingleOrDefault(user => user.email == regModel.email);

                // If match, throw error to login.
                if (returnedEmails != null)
                {
                    ModelState.AddModelError("email", "This email is already registered. Please log in.");
                }
                else
                {
                    // Hash the user's password.
                    PasswordHasher<RegisterView> hashedPassword = new PasswordHasher<RegisterView>();
                    regModel.password = hashedPassword.HashPassword(regModel, regModel.password);

                    // Save user's input in database.
                    User newUser = new User
                    {
                        first_name = regModel.firstName,
                        last_name = regModel.lastName,
                        email = regModel.email,
                        password = regModel.password,
                        created_at = DateTime.Now,
                        updated_at = DateTime.Now
                    };

                    _context.Add(newUser);
                    _context.SaveChanges();

                    HttpContext.Session.SetInt32("loggedUserID", Convert.ToInt32(newUser.userId));

                    return RedirectToAction("WeddingIndex", "Wedding");
                } 
            }
            return View("IndexR", regModel);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginView logModel)
        {
            TryValidateModel(logModel);
            if (ModelState.IsValid)
            {
                // Get any email that matches user's inputted email from database.
                User returnedUser = _context.users.SingleOrDefault(user => user.email == logModel.loginEmail);

                // If no match, throw error to register.
                if (returnedUser == null)
                {
                    ModelState.AddModelError("loginEmail", "This email doesn't exist. Please register an account.");
                }
                else
                {
                    // Unhash the user's password.
                    var hashedPassword = new PasswordHasher<User>();
                    if (hashedPassword.VerifyHashedPassword(returnedUser, returnedUser.password, logModel.loginPassword) != 0)
                    {
                        HttpContext.Session.SetInt32("loggedUserID", Convert.ToInt32(returnedUser.userId));
                        return RedirectToAction("WeddingIndex", "Wedding");
                    }

                    ModelState.AddModelError("loginPassword", "Password is incorrect.");
                }
            }
            return View("IndexL", logModel);
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("IndexL");
        }
    }
}
