using System;
using System.Collections.Generic;

namespace WizardNinjaSamuraiAssignment
{
    public class Samurai : Human
    {        
        public static int count = 0;

        // Samurai should have a default health of 200.
        public Samurai(string name) : base(name)
            {
                personHealth = 200;
                count ++;
                Console.WriteLine("Welcome, {0}. You have health of {1}.", name, personHealth);
            }

        // Samurai should have a method called "DeathBlow", which when invoked, should attack an object and decreases its health to 0 if it has less than 50 health.
        public void DeathBlow(object target)
        {
            Human victim = target as Human;
            if (victim != null && victim.personHealth < 50)
            {
                victim.personHealth = 0;
                Console.WriteLine("DeathBlow successful! {0} is now dead.", victim.personName);
            }
            else
            {
                Console.WriteLine("DeathBlow failed!");
            }
        }


        // Samurai should have a method called "Meditate", which when invoked, heals the Samurai back to full health.
        public void Meditate()
        {
            personHealth = 200;
            Console.WriteLine("{0}, your health is back to 200.", personName);
        }


        // Samurai should have a class method called "HowMany", which when invoked, displays how many Samurais there are. (Hint: Use the static keyword).
        public void HowMany()
        {
            Console.WriteLine("There are {0} samurais.", count);
        }
    }
}