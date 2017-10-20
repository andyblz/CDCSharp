using System;
using System.Collections.Generic;

namespace PuzzlesAssignment
{
    class Program
    {
        // Create a function called RandomArray() that returns an integer array.
        public static void RandomArray() {
            int[] numArray = new int[10];
            Random rand = new Random();

            for (int i = 0; i < numArray.Length; i++) {
                numArray[i] = rand.Next(5,26);
            }

            int min = numArray[0];
            int max = numArray[0];
            int sum = 0;
            for (int i = 0; i < numArray.Length; i++) {
                if (numArray[i] < min) {
                    min = numArray[i];
                } else if (numArray[i] > max) {
                    max = numArray[i];
                }
                sum += numArray[i];
            }
            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.WriteLine(sum);
        }

        // Create a function called TossCoin() that returns a string.
        public static int TossCoin() {
            Console.WriteLine("Tossing a Coin!");
            Random rand = new Random();
            int result = rand.Next(0,2);
            
            if (result == 0) {
                Console.WriteLine("Heads!");
            } else {
                Console.WriteLine("Tails!");
            }

            return result;
        }

        // Create another function called TossMultipleCoins(int num) that returns a double.
        public static double TossMultipleCoins(int num) {
            int headCount = 0;
            int tailCount = 0;
            for (int i = 0; i < num; i++) {
                int result = TossCoin();
                if (result == 0) {
                    headCount ++;
                } else {
                    tailCount ++;
                }
            }
            if (headCount > tailCount) {
                double ratio = tailCount/headCount;
                Console.WriteLine(ratio);
                return ratio;
            } else {
                double ratio = headCount/tailCount;
                Console.WriteLine(ratio);
                return ratio;
            }
        }

        // Create a function Names() that will return an array of strings.
        public static string[] Names() {
            string[] nameArr = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            Random rand = new Random();

            for (int i = 0; i < nameArr.Length; i++) {
                int index = rand.Next(0, nameArr.Length);
                string temp = nameArr[index];
                nameArr[index] = nameArr[i];
                nameArr[i] = temp;
            }

            foreach (string val in nameArr) {
                Console.WriteLine(val);
            }

            List<string> newArr = new List<string>();

            for (int i = 0; i < nameArr.Length; i++) {
                if (nameArr[i].Length > 5) {
                    newArr.Add(nameArr[i]);
                }
            }

            foreach (string val in newArr) {
                Console.WriteLine(val);
            }

            return newArr.ToArray();
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // RandomArray();
            // TossCoin();
            // TossMultipleCoins(5);
            Names();

        }
    }
}
