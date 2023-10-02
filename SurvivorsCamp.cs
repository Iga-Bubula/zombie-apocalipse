using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZombieApocalipse
{
    internal class SurvivorsCamp: PlaceDecorator
    {
        private Place place;
        private string name;
        private bool accept = true;
        
        public SurvivorsCamp(List<Supply> supplies, List<Wepon> wepons, Place place): base(supplies, wepons, place) 
        {
            this.place = place;
            this.place.AddSupply(supplies);
            this.place.AddWepon(wepons);
            
            this.place.AddPeople(wepons.Count);
            name = "Survivor's Camp";
            if(this.place.HowManyPeople() > 4) accept = false;

        }

        public bool Welcome()
        {
            if(accept)
            {
                Console.WriteLine("You're accepted");
            }
            else Console.WriteLine(" There's too many people. You can't come in.");
            return accept;
        }

        public override string ToString()
        {
            return name;
        }

    }
}
