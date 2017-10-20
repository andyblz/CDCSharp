using System;
using System.Collections.Generic;

namespace Animalistic
{
    public class Husky : Canine
    {
        public Husky(string canineName) : base(canineName)
            {
                strength = 15;
                stamina = 50;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Welcome, {0}! You're a Husky.", name);
                Console.ResetColor();

                var arrHusky = new[]
                {
                    @"            ,",
                    @"            |`-.__",
                    @"            / ' _/",
                    @"           ****` ",
                    @"          /    }",
                    @"         /  \ /",
                    @"     \ /`   \\\",
                    @"jgs   `\    /_\\",
                    @"       `~~~~~``~`",
                };

                foreach (string line in arrHusky)
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