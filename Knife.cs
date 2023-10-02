using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalipse
{
    internal class Knife: Wepon
    {
        public int demage = 10; 
        public Knife() { }

        public new int  GetDemage() {
            int dem = base.GetDemage();
            return dem + demage; 
        }

        public override string ToString()
        {
            return "Knife";
        }
    }
}
