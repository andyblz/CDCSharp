using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace AjaxNotes.Controllers
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
        [Route("/post")]
        public IActionResult PostNote()
        {
            return RedirectToAction("ShowPosts");
        }

        [HttpGet]
        [Route("")]
        public IActionResult ShowPosts()
        {
            return View("Index");
        }
    }
}
