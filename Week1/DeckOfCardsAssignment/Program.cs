using System;

namespace DeckOfCardsAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wanna play a game?");
            Deck newGame = new Deck();
            newGame.Shuffle();

            Player person1 = new Player("jennifer");
            Console.WriteLine("Welcome, {0}", person1.playerName);

            person1.Draw(newGame);
            person1.Discard(0);
            person1.Discard(0);          

            newGame.Reset();  
        }
    }
}
