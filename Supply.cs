using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalipse
{
    internal class Supply
    {
        private double Volume;
        public Supply(double Volume) { 
            this.Volume = Volume;
        }

        public double GetVolume() { return  Volume; }

        public void Use() 
        {
            Console.WriteLine("Object is used.");
        }

        public override string ToString()
        {
            return " ";
        }

    }
}
