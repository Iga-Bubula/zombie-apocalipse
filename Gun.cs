using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalipse
{
    internal class Gun: Wepon
    {
        private int demage = 25;
        private List<Ammunition> ammunition = new List<Ammunition> { };
        private int bullets;

        public Gun(Ammunition ammo) { ammunition.Add(ammo); }

        public void Reload()
        {
            if (ammunition.Count < 0) { Console.WriteLine("Cannot reload. No ammunition."); }
            else { ammunition.Remove(ammunition.Last()) ; bullets = 10; }
 
        }
        public new int GetDemage() { 
            if(bullets > 0) {
                bullets--; 
                int dem = base.GetDemage();
                return demage + dem;
            }
            else { Console.WriteLine("No bullets."); return 0; }
            
        }

        public override string ToString()
        {
            return "Gun";
        }

    }
}
