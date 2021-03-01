using System.Linq;
using System.Collections.Generic;
using dotnet_rpg.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private static List<Character> characters = new List<Character>(){
    new Character(),
    new Character {Id= 1, Name = "Sam",Intelligence=20,Strength=258
    }
        };
        [HttpGet]
        [Route("Getall")]
        public IActionResult Get()
        {
            return Ok(characters);
        }
        [HttpGet("{id}")]
        public IActionResult GetSingleCharacter(int id)
        {
            return Ok(characters.FirstOrDefault(c => c.Id == id));
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddCharacter(Character usercharacter)
        {
          characters.Add(usercharacter);
            return Ok(characters);
        }
    }
}