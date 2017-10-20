using System;
using System.Collections.Generic;

namespace Animalistic
{
    public class Wolf : Canine
    {
        public Wolf(string canineName) : base(canineName)
            {
                strength = 20;
                stamina = 40;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Welcome, {0}! You're a Wolf.", name);
                Console.ResetColor();

                var arrWolf = new[]
                {
                    @"                     .",
                    @"                    / V\",
                    @"                  / `  /",
                    @"                 <<   |",
                    @"                 /    |",
                    @"               /      |",
                    @"             /        |",
                    @"           /    \  \ /",
                    @"          (      ) | |",
                    @"  ________|   _/_  | |",
                    @"<__________\______)\__)",
                };

                foreach (string line in arrWolf)
                    Console.WriteLine(line);

                ShowStats();
            }

        public new void Bite(object target)
        {
            base.Bite(target);
            ShowStats();
            ShowEnemyStats(target);
        }

        public new void Dodge()
        {
            base.Dodge();
            ShowStats();            
        }

        public new void Rest()
        {
            base.Rest();
            ShowStats();            
        }
    }
}