using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using TheWall.Models;

namespace TheWall.Controllers
{
    public class WallController : Controller
    {
        [HttpGet]
        [Route("/thewall")]
        public IActionResult TheWall()
        {
            if(HttpContext.Session.GetInt32("loggedUserID") == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Messages = GetMessages();
            ViewBag.Comments = GetComments();
            ViewBag.DateTimeNow = DateTime.Now;
            Console.WriteLine(ViewBag.DateTimeNow);
            ViewBag.LoggedUser = DbConnector.Query($"SELECT id, first_name FROM users WHERE users.id = {(int)HttpContext.Session.GetInt32("loggedUserID")}")[0];

            return View();
        }

        [HttpPost]
        [Route("/postmessage")]
        public IActionResult PostMessage(MessagePost model)
        {   
            if (ModelState.IsValid)
            {
                string query = $@"INSERT INTO messages (message, users_id) VALUES (
                    '{model.messagePost}', {(int)HttpContext.Session.GetInt32("loggedUserID")})";
                DbConnector.Execute(query);
                return RedirectToAction("TheWall");
            }
            return RedirectToAction("TheWall");
        }

        [HttpPost]
        [Route("/postcomment")]
        public IActionResult PostComment(CommentPost model)
        {
            if (ModelState.IsValid)
            {
                string query = $@"INSERT INTO comments (comment, users_id, messages_id) VALUES (
                    '{model.commentPost}', {(int)HttpContext.Session.GetInt32("loggedUserID")}, '{model.messageID}')";
                DbConnector.Execute(query);
                return RedirectToAction("TheWall");
            }
            return RedirectToAction("TheWall");
        }

        [HttpPost]
        [Route("/deletemessage")]
        public IActionResult DeleteMessage(string delete_message)
        {
            string query = $@"DELETE FROM messages WHERE id = '{delete_message}'";
            string query2 = $@"DELETE FROM comments WHERE messages_id = '{delete_message}'";
            DbConnector.Execute(query2);
            DbConnector.Execute(query);
            return RedirectToAction("TheWall");
        }

        [HttpPost]
        [Route("/deletecomment")]
        public IActionResult DeleteComment(string delete_comment)
        {
            Console.WriteLine(delete_comment);
            string query = $@"DELETE FROM comments WHERE id = '{delete_comment}'";
            DbConnector.Execute(query);
            return RedirectToAction("TheWall");
        }

        // Function to get all the messages.
        public List<Dictionary<string, object>> GetMessages()
        {
            string query = $@"SELECT messages.id AS message_id, messages.message, messages.created_at, messages.updated_at, users.first_name, users.last_name, users.id FROM messages JOIN users ON messages.users_id = users.id ORDER BY messages.created_at DESC";
            return DbConnector.Query(query);
        }

        // Function to get all the comments.
        public List<Dictionary<string, object>> GetComments()
        {
            string query = $@"SELECT comments.id AS comment_id, comments.comment, comments.created_at, comments.updated_at, users.first_name, users.last_name, users.id, comments.messages_id FROM comments JOIN users ON comments.users_id = users.id ORDER BY comments.created_at DESC";
            return DbConnector.Query(query);
        }
    }
}
