using System;
using System.Collections.Generic;

namespace Animalistic
{
    public class Cheetah : Feline
    {
        public Cheetah(string felineName) : base(felineName)
            {
                strength = 15;
                stamina = 50;
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Welcome, {0}! You're a Cheetah.", name);
                Console.ResetColor();

                var arrCheetah = new[]
                {
                    @"                      (`.-,')",
                    @"                    .-'     ;",
                    @"                _.-'   , `,-",
                    @"          _ _.-'     .'  /._",
                    @"        .' `  _.-.  /  ,'._;)",
                    @"       (       .  )-| (",
                    @"        )`,_ ,'_,'  \_;)",
                    @"('_  _,'.'  (___,))",
                    @" `-:;.-'",                  
                };

                foreach (string line in arrCheetah)
                    Console.WriteLine(line);

                ShowStats();
            }

        public new void Bite(object target)
        {
            base.Bite(target);
            ShowStats();
            ShowEnemyStats(target);
        }

        public new void Claw(object target)
        {
            base.Claw(target);
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