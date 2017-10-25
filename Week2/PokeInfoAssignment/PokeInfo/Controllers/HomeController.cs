using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace PokeInfo.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {   
            return View();
        }

        [HttpGet]
        [Route("pokemon")]
        public IActionResult QueryPoke(int pokeid)
        {
            var PokeInfo = new Dictionary<string, object>();
            WebRequest.GetPokemonDataAsync(pokeid, ApiResponse =>
                {
                    PokeInfo = ApiResponse;
                }
            ).Wait();

            Pokemon newPokemon = new Pokemon();

            newPokemon.Name = PokeInfo["name"];
            newPokemon.ID = pokeid;
            newPokemon.Height = PokeInfo["height"];
            newPokemon.Weight = PokeInfo["weight"];

            dynamic pokeSprite = PokeInfo["sprites"];
            newPokemon.Photo = pokeSprite["front_default"];

            dynamic pokeType = PokeInfo["types"];
            newPokemon.PrimaryType = pokeType[0]["type"]["name"];

            ViewBag.PokemonInfo = newPokemon;

            return View();
        }
    }
}
