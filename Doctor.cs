using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalipse
{
    internal class Doctor: Human
    {
        public Doctor(int health, Place location) : base(health, location) { }

        public override string ToString()
        {
            return base.ToString() + "Doctor";
        }
    }
}
