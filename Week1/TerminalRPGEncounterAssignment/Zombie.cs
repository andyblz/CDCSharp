using System;
using System.Collections.Generic;

namespace TerminalRPGEncounterAssignment
{
    public class Zombie : Enemy
    {
        // Create a Zombie class.
        public Zombie(string name) : base(name)
        {
            enemyHealth = 300;
            Console.WriteLine("Welcome, {0}. You have health of {1}.", name, enemyHealth);
        }

        // Add Zombie method.
        public void Attack(object target)
        {
            Human victim = target as Human;
            if (victim != null)
            {
                victim.personHealth -= 30;
                Console.WriteLine("Zombie attack! {0}'s health is now {1}.", victim.personName, victim.personHealth);
            }
        }


    }
}