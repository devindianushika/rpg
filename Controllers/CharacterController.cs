using System.Linq;
using System.Collections.Generic;
using dotnet_rpg.Models;
using Microsoft.AspNetCore.Mvc;
using dotnet_rpg.Services.CharacterService;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Character;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace dotnet_rpg.Controllers

{   [Authorize]
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
        public async Task<IActionResult> Get()
        
        {
            int userid = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            return Ok(await _charcterService.GetAllCharacters(userid));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleCharacter(int id)
        {
            return Ok(await _charcterService.GetCharacterById(id));
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddCharacter(AddCharacterDto usercharacter)
        {

            return Ok(await _charcterService.AddCharacter(usercharacter));
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto userupdatecharcter)
        {
            ServiceResponse<GetCharacterDto> response = await _charcterService.UpdateCharacter(userupdatecharcter);
            if (response.Data == null)
            {
                return NotFound(response);

            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            ServiceResponse<List<GetCharacterDto>> response = await _charcterService.DeleteCharacter(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

    }
}