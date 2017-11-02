using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WeddingPlanner.Models;


namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        private HomeContext _context;

        public WeddingController(HomeContext context)
        {
            _context = context;
        }

        // Get today's date.
        private string ReturnCurrentDate()
        {
            String dateNow = DateTime.Now.ToString("yyyy-MM-dd");
            return dateNow;
        }

        // Get logged user.
        private User ReturnLoggedUser()
        {
            int? loggedUserId = HttpContext.Session.GetInt32("loggedUserID");
            User loggedUser = _context.users.SingleOrDefault(user => user.userId == loggedUserId);
            return loggedUser;
        }


        [HttpGet]
        [Route("wedding")]
        public IActionResult WeddingIndex()
        {
            if (ReturnLoggedUser() == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.LoggedUser = ReturnLoggedUser();
            
            Dashboard dashData = new Dashboard
            {
                Weddings = _context.weddings.Include(w => w.Guests).ToList(),
                User = ReturnLoggedUser()
            };

            return View(dashData);
        }

        [HttpGet]
        [Route("wedding/form")]
        public IActionResult WeddingForm()
        {
            if (ReturnLoggedUser() == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.LoggedUser = ReturnLoggedUser();
            ViewBag.DateTimeNow = ReturnCurrentDate();
            
            return View();
        }

        [HttpGet]
        [Route("wedding/info/{weddingId}")]
        public IActionResult WeddingInfo(int weddingId)
        {
            if (ReturnLoggedUser() == null)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.LoggedUser = ReturnLoggedUser();

            Wedding returnedWeddings = _context.weddings.SingleOrDefault(w => w.weddingId == weddingId);

            List<WeddingUser> returnedGuest = _context.rsvps.Where(w => w.weddingId == weddingId)
                                                        .Include(g => g.Guest)
                                                        .ToList();

            ViewBag.WeddingInfo = returnedWeddings;

            return View();
        }

        [HttpPost]
        [Route("wedding/form/add")]
        public IActionResult AddWedding(WeddingView weddingModel, int plannerId)
        {
            TryValidateModel(weddingModel);
            if (ModelState.IsValid)
            {
                Wedding returnedWedding = _context.weddings.SingleOrDefault(wedding => wedding.userId == plannerId);

                if (returnedWedding != null)
                {
                    ModelState.AddModelError("wedderOne", "You already have a wedding registered.");
                }
                else
                {
                    Wedding newWedding = new Wedding
                    {
                        wedder_one = weddingModel.wedderOne,
                        wedder_two = weddingModel.wedderTwo,
                        wedding_date = (DateTime)weddingModel.weddingDate,
                        address = weddingModel.address,
                        created_at = DateTime.Now,
                        updated_at = DateTime.Now,
                        userId = plannerId
                    };

                    _context.Add(newWedding);
                    _context.SaveChanges();

                    Wedding weddingInfo = _context.weddings.SingleOrDefault(wedding => wedding.weddingId == newWedding.weddingId);

                    return RedirectToAction("WeddingInfo", new { weddingId = weddingInfo.weddingId });
                }
            }

            ViewBag.LoggedUser = ReturnLoggedUser();            
            ViewBag.DateTimeNow = ReturnCurrentDate();

            return View("WeddingForm", weddingModel);
        }

        [HttpGet]
        [Route("wedding/rsvp/{weddingId}")]
        public IActionResult RSVP(int weddingId)
        {
            User LoggedUser = ReturnLoggedUser();

            WeddingUser newRSVP = new WeddingUser
            {
                weddingId = weddingId,
                userId = LoggedUser.userId
            };

            _context.Add(newRSVP);
            _context.SaveChanges();

            ViewBag.LoggedUser = ReturnLoggedUser();

            return RedirectToAction("WeddingIndex");
        }

        [HttpGet]
        [Route("wedding/cancel/{weddingId}")]
        public IActionResult CancelRSVP(int weddingId)
        {
            User LoggedUser = ReturnLoggedUser();

            WeddingUser cancelRSVP = _context.rsvps.Where(r => r.weddingId == weddingId).Where(r => r.userId == LoggedUser.userId).SingleOrDefault();

            _context.Remove(cancelRSVP);
            _context.SaveChanges();

            ViewBag.LoggedUser = ReturnLoggedUser();

            return RedirectToAction("WeddingIndex");
        }

        [HttpGet]
        [Route("wedding/delete/{weddingId}")]
        public IActionResult DeleteWedding(int weddingId)
        {
            User LoggedUser = ReturnLoggedUser();

            Wedding deleteGuests = _context.weddings.SingleOrDefault(w => w.weddingId == weddingId);

            _context.Remove(deleteGuests);
            _context.SaveChanges();

            ViewBag.LoggedUser = ReturnLoggedUser();

            return RedirectToAction("WeddingIndex");
        }
    }
}
