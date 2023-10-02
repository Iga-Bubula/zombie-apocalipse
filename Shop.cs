using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalipse
{
    internal class Shop: Place
    {
        private string name;
        public Shop(List<Supply> supplies, List<Wepon> wepons) : base(supplies, wepons) 
        {
            name = "Shop"; 
        }

        public override string ToString()
        {
            return name;
        }

    }
}
