using System;

namespace FundamentalsIAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is for Fundamentals I assignment.");

            // INFO: Loop that prints values from 1-255.
            for (var i = 1; i <= 255; i++) {
                Console.WriteLine(i);
            }

            // INFO: Loop that prints values from 1-100 that are divisible by 3 or 5, but not both.
            for (var i = 1; i <= 100; i++) {
                if (i % 3 == 0 && i % 5 == 0) {
                    continue;
                } else if (i % 3 == 0) {
                    Console.WriteLine(i);
                } else if (i % 5 == 0) {
                    Console.WriteLine(i);
                } else {
                    continue;
                }
            }

            // INFO: Modify previous loop to print "Fizz" for multiples of 3, "Buzz" for multiples of 5, and "FizzBuzz" for multiples of 3 and 5.
            for (var i = 1; i <= 100; i++) {
                if (i % 3 == 0 && i % 5 == 0) {
                    Console.WriteLine("FizzBuzz");
                } else if (i % 3 == 0) {
                    Console.WriteLine("Fizz");
                } else if (i % 5 == 0) {
                    Console.WriteLine("Buzz");
                } else {
                    continue;
                }
            }

            // INFO: Redo loop without using modulus.

            // INFO: Generate 10 random values and output the respective word, in relation to step 3, for the generated values.
            Random rand = new Random();
            for (var i = 1; i <= 10; i++) {
                if (rand.Next(1, 100) % 3 == 0 && rand.Next(1, 100) % 5 == 0) {
                    Console.WriteLine("FizzBuzz");
                } else if (rand.Next(1, 100) % 3 == 0) {
                    Console.WriteLine("Fizz");
                } else if (rand.Next(1, 100) % 5 == 0) {
                    Console.WriteLine("Buzz");
                } else {
                    continue;
                }
            }
        }
    }
}
