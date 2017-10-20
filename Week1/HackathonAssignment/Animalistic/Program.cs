using System;
using System.Collections.Generic;

namespace Animalistic
{
    class Program
    {
        static void Main(string[] args)
        {
            // Welcome to the game.
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("W E L C O M E   T O   A N I M A L I S T I C !");
            Console.ResetColor();
            
            // Start the game!
            Controller.StartGame();
        }
    }
}
