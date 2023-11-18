using System;
using net.Models;

namespace net.Services.CharacterService
{
    public class BattleCharacter : IBattle
    {
        public Character Fight(Character attacker, Boss boss)
        {
            int damage = attacker.Strength - boss.AttackStrength;
            if (damage > 0)
            {
                boss.HitPoints -= damage;
            }
            return attacker;
        }

        public Character Winner(Character attacker, Boss boss)
        {
            Fight(attacker, boss);
            
            if (boss.HitPoints <= 0)
            {
                return attacker;
            }
            else
            {
                return null; // The battle is ongoing; the boss is not defeated yet
            }
        }

        public string AttackBoss(Character player, Boss boss)
        {
            Random random = new Random();
            int d20Roll = random.Next(1, 21); // Roll a D20 (1 to 20)

            if (d20Roll >= 10) // Simple check, you can adjust this threshold
            {
                // Player successfully hits the boss    

                boss.HitPoints -= player.Strength;
                return $"{player.Name} successfully hit the boss! \n D20 roll: {d20Roll}";
            }
            else
            {
                // Player misses the boss
                return $"{player.Name} missed the boss! \n D20 roll: {d20Roll}";
            }
        }

        
    }
}
