using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using net.Models;

namespace net.Services
{
    public interface IBattle
    {

        public Character Fight(Character attacker, Boss boss);
       public Character Winner(Character attacker, Boss boss);
         public string AttackBoss(Character player, Boss boss);
       
    }
}