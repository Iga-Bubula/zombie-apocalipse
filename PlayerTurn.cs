using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalipse
{
    internal class PlayerTurn
    {


        public static void MakeMove(Human Player, string command)
        {
            if (command == "dead")
            {
                Game.GameOver();
            }
            else
            {
                int movesleft = Player.GetMoves() - 1;
                Player.SetMoves(movesleft);

                if (Player.GetMoves() == 0)
                {
                    Console.WriteLine("No moves left.");
                }
                else
                {
                    switch (command)
                    {
                        case "change loc":
                            bool travel = true;
                            Place newLocation = Map.GetRandomLocation();
                            while (travel)
                            {
                                Console.WriteLine("Would you like to travel to " + newLocation.ToString() + "?");

                                string ans = Game.UserInput();

                                if (Game.acceptAnswer(ans, 2))
                                {
                                    if (ans.ToLower() == "y" || ans.ToLower() == "yes")
                                    {
                                        if (newLocation.ToString() == "Survivors Camp")
                                        {
                                            SurvivorsCamp survivorsCamp = (SurvivorsCamp)newLocation;
                                            if (survivorsCamp.Welcome()) { Player.ChangeLocation(survivorsCamp); travel = false; }

                                        }
                                        else
                                        {
                                            Player.ChangeLocation(newLocation);
                                            travel = false;
                                        }
                                    }
                                    else newLocation = Map.GetRandomLocation();
                                }
                                else Console.WriteLine("Answer declined. Try again.");
                            }
                            break;

                        case "get supply":
                            Player.GetSupplies();
                            break;

                        case "use":
                            int index = Player.PickItem();
                            Player.UseItem(index);
                            break;

                        case "fight":
                            Zombie Zombie = Player.GetLocation().GetRandomZombie();
                            if (Zombie != null)
                            {
                                Game.Fight(Player, Zombie);
                            }
                            else Console.WriteLine("There is no enemy to fight. ");
                            break;

                        case "get wepon":
                            Player.GetWepons();
                            break;

                        case null:
                            Game.Issue();
                            break;
                    }
                }

            }
        }


        public static void MakeRandomMove(Human man, string command)
        {
            int movesleft = man.GetMoves() - 1;
            man.SetMoves(movesleft);
            while (movesleft > 0)
            {
                switch (command)
                {
                    case "change loc":
                        bool travel = true;
                        Place newLocation = Map.GetRandomLocation();
                        if (newLocation.ToString() == "Survivors Camp")
                        {
                            SurvivorsCamp survivorsCamp = (SurvivorsCamp)newLocation;
                            if (survivorsCamp.Welcome()) { man.ChangeLocation(survivorsCamp); }
                        }
                        else
                        {
                            newLocation = Map.GetRandomLocation();
                            man.ChangeLocation(newLocation);
                        }
                        break;
                    case "get supply":
                        man.GetSupplies();
                        break;
                    case "use":
                        man.UseItem(0);
                        break;

                    case "fight":
                        Zombie Zombie = man.GetLocation().GetRandomZombie();
                        if (Zombie != null)
                        {
                            Game.Fight(man, Zombie);
                        }
                        break;

                    case "get wepon":
                        man.GetWepons();
                        break;
                }
            movesleft--;

            }
        }
    }
}
