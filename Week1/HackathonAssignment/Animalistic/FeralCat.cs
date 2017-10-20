using System;
using System.Collections.Generic;

namespace Animalistic
{
    public class FeralCat : Feline
    {
        public FeralCat(string felineName) : base(felineName)
            {
                strength = 10;
                stamina = 20;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Welcome, {0}! You're a Feral Cat.", name);
                Console.ResetColor();

                var arrFeralCat = new[]
                {
                     @" ,_     _",
                     @" |\\_,-~/",
                     @" / _  _ |    ,--.",
                     @"(  @  @ )   / ,-'",
                     @"\  _T_ /-._( (",
                     @"/         `.  \",
                     @"|         _  \ |",
                     @" \ \ ,  /      |",
                     @"  || |-_\__   /",
                     @" ((_/`(____,-'",
                };

                foreach (string line in arrFeralCat)
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