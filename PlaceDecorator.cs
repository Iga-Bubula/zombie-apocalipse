using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalipse
{
    internal class PlaceDecorator: Place
    {
        Place place;
        private string name;
        public PlaceDecorator(List<Supply> supplys, List<Wepon> wepons, Place place): base(supplys, wepons) 
        { 
            this.place = place; 
            name = place.ToString(); 
            this.place.AddSupply(supplys);
            this.place.AddWepon(wepons);
        }

        public override string ToString()
        {
            return name;
        }
    }
}
