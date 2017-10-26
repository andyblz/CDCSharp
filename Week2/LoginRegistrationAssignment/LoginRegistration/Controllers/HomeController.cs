using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using LoginRegistration.Models;


namespace LoginRegistration.Controllers
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
            List<Dictionary<string, object>> users = DbConnector.Query($"SELECT id, password FROM users WHERE email = '{model.email}'");

            if (users.Count > 0)
            {
                ModelState.AddModelError("email", "Email is already registered.");                
            }

            if (ModelState.IsValid)
            {
                string query = $@"INSERT INTO users (firstName, lastName, email, password, created_at, updated_at) VALUES ('{model.firstName}', '{model.lastName}', '{model.email}', '{model.password}', NOW(), NOW());
                SELECT LAST_INSERT_ID() as id"; 

                HttpContext.Session.SetInt32("id", Convert.ToInt32(DbConnector.Query(query)[0]["id"]));
                return RedirectToAction("Success");

            }
            return View("Index");
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult Login(Login model)
        {
            string query = $"SELECT id, password FROM users WHERE email = '{model.login_email}'";
            List<Dictionary<string, object>> users = DbConnector.Query(query);  

            if((users.Count == 0 || model.login_password == null) || ((string)users[0]["password"] != model.login_password))
            {
                ModelState.AddModelError("login_email", "Invalid email/password.");
            }

            if (ModelState.IsValid)
            {   
                HttpContext.Session.SetInt32("id", Convert.ToInt32(DbConnector.Query(query)[0]["id"]));                
                return RedirectToAction("Success");
            }

            return View("Index");
        }

        [HttpGet]
        [Route("/success")]
        public IActionResult Success()
        {
            int? loggedUserID = HttpContext.Session.GetInt32("id");
            string query = $"SELECT firstName FROM users WHERE id = '{(int)loggedUserID}'";
            var user = DbConnector.Query(query);

            ViewBag.User = user[0];

            return View();
        }
    }
}
