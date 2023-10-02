using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalipse
{
    internal class Map
    {
        private static List<Place> map;
        private List<Supply> shopSupplies = new List<Supply> { new Flashlight(5), new Food(55) };
        private List<Supply> hospitalSupplies = new List<Supply> { new FirstAidKit(15), new Food(15) };
        private List<Wepon> shopWepons = new List<Wepon>() { new Knife() };
        private List<Wepon> hospitalWepons = new List<Wepon> {};
        private List<Wepon> militaryShopWepons = new List<Wepon>() { new Knife(), new Gun(new Ammunition(10)), new Axe() };
        private List<Supply> militaryShopSupplies = new List<Supply> { new Ammunition(30), new FirstAidKit(5)};


        public Map(int numberOfLocations)
        {
            map = new List<Place>();
            if (numberOfLocations <= 0) { Game.Issue(); }
            for (int i = 0; i < numberOfLocations; i++)
            {

                if (i == 5) { map.Add(new Hospital(hospitalSupplies, hospitalWepons)); }
                else if (i % 7  == 0) { map.Add(new Supermarket(shopSupplies, shopWepons, new Shop(shopSupplies, shopWepons))); }
                else if (i == 9 || i % 13 ==0) { map.Add(new MilitaryShop(militaryShopSupplies, militaryShopWepons, map.First())); }
                else if (i == 11 || i % 17 == 0) { map.Add(new SurvivorsCamp(shopSupplies, militaryShopWepons, new Hospital(hospitalSupplies, hospitalWepons))); }
                else map.Add(new Shop(shopSupplies, shopWepons));
                
            }

            Populate(numberOfLocations*2); 
            Invade(numberOfLocations);
            //Console.WriteLine(map.Count);

        }

        public static Place GetRandomLocation()
        {
            Random randomSeed = new Random();
            if (map != null)
            {
                int rand = randomSeed.Next(0, map.Count);
                //Console.WriteLine(map[rand].ToString());
                return map[rand];
            }
            else { Console.WriteLine("Error: Map Random Loc"); return new Shop(new List<Supply> { new Food(25) }, new List<Wepon> { new Knife()}); };
            
        }

        public void Invade(int n)
        {
            Random randomSeed = new Random();
            if (map != null)
            {
                int rand = randomSeed.Next(0, map.Count);
                map[rand].AddZombie(n);
            }
        }

        public void Populate(int n)
        {
            Random randomSeed = new Random();
            if (map != null)
            {
                int rand = randomSeed.Next(0, map.Count);
                map[rand].AddPeople(n);
            }
        }
        
    }
}
