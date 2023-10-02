using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalipse
{
    internal class ZombieTurn
    {
        public static void MakeMove(Place location, Zombie Zombie, Human Player)
        {
            int moves = 0;
            while(moves < 2) { 

                if (Player == null) { Zombie.ChangeLocation(Map.GetRandomLocation()); }
                else 
                { 
                    if (Player.GetLocation() == location || Player.GetSCHuman() < Zombie.GetSCZombie()) 
                    {
                        Game.Fight(Player, Zombie);
                    } 
                    else { Zombie.ChangeLocation(Player.GetLocation()); }
                }
                moves++;

            }
        }
    }
}
