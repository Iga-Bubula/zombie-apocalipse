using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZombieApocalipse
{
    internal class Hospital: Place
    {
        private string name;
        public Hospital(List<Supply> supplies, List<Wepon> wepons) : base(supplies, wepons) 
        {
            name = "Hospital"; 
        }


        public override string ToString()
        {
            return name;
        }

    }
}
