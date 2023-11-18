    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using net.Models;
    using net.Services;
    using net.Services.CharacterService;

    namespace net.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class CharacterController : ControllerBase
        {

            
            private readonly ICharacterService _characterService;
            private readonly IBattle _battleCharacter;

            public CharacterController(ICharacterService characterService, IBattle battleCharacter)
                {
                _characterService = characterService;
                _battleCharacter = battleCharacter;
                
            }

                [HttpGet("GetAll")]
                public async  Task<ActionResult<List<Character>>> Get(){
                    return Ok(await _characterService.GetAllCharacters());
                }



                [HttpGet("{id}")]
                public ActionResult<Character> GetSingle(int id){
                    return Ok(_characterService.GetCharacterById(id));
                }

                [HttpPost]
                public async Task<ActionResult<List<Character>>> AddCharacter(Character newCharacter){
                    return Ok(await _characterService.AddCharacter(newCharacter));
                }
                
            
[HttpPost("Battle")]
public async Task<ActionResult<ServiceResponse<BattleResult>>> Battle(int attackerId)
{
    try
    {
        // Get characters from the service using their IDs
        ServiceResponse<Character> attackerResponse = await _characterService.GetCharacterById(attackerId);
        Character attacker = attackerResponse.Data;
        Boss boss = new Boss("Evil Boss", 100, 10); // Create a boss for the battle

        // Check if characters are found
        if (attacker == null)
        {
            // Handle the case where the attacker is not found
            return NotFound(new ServiceResponse<BattleResult> { Message = "Attacker not found." });
        }

        // Perform the battle and create a BattleResult object
        BattleResult result = new BattleResult
        {
            Message = _battleCharacter.AttackBoss(attacker, boss),
            Name = attacker.Name
        };

        // Return the battle result as JSON using OkObjectResult
        return Ok(new ServiceResponse<BattleResult> { Data = result });
    }
    catch (Exception ex)
    {
        // Handle any exceptions and return an appropriate response
        return BadRequest(new ServiceResponse<BattleResult> { Message = ex.Message });
    }
}

        }
        

    }