using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ZombieApocalipse
{
    internal class Game
    {
        static Map map;
        static Human Player;
        static Zombie Enemy;
        static string[] answerPack1 = { "A", "B", "C", "D", "E" };
        static string[] answerPack2 = { "y", "yes", "n", "no" };
        static string[] answerPack3 = { "use", "change loc", "fight", "get supply", "get wepon" };


        public static int Settings()
        {
            Console.WriteLine("Type the number of rounds you want to play.");
            int numberOfRounds = 0;
            bool accepted = true;
            while (accepted)
            {
                try {
                    numberOfRounds = Convert.ToInt32(Console.ReadLine());
                    if (numberOfRounds == 0) Console.WriteLine("Answer declined. Try again.");
                    else if (numberOfRounds < 10) { accepted = false; map = new Map(numberOfRounds * 5); }
                    else if (numberOfRounds >= 10) Console.WriteLine("Maximum number of rounds is 9. Try again. ");
                }
                catch (System.FormatException) { Console.WriteLine("Answer declined. Plese enter a number."); }
            }

            Console.WriteLine("Number of rounds: " + numberOfRounds + "\n");
            return numberOfRounds;
        }



        public static void Run()
        {

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to Zombie Apocalipse! \n");
            Console.ForegroundColor = ConsoleColor.White;
            int numberOfRounds = Settings();
            Console.WriteLine();

            Player = characterChoice();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You chose: " + Player.ToString() + "\n");
            Console.ForegroundColor = ConsoleColor.White;

            int day = 1;
            while (day <= numberOfRounds)
            {
                if (Player != null)
                {
                    

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Day: " + day + "\n");
                    Player.SetMoves(5);

                    Player.Inventory();

                    Console.ForegroundColor = ConsoleColor.White;

                    int moves = Player.GetMoves();
                    while (moves>0)
                    {
                        Enemy = Player.GetLocation().GetRandomZombie();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Current location: " + Player.GetLocation().ToString());
                        Console.WriteLine("You have " + Player.GetMoves() + " action points. \n");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Choose your move: ");
                        Console.WriteLine("A. use object");
                        Console.WriteLine("B. change location");
                        Console.WriteLine("C. fight");
                        Console.WriteLine("D. get supply");
                        Console.WriteLine("E. get weppon");

                        string command = UserInput();

                        if (acceptAnswer(command, 1))
                        {
                            moves--;
                            for (int i = 0; i < answerPack1.Count(); i++)
                            {
                                if (answerPack1[i] == command.ToUpper())
                                {
                                    command = answerPack3[i];
                                    //Console.WriteLine("Your command: " + command);
                                    break;
                                }
                            }
                            Console.WriteLine();
                            PlayerTurn.MakeMove(Player, command);
                            
                        }
                        else { Console.WriteLine("Answer declined"); }
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n Zombie's turn!");
                    Console.ForegroundColor = ConsoleColor.White;
                    ZombieTurn.MakeMove(Player.GetLocation(), Enemy, Player);


                    //Console.ForegroundColor = ConsoleColor.Yellow;
                    //Console.WriteLine("\n Random turn!");
                    //Console.ForegroundColor = ConsoleColor.White;
                    //Place randomLocation = Map.GetRandomLocation();

                    //Random random = new Random();
                    //PlayerTurn.MakeRandomMove(randomLocation.GetRandomHuman(), answerPack3[random.Next(5)]);
                    //ZombieTurn.MakeMove(randomLocation, randomLocation.GetRandomZombie(), randomLocation.GetRandomHuman());
                    day++;
                }
                else
                {
                    GameOver();
                    break;
                }

            }

            Console.WriteLine("Ending game");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("You won <3");
            Console.ForegroundColor = ConsoleColor.White;

            Quit();


        }

        public static Human characterChoice()
        {
            Console.WriteLine("Which character do you chose?");
            Console.WriteLine("A. Civil [better equipment]");
            Console.WriteLine("B. Doctor [ability to heal]");
            Console.WriteLine("C. Lone Survivor [better at fighting]");

            
            string input;
            Human Player = new Human(0, Map.GetRandomLocation());
            for(int i = 0;i<100;i++)
            {
                input = UserInput();
                if (acceptAnswer(input, 1))
                {
                    if (input.ToUpper() == "A") { Player = new Civil(90, Map.GetRandomLocation());  return Player; }
                    else if (input.ToUpper() == "C") { Player = new LoneSurviver(110, Map.GetRandomLocation());  return Player; }
                    else if (input.ToUpper() == "B") { Player = new Doctor(100, Map.GetRandomLocation());  return Player; }
                }
                else
                {
                    Console.WriteLine("Answer declined.");
                }
            }
            Issue();
            return Player;
        }

        public static bool acceptAnswer(string answer, int i)
        {
            bool accepted = false; ;
            if (i == 1) foreach (string answer2 in answerPack1) { if (answer.ToUpper() == answer2) accepted = true; }
            else if (i == 2) foreach (string answer3 in answerPack2) { if (answer.ToLower() == answer3) accepted = true; }
            else if (answer == " ") { Console.WriteLine("No input"); accepted = false; }
            else { Issue(); }
            return accepted;
        }

        public static void Fight(Human man, Zombie zombie)
        {
            int choice;
            int demageMan;
            
            Random rand = new Random();
            bool fight = true;
            bool manWon = false;
            bool manRun = false;

            while (fight)
            {
                int healthZombie = zombie.GetHealth();
                int healthMan = man.GetHealth();

                Console.WriteLine("Your chance of survival: " + man.GetSCHuman());
                Console.WriteLine("Zombie's chance of survival: " + zombie.GetSCZombie());
                Console.WriteLine("Your health: " + man.GetHealth());
                Console.WriteLine("Zombie's health: " + zombie.GetHealth());

                if (healthMan <= 0)
                {
                    manWon = false;
                    break;
                }
                else if (healthZombie <= 0)
                {
                    manWon = true;
                    break;
                }

                Console.WriteLine("Do you wish to continue the fight?");

                string a = UserInput();
                bool decision = true;
                while (decision)
                {
                    if (acceptAnswer(a, 2))
                    {
                        if (a.StartsWith('n'))
                        {
                            if (man.Run()) { manRun = true; fight = false; break; }
                            else Console.WriteLine("You tried to run away, but zombie caught you!");
                        }
                        decision = false;
                        manRun = false;
                    }
                    else { Console.WriteLine("Answer declined. Try again."); }
                }

                

                if (!manRun)
                {
                    if (man == Player)
                    {
                        choice = Player.PickWepon();
                        demageMan = Player.UseWepon(choice);
                    }
                    else
                    {
                        choice = 0;
                        demageMan = man.UseWepon(choice);
                    }

                    Console.WriteLine("You attack dealing " + demageMan + " demage");
                    healthZombie -= demageMan;

                    zombie.SetHealth(healthZombie);

                    healthMan -= zombie.Fight(man);
                    man.SetHealth(healthMan);
                }
                    

            }

            if (!manWon && !manRun)
            {
                if (man == Player) { GameOver(); }
                else man.GetLocation().RemoveHuman(man);
            }
            else if (manRun) Console.WriteLine("Run away to " + man.GetLocation().ToString());
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Zombie defeated.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    

        public static void Quit()
        {
            Console.WriteLine("Quitting...");
            Environment.Exit(0);
        }

        public static void Issue()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error occured.");
            Console.ForegroundColor = ConsoleColor.White;
            Quit();
        }

        public static void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Would you like to play again?");
            string command = UserInput();
            if (acceptAnswer(command, 2)) {
                if (command.ToLower().StartsWith('y') ) Run(); 
                else Quit();
            }
            else Quit();

        }

        public static string UserInput()
        {
            string input = Console.ReadLine();
            if (input == null) { Console.WriteLine("No input"); return " "; }
            return input;
        }
    }
}
