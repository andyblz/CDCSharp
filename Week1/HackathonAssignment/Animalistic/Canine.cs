using System;
using System.Collections.Generic;

namespace Animalistic
{
    public class Canine
    {
        // Canine default properties.
        public string name { get; set; }
        public int health { get; set; }
        public int strength { get; set; }
        public int stamina { get; set; }


        public Canine(string canineName)
        {
            name = canineName;
            health = 100;
        }

        public void Bite(object target)
        {
            Feline victim = target as Feline;
            if (victim != null)
            {
                if (stamina > 0)
                {
                    victim.health -= 20;
                    victim.strength -= 3;
                    stamina -= 1;
                }
                else
                {
                    Console.WriteLine("Not enough stamina to fight.");
                }

                if (victim.health < 0 || victim.health == 0)
                {
                    Console.WriteLine("{0} WINS!", name);
                    Controller.GameOver();
                }

                if (victim.strength < 0)
                {
                    victim.strength = 0;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} bit {1}, causing {1} to lose 20 health, and 2 strength! {0} loses 1 stamina for fighting.", name, victim.name);
                Console.ResetColor();
            }

        }

        public void Dodge()
        {
            if (stamina > 0)
            {
                stamina -= 10;
            }
            else
            {
                Console.WriteLine("Not enough stamina to dodge.");
            }

            if (stamina < 0)
            {
                stamina = 0;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0} dodged the attack, and lost 10 stamina.", name);
            Console.ResetColor();
        
        }

        public void Rest()
        {
            health += 10;
            stamina += 5;
            
            if (health > 100)
            {
                health = 100;
            }

            if (stamina > 50)
            {
                stamina = 50;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0} rested, and gained 5 stamina and 10 health!", name);
            Console.ResetColor();
        }

        public void ShowStats()
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("{0}'S CURRENT STATS:", name);
            Console.ResetColor();
            Console.WriteLine("Health: {0}.", health);
            Console.WriteLine("Strength: {0}.", strength);
            Console.WriteLine("Stamina: {0}.", stamina);
        }

        public void ShowEnemyStats(object target)
        {
            Feline victim = target as Feline;
            if (victim != null)
            {
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("{0}'S CURRENT STATS:", victim.name);
                Console.ResetColor();
                Console.WriteLine("Health: {0}.", victim.health);
                Console.WriteLine("Strength: {0}.", victim.strength);
                Console.WriteLine("Stamina: {0}.", victim.stamina);
            }
        }
    }
}