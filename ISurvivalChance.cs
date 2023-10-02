using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalipse
{
    internal interface ISurvivalChance
    {
        public int GetSCZombie(Zombie zom)
        {
            int sc = zom.GetHealth() + zom.GetSpeed();
            return sc;
        }

        public int GetSCHuman(Human hum)
        {
            int sc = hum.GetHealth() + hum.GetSpeed() + hum.GetSuppliesBonus() + hum.GetWeponsBonus();
            return sc;
        }
    }
}
