using System;

namespace TerminalRPGEncounterAssignment
{
    // Create a base Enemy class with 5 attributes: name, strength, intelligence, dexterity, and health.
    public class Enemy {
        public string enemyName;
        public int enemyStrength { get; set;}
        public int enemyIntel { get; set;}
        public int enemyDex { get; set;}
        public int enemyHealth { get; set;}
        public int damageDone { get; set;}

        
        // Given a default value of 3 for strength, intelligence, and dexterity. Health should have a default of 100.
        public Enemy(string name) 
        {
            enemyName = name;
            enemyStrength = 3;
            enemyIntel = 3;
            enemyDex = 3;
            enemyHealth = 100;
        }

        // Create an additional constructor that accepts 5 parameters, so we can set custom values for every field.
        public Enemy(string name, int strength, int intel, int dex, int health) 
        {
            enemyName = name;
            enemyStrength = strength;
            enemyIntel = intel;
            enemyDex = dex;
            enemyHealth = health;
        }
    }

}