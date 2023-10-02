using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZombieApocalipse
{
    internal class Human: ISurvivalChance
    {
        private List<Supply> supplies = new List<Supply> {new Food(10) };
        private double ContainerVolume = 50;
        private int health;
        private Place location;
        private List<Wepon> wepons = new List<Wepon> { new BareHands() };
        private int speed = 20;
        int moves = 5;

        public Human(int health, Place location) 
        { 
            this.health = health;
            this.location = location;
        }

        public void ChangeLocation(Place newLocation)
        {
            location = newLocation;
        }

        public void GetSupplies()
        {
            Supply taken = location.Take();
            if (ContainerVolume - taken.GetVolume() >= 0) 
            { 
                ContainerVolume -= taken.GetVolume();
                supplies.Add(taken); 
            }
            else Console.WriteLine("No room for new supplies.");
            if (supplies != null) {
                Console.WriteLine("Currently in your inventory you have:");
                foreach (Supply supply in supplies) { Console.WriteLine(supply.ToString()); }
                Console.WriteLine("Container Volume: " + ContainerVolume);
            }

            
        }

        public void GetWepons()
        {
            Wepon taken = location.TakeWepon();
            if (wepons.Count < 3) { wepons.Add(taken); }
            else
            {
                wepons.Remove(wepons.First());
                wepons.Add(taken);
            }
            if (wepons != null)
            {
                Console.WriteLine("Currently in your inventory you have:");
                foreach (Wepon wep in wepons) { Console.WriteLine(wep.ToString()); }
            }
        }

        public int UseWepon(int choice)
        {
            if (choice < 0) { Game.Issue(); return 0; }
            else
            {
                
                Wepon chosen = wepons[choice];
                int dem = chosen.GetDemage();
                switch (chosen.ToString())
                {
                    case "Gun":
                        Gun gun = (Gun)chosen;
                        dem = gun.GetDemage();
                        break;
                    case "BareHands":
                        BareHands bareHands = (BareHands)chosen;
                        int newhealth = wepons[choice].GetDemage() + bareHands.Demage();
                        SetHealth(newhealth);
                        dem = bareHands.GetDemage();
                        break;
                    case "Knife":
                        Knife knife = (Knife)chosen;
                        dem = knife.GetDemage();
                        break;
                    case "Axe":
                        Axe axe = (Axe)chosen;
                        dem = axe.GetDemage();
                        break;
                }
                return dem;
            }         
        }

        public int PickWepon()
        {
            bool notchosen = true;
            int index = 0;
            while (notchosen)
            {
                if (index >= wepons.Count) { index = 0; }
                Console.WriteLine(wepons[index].ToString() + " " + (index + 1) + "/" + (wepons.Count));
                Console.WriteLine("Would you like to chose this wepon?");

                string choice = Game.UserInput();
                if (Game.acceptAnswer(choice, 2))
                {
                    if (choice.ToLower() == "y" || choice.ToLower() == "yes") notchosen = false;
                    else index++;
                }
                else Console.WriteLine("Answer declined.");
            }
            return index;
        }

        public int PickItem()
        {
            bool notchosen = true;
            int index = 0;
            if (supplies == null || supplies.Count == 0) { Game.Issue(); return index; }
            else
            {
                while (notchosen)
                {
                    if (index >= supplies.Count) { index = 0; }
                    string s = supplies[index].ToString();
                    Console.WriteLine(s + (index + 1) + "/" + (supplies.Count));
                    Console.WriteLine("Would you like to chose this item?");

                    string choice = Game.UserInput();

                    if(Game.acceptAnswer(choice, 2)) {
                        if (choice.ToLower() == "y" || choice.ToLower() == "yes") notchosen = false;
                        else index++;
                    }             
                    else Console.WriteLine("Answer declined.");
                }
                return index;
            }
        }

        public void Inventory() {
            if (supplies != null)
            {
                Console.WriteLine("Currently in your inventory you have:");
                foreach (Supply supply in supplies) { Console.WriteLine(supply.ToString()); }
                Console.WriteLine("Container Volume: " + ContainerVolume);
            }
        }

        public void UseItem(int choice) { 
            if (choice < 0) { Game.Issue(); }
            else {
                Supply chosen = supplies[choice];
                switch (chosen.ToString())
                {
                    case "Food":
                        Food itemFood = (Food) chosen;
                        itemFood.Use(this);
                        Console.WriteLine("Eating " + chosen.ToString());
                        supplies.Remove(chosen);
                        break;
                    case "Flashlight":
                        Flashlight itemLight = (Flashlight) chosen;
                        itemLight.Use();
                        Console.WriteLine("Using " + chosen.ToString());
                        break;
                    case "Ammunition":
                        foreach (Wepon wep in wepons)
                        {
                            if (wep.GetType() == typeof(Gun))
                            {
                                Gun gun = (Gun)wep;
                                supplies.Remove(chosen);
                                gun.Reload();
                                wepons.Remove(wep); 
                                wepons.Add(gun);
                            }
                        }
                        break;
                    case "First Aid Kit":
                        FirstAidKit itemFAK = (FirstAidKit) chosen;
                        itemFAK.Use(this);
                        supplies.Remove(chosen);
                        break;
                    case " ":
                        //chosen.Use();
                        supplies.Remove(chosen);
                        break;
                }

                
            }
        }

        public bool Run() 
        {
            if (speed >= 15) { ChangeLocation(Map.GetRandomLocation()); return true; }
            else return false; 
        }

        public int GetSuppliesBonus() { return supplies.Count * 5; }
        public int GetWeponsBonus() { return wepons.Count * 10; }
        public int GetSpeed() { return speed; }
        public void SetSpeed(int speed) { this.speed = speed;}
        public void SetHealth(int health) { this.health = health; }
        public int GetHealth() { return health; }
        public int GetMoves() { return moves; }
        public void SetMoves(int moves) { this.moves = moves;}
        public Place GetLocation() { return location; }

        public int GetSCHuman()
        {
            int sc = health + speed + this.GetSuppliesBonus() + this.GetWeponsBonus();
            return sc;
        }

        public override string ToString()
        {
            return "";
        }
    }
}
