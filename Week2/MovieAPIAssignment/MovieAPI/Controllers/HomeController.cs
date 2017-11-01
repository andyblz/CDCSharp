using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MovieAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;
        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            string query = $@"SELECT title, release_date, rating, overview FROM movies";

            List<Dictionary<string, object>> allMovies = _dbConnector.Query(query);

            ViewBag.Movies = allMovies;
            
            return View();
        }

        [HttpPost]
        [Route("/searchmovie")]
        public IActionResult SearchMovie(string movieName)
        {
            Dictionary<string, dynamic> movieInfo = new Dictionary<string, dynamic>();
            WebRequest.GetMovieDataAsync(movieName, ApiResponse => {
                movieInfo = ApiResponse;
            }).Wait();

            string title = movieInfo["title"];
            string releaseDate = movieInfo["release"];
            string overview = movieInfo["overview"];
            float rating = movieInfo["vote_average"];

            string query = $@"INSERT INTO movies (title, release_date, overview, rating) VALUES ('{title}', '{releaseDate}', '{overview}', '{rating}')";

            _dbConnector.Execute(query);


            ViewBag.MovieTitle = title;
            Console.WriteLine(ViewBag.MovieTitle);

            return RedirectToAction("Index");
        }
    }

}
