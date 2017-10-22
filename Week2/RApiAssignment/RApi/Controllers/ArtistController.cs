using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {

    
    public class ArtistController : Controller {

        private List<Artist> allArtists;

        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("")]
        [HttpGet]
        public string Index() {
            //String describing the API functionality
            string instructions = "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }

        // Route that returns all artists in JSON.
        [Route("/artists")]
        [HttpGet]
        public JsonResult Artists()
        {
            return Json(allArtists);
        }

        // Route that returns all artists that match the provided name.
        [Route("/artists/name/{name}")]
        [HttpGet]
        public JsonResult ArtistName(string name)
        {
            List<Artist> result = allArtists.Where(artist => artist.ArtistName.Contains(name)).ToList();
            return Json(result);
        }

        // Route that returns all artists whose real names match the provided name.
        [Route("artists/realname/{name}")]
        [HttpGet]
        public JsonResult ArtistRealName(string name)
        {
            List<Artist> result = allArtists.Where(artist => artist.RealName.Contains(name)).ToList();
            return Json(result);
        }

        // Route that returns all artists from the provided town.
        [Route("artists/hometown/{town}")]
        [HttpGet]
        public JsonResult ArtistHometown(string town)
        {
            List<Artist> result = allArtists.Where(artist => artist.Hometown == town).ToList();
            return Json(result);
        }

        // Route that returns all artists who have a GroupId that matches the provided id.
        [Route("artists/groupid/{id}")]
        [HttpGet]
        public JsonResult ArtistGroupID(int id)
        {
            List<Artist> result = allArtists.Where(artist => artist.GroupId == id).ToList();
            return Json(result);
        }
    }
}