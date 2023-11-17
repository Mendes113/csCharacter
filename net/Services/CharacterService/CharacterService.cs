using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using net.Models;

namespace net.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {


            private static List<Character> characters = new List<Character>{ 
                new Character(),
                new Character{
                    Id = 1,
                    Name = "Sam",
                    Class = RpgClass.Knight,
                },
                  new Character{
                    Id = 2,
                    Name = "Gandalf",
                    Intelligence = 100,
                    Strength = 80,
                    Class = RpgClass.Mage,
                }
            };

            
        public List<Character> AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
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