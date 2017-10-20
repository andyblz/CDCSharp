using System;
using System.Collections.Generic;

namespace TerminalRPGEncounterAssignment
{
    public class Ninja : Human
    {
        // Ninja should have a default dexterity of 175.
        public Ninja(string name) : base(name)
        {
            personDex = 175;
            Console.WriteLine("Welcome, {0}. You have a dexterity of {1}.", name, personDex);
        }


        // Ninja should have a "steal" method, which when invoked, attacks an object and increases the Ninja's health by 10.
        public void Steal(object target)
        {
            Enemy victim = target as Enemy;
            if (victim != null)
            {
                personHealth += 10;
                Console.WriteLine("Steal success! Gained 10 health. Health is now: {0}.", personHealth);
            }
        }

        // Ninja should have a "GetAway" method, which when invoked, decreases its health by 15.
        public void GetAway()
        {
            personHealth -= 15;
            Console.WriteLine("Got away, and lost 15 health. Health is now: {0}.", personHealth);
        }
    }
}