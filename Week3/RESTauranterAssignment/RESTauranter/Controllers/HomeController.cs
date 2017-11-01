using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RESTauranter.Models;
using System.Linq;


namespace RESTauranter.Controllers
{
    public class HomeController : Controller
    { 
        // INFO: For EF Core
        private ReviewContext _context;

        public HomeController(ReviewContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.DateTimeNow = DateTime.Now;
            return View();
        }

        [HttpPost]
        [Route("add/review")]
        public IActionResult AddReview(ReviewView model)
        {
            TryValidateModel(model);
            if (ModelState.IsValid)
            {
                Review newReview = new Review
                {
                    reviewer = model.reviewer,
                    restaurantName = model.restaurantName,
                    review = model.review,
                    rating = model.rating,
                    created_at = DateTime.Now
                };

                _context.Add(newReview);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            }
            return View("Index", model);
        }

        [HttpGet]
        [Route("all/reviews")]
        public IActionResult Reviews()
        {
            List<Review> allReviews = _context.reviews.OrderByDescending(review => review.created_at).ToList();

            ViewBag.Reviews = allReviews;
            return View();
        }
    }
}
