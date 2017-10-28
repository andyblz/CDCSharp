using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using TheWall.Models;

namespace TheWall.Controllers
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
        [Route("/register")]
        public IActionResult Register(Register model)
        {
            // Compare user's inputted email with database, and pull up any user whose email matches any emails in the database.
            List<Dictionary<string, object>> userList = DbConnector.Query($"SELECT id, password FROM users WHERE email = '{model.email}'");

            // If there is an email match, send a validation error.
            if (userList.Count > 0)
            {
                ModelState.AddModelError("email", "This email is already registered. Please log in.");
            }

            // If validations pass, save the user information to the database, and save that user's ID to a session.
            if (ModelState.IsValid)
            {
                string query = $@"INSERT INTO users (first_name, last_name, email, password) VALUES ('{model.firstName}', '{model.lastName}', '{model.email}', '{model.password}');
                SELECT LAST_INSERT_ID() as id";

                HttpContext.Session.SetInt32("loggedUserID", Convert.ToInt32(DbConnector.Query(query)[0]["id"]));
                return RedirectToAction("TheWall", "Wall");
            }

            return View("Index");
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult Login(Login model)
        {
            // Compare user's inputted email with database, and pull up any user whose email matches any emails in the database.
            string query = $"SELECT id, password FROM users WHERE email = '{model.loginEmail}'";
            List<Dictionary<string, object>> userList = DbConnector.Query(query);

            // If no matches or if password doesn't match, send a validation error.
            if ((userList.Count == 0) || ((string)userList[0]["password"] != model.loginPassword))
            {
                ModelState.AddModelError("loginEmail", "Invalid email or password.");
            }

            // If validations pass, save that user's ID to a session.
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetInt32("loggedUserID", Convert.ToInt32(DbConnector.Query(query)[0]["id"]));
                return RedirectToAction("TheWall", "Wall");
            }

            return View("Index");
        }

        [HttpGet]
        [Route("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
