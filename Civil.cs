using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalipse
{
    internal class Civil: Human
    {
        public Civil(int health, Place location): base(health, location) { }

        public override string ToString()
        {
            return base.ToString() + "Civil";
        }
    }
}
