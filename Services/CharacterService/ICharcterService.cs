using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Models;
namespace dotnet_rpg.Services.CharacterService
{
    public interface ICharcterService
    {
         
    
     Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
      Task <ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
      Task <ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);

      Task <ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto newCharacter);

     
      Task <ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);

    }
}