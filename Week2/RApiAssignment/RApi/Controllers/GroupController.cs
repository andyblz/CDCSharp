using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace MusicApi.Controllers {
    public class GroupController : Controller {
        // Add an extra boolean parameter to the group routes that will include members for all Group JSON responses.
        List<Group> allGroups {get; set;}
        List<Artist> allArtists {get; set;}

        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        // Route that returns all groups as JSON.
        [Route("/groups")]
        [HttpGet]
        public JsonResult Groups()
        {
            return Json(allGroups);
        }

        // Route that returns all groups that match the provided name.
        [Route("/groups/name/{name}")]
        [HttpGet]
        public JsonResult GroupName(string name, bool listArtists)
        {
            List<Group> result = allGroups.Where(group => group.GroupName == name).ToList();
            listArtists = true;
            if (listArtists == true)
            {
                result = result.GroupJoin(allArtists,
                                            group => group.Id,
                                            artist => artist.GroupId,
                                            (group, artists) => {group.Members = artists.ToList(); return group;}).ToList();
            }
            return Json(result);
        }

        // Route that returns all groups with the provided Id value.
        [Route("/groups/id/{id}")]
        [HttpGet]
        public JsonResult GroupID(int id)
        {
            List<Group> result = allGroups.Where(group => group.Id == id).ToList();
            result = result.GroupJoin(allArtists,
                                            group => group.Id,
                                            artist => artist.GroupId,
                                            (group, artists) => {group.Members = artists.ToList(); return group;}).ToList();
            return Json(result);
        }
    }
}