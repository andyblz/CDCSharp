using System;

namespace TerminalRPGEncounterAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("S T A R T   G A M E !");

            Ninja newNinja = new Ninja("Mia");
            Samurai newSamurai = new Samurai("Jack");
            Wizard newWizard = new Wizard("Harry");

            Zombie newZombie = new Zombie("Naix");
            Spider newSpider = new Spider("Brood");

        }
    }
}
