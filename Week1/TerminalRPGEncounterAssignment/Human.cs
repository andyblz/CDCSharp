using System;

namespace TerminalRPGEncounterAssignment
{
    // Create a base Human class with 5 attributes: name, strength, intelligence, dexterity, and health.
    public class Human {
        public string personName;
        public int personStrength { get; set;}
        public int personIntel { get; set;}
        public int personDex { get; set;}
        public int personHealth { get; set;}
        public int damageDone { get; set;}

        
        // Given a default value of 3 for strength, intelligence, and dexterity. Health should have a default of 100.
        public Human(string name) 
        {
            personName = name;
            personStrength = 3;
            personIntel = 3;
            personDex = 3;
            personHealth = 100;
        }

        // Create an additional constructor that accepts 5 parameters, so we can set custom values for every field.
        public Human(string name, int strength, int intel, int dex, int health) 
        {
            personName = name;
            personStrength = strength;
            personIntel = intel;
            personDex = dex;
            personHealth = health;
        }

        // Add a new method called "attack", which when invoked, should attack another Human object that is passed as a parameter. The damage done should be 5 * strength (5 points of damage to the attacked, for each 1 point of strength of the attacker).
        public int Attack(object thing) 
        {
            if (thing is Enemy) 
            {
                Enemy victim = thing as Enemy;
                damageDone = 5 * personStrength;
                Console.WriteLine("Victim's name is {0}.", victim.enemyName);
                victim.enemyHealth -= damageDone;
                return victim.enemyHealth;
            } 
            else 
            {
                return 0;
            }
        }
    }

}