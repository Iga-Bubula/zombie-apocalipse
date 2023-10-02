using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalipse
{
    internal class Food: Supply
    {
        private double volume;
        private double callories;

        public Food(double volume): base(volume)
        {
            this.volume = volume;
            callories = volume * 4.5;

        }

        public void Use(Human human)
        {
            int health = human.GetHealth() + (int) callories / 10;
            human.SetSpeed(  human.GetSpeed() + (int) callories);
            human.SetHealth(health);
        }

        public override string ToString()
        {
            return  "Food";
        }
    }
}
