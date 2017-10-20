using System;

namespace HumanAssignment
{
    // Create a base Human class with 5 attributes: name, strength, intelligence, dexterity, and health.
    public class Human {
        public string personName;
        public int personStrength;
        public int personIntel;
        public int personDex;
        public int personHealth;
        public int damageDone;

        // Create an additional constructor that accepts 5 parameters, so we can set custom values for every field.
        // Given a default value of 3 for strength, intelligence, and dexterity. Health should have a default of 100.
        public Human(string name, int strength = 3, int intel = 3, int dex = 3, int health = 100) {
            personName = name;
            personStrength = strength;
            personIntel = intel;
            personDex = dex;
            personHealth = health;
        }

        // Add a new method called "attack", which when invoked, should attack another Human object that is passed as a parameter. The damage done should be 5 * strength (5 points of damage to the attacked, for each 1 point of strength of the attacker).
        public int Attack(Human victim) {
            damageDone = 5 * personStrength;
            Console.WriteLine("Victim's name is {0}.", victim.personName);
            victim.personHealth -= damageDone;
            return victim.personHealth;
        }

        // Change the last function to accept any object and just make sure it is of type Human before applying damage.
        public int Attack(object thing) {
            if (thing is Human) {
                Human victim = thing as Human;
                damageDone = 5 * personStrength;
                Console.WriteLine("Victim's name is {0}.", victim.personName);
                victim.personHealth -= damageDone;
                return victim.personHealth;
            } else {
                return 0;
            }
        }
    }

}