using System;
using System.Collections.Generic;

namespace BoxingUnboxingAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Create an empty List of type object.
            List<object> newList = new List<object>();

            // Add the following values to the List: 7, 28, -1, true, "chair".
            newList.Add(7);
            newList.Add(28);
            newList.Add(-1);
            newList.Add(true);
            newList.Add("chair");
            
            // Loop through the list and print all values.
            foreach (object val in newList) {
                Console.WriteLine(val);
            }

            // Add all values that are Int type together and output the sum.
            int sum = 0;

            foreach (object val in newList) {
                if (val is int) {
                    Console.WriteLine(val);
                    sum += (int)val;
                } else {
                    continue;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
