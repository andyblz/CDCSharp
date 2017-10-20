using System;
using System.Collections.Generic;

namespace Animalistic
{
    public class Hyena : Canine
    {
        public Hyena(string canineName) : base(canineName)
            {
                strength = 15;
                stamina = 30;
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Welcome, {0}! You're a Hyena.", name);
                Console.ResetColor();

                var arrHyena = new[]
                {
                    @"          hehahaheheh...",
                    @"                /      ",
                    @"                 _,     _,",
                    @"                /)|    /)\",
                    @"                \_'-**/(_\`*..",
                    @"                 /   <        ``--._",
                    @"                 |. _ )     `    *  ',",
                    @"                  ^  ^/_,     *     (\*\", 
                    @"                  (#_/  `\)  /'  * - ))_|",
                    @"                    U      \  \*   _,//_ *",
                    @"                            ) >\_* ((|\_/",
                    @"                            \ | \  | # (",
                    @"                             \#  \#\ \ #",
                    @"                              \\  \(  )/",
                    @"                              _)> _))/(_",
                    @"              b'ger .-\\,, , /\\//\//\\/),, ,,)/",
                    @"                      ,\.        .-    -'-,)\/.'))"
                };

                foreach (string line in arrHyena)
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