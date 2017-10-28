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
        public JsonResult PostNote(string title, string desc)
        {
            string query = $@"INSERT INTO notes (title, note) VALUES ('{title}', '{desc}')";
            string query2 = $@"SELECT * FROM notes ORDER BY id DESC LIMIT 1";
            DbConnector.Execute(query);
            List<Dictionary<string, object>> NewNote = DbConnector.Query(query2);
            return Json(NewNote);
        }

        [HttpGet]
        [Route("/showposts")]
        public JsonResult ShowPosts()
        {
            string query = $@"SELECT * FROM notes";
            List<Dictionary<string, object>> AllNotes = DbConnector.Query(query);
            return Json(AllNotes);
        }
    }
}
