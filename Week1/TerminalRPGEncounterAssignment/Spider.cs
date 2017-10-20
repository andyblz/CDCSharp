using System;
using System.Collections.Generic;

namespace TerminalRPGEncounterAssignment
{
    public class Spider : Enemy
    {
        // Create a Spider class.
        public Spider(string name) : base(name)
        {
            enemyHealth = 200;
            Console.WriteLine("Welcome, {0}. You have health of {1}.", name, enemyHealth);
        }

        // Add Spider method.
        public void Attack(object target)
        {
            Human victim = target as Human;
            if (victim != null)
            {
                victim.personHealth -= 20;
                Console.WriteLine("Spider attack! {0}'s health is now {1}.", victim.personName, victim.personHealth);
            }
        }


    }
}