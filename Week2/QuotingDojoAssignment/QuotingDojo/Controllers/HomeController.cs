using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace QuotingDojo.Controllers
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
        [Route("post")]
        public IActionResult PostQuote(string name, string quote)
        {

            DbConnector.Query(String.Format("INSERT INTO users (name, quote, created_at, updated_at) VALUES ('{0}', '{1}', NOW(), NOW())", name, quote));
            return RedirectToAction("Quotes");
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes()
        {
            var results = DbConnector.Query("SELECT name, quote, created_at FROM users ORDER BY created_at DESC");
            ViewBag.Quotes = results;
            return View();
        }
    }
}
