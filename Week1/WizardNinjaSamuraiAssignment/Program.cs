using System;

namespace WizardNinjaSamuraiAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Wizard, Ninja, Samurai!");

            Wizard newWizard = new Wizard("Harry Potter");
            Ninja newNinja = new Ninja("Mia");
            Samurai newSamurai = new Samurai("Jack");
            Samurai newSamurai2 = new Samurai("Kenshin");

            newWizard.Heal();
            newWizard.Fireball(newSamurai);

            newNinja.Steal(newWizard);
            newNinja.GetAway();

            newSamurai.DeathBlow(newNinja);
            newSamurai.Meditate();
            newSamurai.HowMany();
        }
    }
}
