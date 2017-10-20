using System;
using System.Collections.Generic;

namespace Animalistic
{
    public class Feline
    {
        // Feline default properties.
        public string name { get; set; }
        public int health { get; set; }
        public int strength { get; set; }
        public int stamina { get; set; }


        public Feline(string felineName)
        {
            name = felineName;
            health = 100;
        }

        public void Bite(object target)
        { 
            Canine victim = target as Canine;
            if (victim != null)
            {
                if (stamina > 0)
                {
                    victim.health -= 15;
                    victim.strength -= 2;
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

                if (stamina < 0)
                {
                    stamina = 0;
                }
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} bit {1}, causing {1} to lose 15 health, and 1 strength! {0} losts 1 stamina for fighting.", name, victim.name);
                Console.ResetColor();
            }

        }

        public void Claw(object target)
        {
            Canine victim = target as Canine;
            if (victim != null)
            {
                if (stamina > 0)
                {
                    victim.health -= 10;
                    victim.strength -= 1;
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
                Console.WriteLine("{0} clawed {1}, causing {1} to lose 5 health, and 1 strength! {0} loses 1 stamina for fighting.", name, victim.name);
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
            stamina += 5;
            health += 10;

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
            Canine victim = target as Canine;
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