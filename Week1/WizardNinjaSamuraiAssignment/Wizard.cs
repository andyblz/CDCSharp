using System;
using System.Collections.Generic;

namespace WizardNinjaSamuraiAssignment
{
    public class Wizard : Human
    {
        // Wizard should have a default health of 50, and intelligence of 25.
        public Wizard(string name) : base(name)
        {
            personHealth = 50;
            personIntel = 25;
            Console.WriteLine("Welcome, {0}. You have a health of {1}, and a intelligence of {2}.", name, personHealth, personIntel);
        }


        // Wizard should have a method called "heal", which when invoked, heals the Wizard by 10 * intelligence.
        public void Heal()
        {
            personHealth += 10 * personIntel;
            Console.WriteLine("Healed for {0} points. Health is now at {1}.", (10 * personIntel), personHealth);
        }


        // Wizard should have a method called "fireball", which when invoked, decreases the health of attacked by some random integer between 20 and 50.
        public void Fireball(object target)
        {
            Human victim = target as Human;
            if (victim != null)
            {
                Random rand = new Random();
                victim.personHealth -= rand.Next(20, 51);
                Console.WriteLine("Dealt {0} damage to {1}.", (rand.Next(20, 51)), victim.personName);
            }
        }

    }

}