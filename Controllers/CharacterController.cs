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
    new Character { Name = "Sam",Intelligence=20,Strength=258
    }
        };
        [HttpGet]
        [Route("Getall")]
        public IActionResult Get()
        {
            return Ok(characters);
        }
        [HttpGet]
        public IActionResult GetSingleCharacter()
        {
            return Ok(characters[0]);
        }

    }
}