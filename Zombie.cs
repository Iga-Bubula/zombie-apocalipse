using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalipse
{
    internal class Zombie: ISurvivalChance
    {

        private int health;
        private int survivalChance;
        private int speed;
        private Place location;

        public Zombie(int health, int speed, Place location)
        {
            this.health = health;
            this.speed = speed;
            this.location = location;
            survivalChance = health + speed;
        }

        public int GetHealth() { return health; }
        public void SetHealth(int health) { this.health  = health; }

        public int GetSpeed() { return speed; }

        public int Fight(Human human)
        {
            int dem = 0;
            if (speed > human.GetSpeed())
            {
                health += 10;
            }
            if (human.GetSCHuman() <= survivalChance*2) 
            { 
                speed += 15;  
                Console.WriteLine("Demage received: 10");
                Console.WriteLine("Current health: " + human.GetHealth());
                dem = 10;
                
            }
            if (human.GetSCHuman() <= 0)
            {
                location.RemoveHuman(human);
                location.AddZombie(1);
                dem = 100;
            }
            else dem = 5;
            return dem;

        }

        public void ChangeLocation(Place newLocation)
        {
            location = newLocation;
        }

        public int GetSCZombie()
        {
            
            return survivalChance;
        }

    }
}
