using System.Linq;
using System.Collections.Generic;
using dotnet_rpg.Models;
using Microsoft.AspNetCore.Mvc;
using dotnet_rpg.Services.CharacterService;

namespace dotnet_rpg.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharcterService _charcterService;
        public CharacterController(ICharcterService characterService)
        {
            _charcterService = characterService;
        }



        [HttpGet]
        [Route("Getall")]
        public IActionResult Get()
        {

            return Ok(_charcterService.GetAllCharacters());
        }


        [HttpGet("{id}")]
        public IActionResult GetSingleCharacter(int id)
        {
            return Ok(_charcterService.GetCharacterById(id));
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddCharacter(Character usercharacter)
        {

            return Ok(_charcterService.AddCharacter(usercharacter));
        }
    }
}