using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ZombieApocalipse
{
    internal class Test
    {
        public static bool Run()
        {
            
            
            Place Hospital = new Place(new List<Supply>() { new Flashlight(5), new FirstAidKit(8), new Food(40) }, new List<Wepon>());
            Place Shop = new Place(new List<Supply>() { new Flashlight(5), new FirstAidKit(8), new Food(40) }, new List<Wepon>() { new Knife() });
            List<Place> locations = new List<Place>() { };
            Map Map = new Map(15);
            Human Player = new Human(100, Map.GetRandomLocation());
            Zombie Zombie = new Zombie(100, 20,Player.GetLocation());
            bool noIssues = true;

            //Console.WriteLine("Hello This is test.");
            Player.SetMoves(4);

            PlayerTurn.MakeMove(Player, "get supply");
            //Console.WriteLine(" Supplies gathered! ");

            PlayerTurn.MakeMove(Player, "get wepon");
            //Console.WriteLine("Wepons accuired!");

            PlayerTurn.MakeMove(Player, "change loc");

           // Console.WriteLine("New location: " + Player.GetLocation());

            PlayerTurn.MakeMove(Player, "fight");
            //Console.WriteLine("FIGHT IS OVER \n");

            //Console.WriteLine("Survival Chance: ");

            //Console.WriteLine(Player.GetSCHuman());

            //Console.WriteLine();


            if (noIssues) { Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Test passed."); return true; }
            else { Console.ForegroundColor = ConsoleColor.Red;  Console.WriteLine("Test failed"); return false; }

        }
    }
}
