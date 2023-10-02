using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalipse
{
    internal class Axe: Wepon
    {
        private int demage = 15;
        public Axe() { }
        public new int GetDemage() { return base.GetDemage() + demage; }

        public override string ToString()
        {
            return "Axe";
        }
    }
}
