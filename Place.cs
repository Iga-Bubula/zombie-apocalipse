using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalipse
{
    internal class Place
    {
        private List<Supply> supplies;
        private List<Wepon> wepons;
        private List<Zombie> zombies;
        private List<Human> people;
        private string name = "location: ";

        public Place(List<Supply> supplies, List<Wepon> wepons, List<Zombie> zombies = null, List<Human> people = null) 
        {
            this.supplies = supplies;
            this.wepons = wepons;
        }

        public Supply Take() { if (supplies == null) { supplies.Add(new Food(1)); } return supplies.First(); }

        public Wepon TakeWepon() { if (wepons == null) { wepons.Add(new BareHands()); }   return wepons.First(); }

        public int HowManyPeople() { return people.Count; }

        public void AddSupply(List<Supply> sup)
        {
            if(sup != null) 
            {
                supplies.AddRange(sup);
            }
            else { Console.WriteLine("Error"); }
        }

        public void AddWepon(List<Wepon> wep)
        {
            if (wep != null)
            {
                wepons.AddRange(wep);
            }
            else { Console.WriteLine("Error"); }
        }

        public void AddZombie(int howMany)
        {
            Random random = new Random();
            if (zombies == null) zombies = new List<Zombie>() {new Zombie(random.Next(100), random.Next(20),this) };
            for (int i = 0; i < howMany; i++)
            {
                zombies.Add(new Zombie(random.Next(100), random.Next(30), this));
            }
        }

        public void AddPeople(int howMany)
        {
            Random random = new Random();
            if (people == null) { people = new List<Human> { new Civil(75, this) }; }
            if (howMany == 1) {people.Add(new LoneSurviver(110, this)); }
            for (int i = 0; i < howMany; i++)
            {
                int rand = random.Next(101);
                if (i == 4 || i % 6 == 0) { people.Add(new Doctor(rand, this)); }
                else people.Add(new Civil(rand, this));
            }
        }

        public Zombie GetRandomZombie()
        {
            Random rand = new Random();
            if (zombies != null)
            {
                int random = rand.Next(zombies.Count);
                return zombies[random];
            }
            else {  return new Zombie(rand.Next(100),rand.Next(30), this); }
        }

        public Human GetRandomHuman()
        {
            Random rand = new Random();
            if (people != null)
            {
                int random = rand.Next(people.Count);
                return people[random];
            }
            else { return new Human(rand.Next(100), this); }
        }

        public void RemoveZombie(Zombie zombie)
        {
            if (zombie != null)
            {
                zombies.Remove(zombie);
            }            
        }

        public void RemoveHuman(Human human)
        {
            if(people!= null) { people.Remove(human); }
            
        }

        public override string ToString()
        {
            return name;
        }
    }
}
