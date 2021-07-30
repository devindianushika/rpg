
using dotnet_rpg.Models;
using System.Collections.Generic;
using System.Linq;
namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharcterService
    {
        private static List<Character> characters = new List<Character> {
    new Character(),
    new Character { Id = 1, Name = "Sam"}
};

        public List<Character> AddCharacter(Character newcharacter)
        {
            characters.Add(newcharacter);
            return characters;

        }


        public List<Character> GetAllCharacters()
        {
            return characters;
        }

        public Character GetCharacterById(int id)
        {
            return characters.FirstOrDefault(c => c.Id == id);
        }


    }




}