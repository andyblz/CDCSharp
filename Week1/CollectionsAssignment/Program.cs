using System;
using System.Collections.Generic;

namespace CollectionsAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Yo!");
            // INFO: THREE BASIC ARRAYS.
            // An array that holds integer values 0-9.
            int[] numArray = {0,1,2,3,4,5,6,7,8,9};

            foreach (int value in numArray) {
                Console.WriteLine(value);
            }

            // An array that holds string values of "Tim", "Martin", "Nikki", "Sara".
            string[] strArray = {"Tim", "Martin", "Nikki", "Sara"};

            foreach (string value in strArray) {
                Console.WriteLine(value);
            }

            // An array of length 10 that alternates between true and false values, starting with true.
            bool[] boolArray = new bool[10];

            for (var i = 0; i < 10; i += 2) {
                boolArray[i] = true;
            }

            foreach (bool value in boolArray) {
                Console.WriteLine(value);
            }

            // INFO: MULTIPLICATION TABLE.
            // With the values 1-10, use code to generate a multiplication table.
            int[,] multiTable = new int[10,10]; 
            for (int x = 0; x < 10; x++) {
                for (int y = 0; y < 10; y++) {
                    multiTable[x,y] = (x + 1) * (y + 1);
                    Console.Write(string.Format("{0} ", multiTable[x,y]));
                }
                Console.Write(Environment.NewLine);
            }
            Console.ReadLine();

            // INFO: LIST OF FLAVORS.
            // A list of ice-cream flavors that holds at least 5 different flavors.
            List<string> iceCream = new List<string>();

            iceCream.Add("Vanilla");
            iceCream.Add("Strawberry");
            iceCream.Add("Chocolate");
            iceCream.Add("Cookies & Cream");
            iceCream.Add("White Chocolate Raspberry Truffle");

            foreach (string value in iceCream) {
                Console.WriteLine(value);
            }
            

            // Output the length of this list.
            Console.WriteLine(iceCream.Count);

            // Output the third flavor in the list, then remove this value.
            Console.WriteLine(iceCream[2]);
            iceCream.RemoveAt(2);
            foreach (string value in iceCream) {
                Console.WriteLine(value);
            }

            // Output the new length of the list.
            Console.WriteLine(iceCream.Count);

            // INFO: USER INFO DICTIONARY.
            // A dictionary that will store both string keys and values.
            Dictionary<string,string> userInfo = new Dictionary<string,string>();

            // For each name in the array of names, add it as a new key in this dictionary with value "null".
            userInfo.Add("Jennifer", null);
            userInfo.Add("Mia", null);
            userInfo.Add("Ming", null);
            userInfo.Add("Loki", null);

            // For each name key, select a random flavor from the flavor list above and store it as the value.
            Random rand = new Random();

            var keys = new List<string>(userInfo.Keys);

            foreach (string key in keys) {
                userInfo[key] = iceCream[rand.Next(iceCream.Count)];
            }

            // Loop through the dictionary and print out each user's name and their associated ice-cream flavor.
            foreach (KeyValuePair<string,string> val in userInfo) {
                Console.WriteLine(val.Key + " - " + val.Value);
            }
        }
    }
}
