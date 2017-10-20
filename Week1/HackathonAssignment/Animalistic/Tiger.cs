using System;
using System.Collections.Generic;

namespace Animalistic
{
    public class Tiger : Feline
    {
        public Tiger(string felineName) : base(felineName)
            {
                strength = 20;
                stamina = 40;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Welcome, {0}! You're a Tiger.", name);
                Console.ResetColor();

                var arrTiger = new[]
                {
                    @"                   __,,,,_",
                    @"    _ __..-;''`--/'/ /.',-`-.",
                    @"(`/' ` |  \ \ \\ / / / / .-'/`,_",
                    @"/'`\ \   |  \ | \| // // / -.,/_,'-,",
                    @"/<7' ;  \ \  | ; ||/ /| | \/    |`-/,/-.,_,/')",
                    @"/  _.-, `,-\,__|  _-| / \ \/|_/  |    '-/.;.\'",
                    @"`-`  f/ ;      / __/ \__ `/ |__/ |",
                    @"     `-'      |  -| =|\_  \  |-' |",
                    @"           __/   /_..-' `  ),'  //",
                    @"       fL ((__.-'((___..-'' \__.'",
                };

                foreach (string line in arrTiger)
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