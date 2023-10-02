using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalipse
{
    internal class MilitaryShop: PlaceDecorator
    {
        private Place place;
        public MilitaryShop(List<Supply> supplys, List<Wepon> wepons, Place place): base(supplys, wepons, place) 
        { 
            this.place = place;
            this.place.AddSupply(supplys);
            this.place.AddWepon(wepons);
        }

        public override string ToString()
        {
            return "Military Shop";
        }
    }
}
