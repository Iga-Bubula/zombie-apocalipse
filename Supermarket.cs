using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZombieApocalipse
{
    internal class Supermarket: PlaceDecorator
    {
        private Place place;
        private string name;
        public Supermarket(List<Supply> supplies, List<Wepon> wepons, Place place): base(supplies, wepons, place) 
        {
            this.place = place;
            place.AddSupply(supplies);
            place.AddWepon(wepons);
            name = "Supermarket";
        }


        public override string ToString()
        {
            return name;
        }

    }
}
