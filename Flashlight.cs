using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalipse
{
    internal class Flashlight: Supply
    {
        private double volume { get; set; }
        private bool isON = false;
        public Flashlight(double volume): base(volume) { this.volume = volume; }

        public void TurnOn() {
            if (isON)
            {
                Console.WriteLine("Flashlight is already turned on.");
                TurnOff();
            }
            else isON = true; 
        }

        public void TurnOff()
        {
            if (isON) isON = false;
            else
            {
                Console.WriteLine("Flashlight is already turned off.");
                TurnOn();
            }
        }

        public new void Use()
        {
            TurnOn();
        }

        public override string ToString()
        {
            return "Flashlight";
        }
    }
}
