using System;
using System.Collections.Generic;

namespace Animalistic
{
    class Controller
    {
        public string userClass { get; set; }
        public string userName { get; set; }
        public string userInstance { get; set; }
        public dynamic compPlayer { get; set; }


        public static void StartGame()
        {
            dynamic userPlayer = CreateUser();
            dynamic compChar = CompAction(userPlayer);

            while (userPlayer.health > 0 || compChar.health > 0)
            {
                // dynamic compChar = CompAction(userPlayer);
                dynamic userChar = UserAction(userPlayer);

                string playerAction = Console.ReadLine();

                if (userChar is Canine)
                {
                    if (playerAction == "Bite")
                    {
                        userChar.Bite(compChar); 
                    } 
                    else if (playerAction == "Dodge")
                    {
                        userChar.Dodge();
                    } 
                    else if (playerAction == "Rest")
                    {
                        userChar.Rest();
                    }
                    else
                    {
                        Console.WriteLine("Action not available.");
                        UserAction(userPlayer);
                    }
                }
                else
                {
                    if (playerAction == "Bite")
                    {
                        userChar.Bite(compChar); 
                    } 
                    else if (playerAction == "Claw")
                    {
                        userChar.Claw(compChar);
                    }
                    else if (playerAction == "Dodge")
                    {
                        userChar.Dodge();
                    } 
                    else if (playerAction == "Rest")
                    {
                        userChar.Rest();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ACTION NOT AVAILABLE.");
                        Console.ResetColor();
                        continue;
                    }
                }

                Random rand = new Random();
                int random = rand.Next(1,4);

                if (compChar is Canine)
                {
                    if (random == 1)
                    {
                        compChar.Bite(userChar);
                    }
                    else if (random == 2)
                    {
                        compChar.Dodge();
                    }
                    else
                    {
                        compChar.Rest();
                    }
                }
                else
                {
                    if (random == 1)
                    {
                        compChar.Bite(userChar);
                    }
                    else if (random == 2)
                    {
                        compChar.Claw(userChar);
                    }
                    else if (random == 3)
                    {
                        compChar.Dodge();
                    }
                    else
                    {
                        compChar.Rest();
                    }
                }
            }

            GameOver();
        }

        // Ask for user's turn action.
        public static object UserAction(object player)
        {
            if (player is Canine)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("PICK AN ACTION: Bite, Dodge, Rest");
                Console.ResetColor();
                return player;
            }
            else 
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("PICK AN ACTION: Bite, Claw, Dodge, Rest");
                Console.ResetColor();
                return player;
            }
        }

        public static object CompAction(object player)
        {
            if (player is Canine)
            {
                object computerPlayer = ComputerFeline();
                return computerPlayer;
            }
            else 
            {
                object computerPlayer = ComputerCanine();
                return computerPlayer;
            }
        }

        // Ask user for their character and name choice.
        public static object CreateUser()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("What class do you want to be?");
            Console.WriteLine("SELECT (CANINE): '1' for Wolf, '2' for Hyena, '3' for Husky.");
            Console.WriteLine("SELECT (FELINE): '4' for Tiger, '5' for Cheetah, '6' for Feral Cat.");
            Console.WriteLine("Type 'Quit' to quit game");
            Console.ResetColor();

            string userClass = Console.ReadLine();

            if (userClass == "Quit")
            {
                QuitGame();
                return null;
            }
            
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("What do you want your character's name to be?");
            Console.ResetColor();

            string userName = Console.ReadLine();

            if (userName == "Quit")
            {
                QuitGame();
                return null;
            }

            switch (userClass)
            {
                case "1":
                    Wolf newWolf = new Wolf(userName);      
                    return newWolf;
                case "2":
                    Hyena newHyena = new Hyena(userName);          
                    return newHyena;
                case "3":
                    Husky newHusky = new Husky(userName);               
                    return newHusky;
                case "4":
                    Tiger newTiger = new Tiger(userName);               
                    return newTiger;
                case "5":
                    Cheetah newCheetah = new Cheetah(userName);               
                    return newCheetah;
                case "6":
                    FeralCat newFeralCat = new FeralCat(userName);              
                    return newFeralCat;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("NOT AN OPTION.");
                    Console.ResetColor();
                    StartGame();
                    return null;
            }
        }

        // Quit game.
        public static void QuitGame()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("AW, YOU'RE LEAVING? :(");
            Console.WriteLine("G A M E   E N D E D .");
            Console.ResetColor();
            Environment.Exit(0);
        }

        // Game over.
        public static void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("G A M E   O V E R !");
            Console.ResetColor();
            Environment.Exit(0);
        }

        // If user selects a Feline character, the computer will randomly select a Canine character to play as.
        public static object ComputerCanine()
        {
            Random rand = new Random();
            int random = rand.Next(1,4);

            if (random == 1)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("YOU'RE PLAYING AGAIN HUSKY BOT!");
                Console.ResetColor();
                Husky newHusky = new Husky("Husky Bot");
                return newHusky;
            }
            else if (random == 2)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("YOU'RE PLAYING AGAINST HYENA BOT!");
                Console.ResetColor();
                Hyena newHyena = new Hyena("Hyena Bot");
                return newHyena;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("YOU'RE PLAYING AGAINST WOLF BOT!");
                Console.ResetColor();
                Wolf newWolf = new Wolf("Wolf Bot");
                return newWolf;
            }
        }

        // If user selects a Canine character, the computer will randomly select a Feline character to play as.        
        public static object ComputerFeline()
        {
            Random rand = new Random();
            int random = rand.Next(1,4);

            if (random == 1)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("YOU'RE PLAYING AGAINST FERAL CAT BOT!");
                Console.ResetColor();
                FeralCat newFeralCat = new FeralCat("Feral Cat Bot");
                return newFeralCat;
            }
            else if (random == 2)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("YOU'RE PLAYING AGAINST CHEETAH BOT!");
                Console.ResetColor();
                Cheetah newCheetah = new Cheetah("Cheetah Bot");
                return newCheetah;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("YOU'RE PLAYING AGAINST TIGER BOT!");
                Console.ResetColor();
                Tiger newTiger = new Tiger("Tiger Bot");
                return newTiger;
            }
        }
    }
}
