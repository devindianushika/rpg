
using AutoMapper;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharcterService
    
    {
        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        private static List<Character> characters = new List<Character> {
    new Character(),
    new Character { Id = 1, Name = "Sam"}
};

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newcharacter)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            //map newcharacter source object to Character destination object
            Character character = _mapper.Map<Character>(newcharacter);
            character.Id = characters.Max(c => c.Id) +1 ;
            characters.Add(character);
            serviceResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse;

        }


        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data =(characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            serviceResponse.Data =_mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));

            return serviceResponse;
        }

   public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto newcharacter)
        {
           
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
             try{
            Character character = characters.FirstOrDefault(c => c.Id == newcharacter.Id);
            character.Name = newcharacter.Name ;
            character.HitPoints = newcharacter.HitPoints;
            character.Strength = newcharacter.Strength;
            character.Intelligence = newcharacter.Intelligence;
            character.Defense = newcharacter.Defense;
            character.Class = newcharacter.Class;
           
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }

            catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }
            
            return serviceResponse;
        }

        public async Task <ServiceResponse<List<GetCharacterDto>>>DeleteCharacter(int id){
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try{
                Character character = characters.FirstOrDefault(c => c.Id == id);
                characters.Remove(character);
                serviceResponse.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            }

            catch(Exception ex){
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

       
    }




}