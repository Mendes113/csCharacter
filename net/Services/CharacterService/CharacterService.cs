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

            
        public async Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter)
        {   
            var serviceResponse = new ServiceResponse<List<Character>>();
            characters.Add(newCharacter);
            serviceResponse.Data = characters;
            return serviceResponse;
        }

        public List<Character> GetAllCharacters()
        {
            return characters;
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {   

            var serviceResponse = new ServiceResponse<Character>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = character;
            return serviceResponse;

            
        }


        public List<Character> UpdateCharacter(Character updatedCharacter)
        {
            Character character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
            character.Name = updatedCharacter.Name;
            character.Class = updatedCharacter.Class;
            character.Defense = updatedCharacter.Defense;
            character.HitPoints = updatedCharacter.HitPoints;
            character.Intelligence = updatedCharacter.Intelligence;
            character.Strength = updatedCharacter.Strength;
            return characters;
        }


        public List<Character> DeleteCharacter(int id)
        {
            Character character = characters.FirstOrDefault(c => c.Id == id);
            characters.Remove(character);
            return characters;
        }

        public Character RandomCharacter()
        {
            Random random = new Random();
            int randomInt = random.Next(0, characters.Count);
            return characters[randomInt];
        }

        Task<ServiceResponse<List<Character>>> ICharacterService.GetAllCharacters()
        {
            throw new NotImplementedException();
        }
    }
}