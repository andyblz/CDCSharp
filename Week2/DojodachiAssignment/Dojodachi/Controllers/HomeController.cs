using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // Sets the default stats and welcome message.
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            if (Happiness == null)
            {
                HttpContext.Session.SetInt32("Happiness", 20);
            }

            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            if (Fullness == null)
            {
                HttpContext.Session.SetInt32("Fullness", 20);
            }

            int? Energy = HttpContext.Session.GetInt32("Energy");
            if (Energy == null)
            {
                HttpContext.Session.SetInt32("Energy", 50);
            }

            int? Meals = HttpContext.Session.GetInt32("Meals");
            if (Meals == null)
            {
                HttpContext.Session.SetInt32("Meals", 3);
            }

            string Message = HttpContext.Session.GetString("Message");
            if (Message == null)
            {
                HttpContext.Session.SetString("Message", "Welcome to Dojodachi!");
            }

            string Session = HttpContext.Session.GetString("Session");
            if (Session == null)
            {
                HttpContext.Session.SetString("Session", "InSession");
                
            }

            // Sets what buttons shows up, depending on game status.
            if (Energy >= 100 && Fullness >= 100 && Happiness >= 100)
            {
                HttpContext.Session.SetString("Message", "CONGRATS! YOU WIN!");
                HttpContext.Session.SetString("Session", "NotInSession");
                HttpContext.Session.SetString("Mood", "Happy");                  
            }
            else if (Fullness == 0 || Happiness == 0)
            {
                HttpContext.Session.SetString("Message", "UHHH.. YOU KILLED IT. YOU LOSE! (T____T)");
                HttpContext.Session.SetString("Mood", "Dead");  
                HttpContext.Session.SetString("Session", "NotInSession");
            }

            // Renders the message and stats.
            ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
            ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
            ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
            ViewBag.Meals = HttpContext.Session.GetInt32("Meals");        
            ViewBag.Message = HttpContext.Session.GetString("Message");
            ViewBag.Session = HttpContext.Session.GetString("Session");

            // Renders the photo depending on Dojodachi's mood.
            string Mood = HttpContext.Session.GetString("Mood");
            if (Mood == "Sad")
            {
                ViewBag.Photo = "https://vignette.wikia.nocookie.net/tamagotchi/images/7/78/Mame_sad.png/revision/latest/scale-to-width-down/169?cb=20150917181119";
            }
            else if (Mood == "Sleep")
            {
                ViewBag.Photo = "http://www.tamatalk.com/IB/uploads/profile/photo-212980.png?_r=1485112499";
            }
            else if (Mood == "Upset")
            {
                ViewBag.Photo = "http://www.tamatalk.com/IB/uploads/profile/photo-195465.jpg?_r=1389560613";
            }
            else if (Mood == "Dead")
            {
                ViewBag.Photo = "https://vignette.wikia.nocookie.net/tamagotchi/images/5/51/GhostJr_tah.png/revision/latest?cb=20140601061454";
            }
            else
            {
                ViewBag.Photo = "https://vignette.wikia.nocookie.net/tamagotchi/images/3/37/03_Mametchi.svg/revision/latest/scale-to-width-down/241?cb=20111125003832";
            }

            return View();
        }

        [HttpPost]
        [Route("/Action")]
        public IActionResult Action(string playAction)
        {
            // Gets the stats, etc so they can be used and reset.
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            int? Energy = HttpContext.Session.GetInt32("Energy");
            int? Meals = HttpContext.Session.GetInt32("Meals");
            string Message = HttpContext.Session.GetString("Message");
            string Mood = HttpContext.Session.GetString("Mood");

            Random rand = new Random();

            // If user clicks "FEED" button.
            if (playAction == "feed")
            {
                if (Meals == 0)
                {
                    HttpContext.Session.SetString("Message", "No meals left to eat (T____T)");
                    HttpContext.Session.SetString("Mood", "Sad");  
                }
                else
                {
                    int chance = rand.Next(0,4);
                    if (chance != 0)
                    {
                        HttpContext.Session.SetString("Message", "You ate a meal!");
                        HttpContext.Session.SetString("Mood", "Happy");  

                        Fullness += rand.Next(5,11);
                        HttpContext.Session.SetInt32("Fullness", (int)Fullness);
                    }
                    else
                    {
                        HttpContext.Session.SetString("Message", "Did not like!");
                        HttpContext.Session.SetString("Mood", "Upset");  
                    }

                    Meals --;  
                    HttpContext.Session.SetInt32("Meals", (int)Meals);
                }
            }

            // If user clicks "PLAY" button.            
            if (playAction == "play")
            {
                if (Energy == 0)
                {
                    HttpContext.Session.SetString("Message", "You have no energy left to play (T____T)"); 
                    HttpContext.Session.SetString("Mood", "Sad"); 
                }
                else
                {
                    int chance = rand.Next(0,4);
                    if (chance != 0)
                    {
                        HttpContext.Session.SetString("Message", "You played!");
                        HttpContext.Session.SetString("Mood", "Happy");  

                        Happiness += rand.Next(5,11);
                        HttpContext.Session.SetInt32("Happiness", (int)Happiness);
                    }
                    else
                    {
                        HttpContext.Session.SetString("Message", "Do not want!");
                        HttpContext.Session.SetString("Mood", "Upset");
                    }
                    Energy -= 5;  
                    HttpContext.Session.SetInt32("Energy", (int)Energy);
                }
            }

            // If user clicks "WORK" button.            
            if (playAction == "work")
            {
                if (Energy == 0)
                {
                    HttpContext.Session.SetString("Message", "You have no energy left to work (T____T)"); 
                    HttpContext.Session.SetString("Mood", "Sad"); 
                }
                else
                {
                    Energy -= 5;  
                    HttpContext.Session.SetInt32("Energy", (int)Energy);
                    HttpContext.Session.SetString("Message", "You worked!"); 
                    HttpContext.Session.SetString("Mood", "Happy"); 

                    Meals += rand.Next(1,4);
                    HttpContext.Session.SetInt32("Meals", (int)Meals);
                }
            }

            // If user clicks "SLEEP" button.            
            if (playAction == "sleep")
            {
                if (Fullness == 0 || Happiness == 0)
                {
                    HttpContext.Session.SetString("Message", "You don't have enough Fullness or Happiness to sleep (T____T)"); 
                    HttpContext.Session.SetString("Mood", "Sad"); 
                }
                else
                {
                    Energy += 15;  
                    Fullness -= 5;
                    Happiness -= 5;
                    HttpContext.Session.SetInt32("Energy", (int)Energy);
                    HttpContext.Session.SetInt32("Fullness", (int)Fullness);
                    HttpContext.Session.SetInt32("Happiness", (int)Happiness);
                    HttpContext.Session.SetString("Message", "You slept!"); 
                    HttpContext.Session.SetString("Mood", "Sleep"); 
                }
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("/Reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }


}
