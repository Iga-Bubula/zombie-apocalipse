using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalipse
{
    internal class Ammunition: Supply
    {
        private double volume { get; set; }
        public Ammunition(double volume): base(volume) { this.volume = volume; }

        public override string ToString()
        {
            return "Ammunition";
        }
    }
}
