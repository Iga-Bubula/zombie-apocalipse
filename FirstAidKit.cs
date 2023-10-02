using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalipse
{
    internal class FirstAidKit: Supply
    {
        double volume { get; set; }
        public FirstAidKit(double volume): base(volume) { this.volume = volume; }

       public new void Use(Human human)
        {
            int health = human.GetHealth() + 20;
            human.SetHealth(health);
        }

        public override string ToString()
        {
            return "First Aid Kit";
        }

    }
}
