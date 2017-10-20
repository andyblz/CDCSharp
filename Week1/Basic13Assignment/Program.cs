using System;
using System.Collections.Generic;

namespace Basic13Assignment
{
    class Program
    {
        // Print numbers from 1-255.
        public static void num1To255() {
            for (int i = 1; i <= 255; i++) {
                Console.WriteLine(i);
            }
        }

        // Print odd numbers from between 1-255.
        public static void odd1To255() {
            for (int i = 1; i <= 255; i++) {
                if (i % 2 == 0) {
                    continue;
                } else {
                    Console.WriteLine(i);
                }
            }
        }

        // Print numbers from 0-255, but also print the sum thus far.
        public static void sum0To255() {
            int sum = 0;
            for (int i = 0; i <= 255; i++) {
                Console.WriteLine(i);
                sum += i;
                Console.WriteLine(sum);
            }
        }

        // Given an array, iterate through and print each value.
        public static void iterateArray(int[] arr) {
            foreach (int val in arr) {
                Console.WriteLine(val);
            }
        }

        // Given an array, print the max number.
        public static void maxNum(int[] arr) {
            int max = arr[0];
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] > max) {
                    max = arr[i];
                } else {
                    continue;
                }
            }
            Console.WriteLine(max);
        }

        // Given an array, print the average of the values in the array.
        public static void avgNum(int[] arr) {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++) {
                sum += arr[i];
            }
            int avg = sum / arr.Length;
            Console.WriteLine(avg);
        }

        // Create an array that contains all the odd numbers between 1-255.
        public static int[] oddNum() {
            List<int> oddList = new List<int>();
            for (int i = 1; i <= 255; i++) {
                if (i % 2 == 0) {
                    continue;
                } else {
                    oddList.Add(i);
                    Console.WriteLine(i);
                }
            }
            return oddList.ToArray();
        }

        // Given an array and a value y, return the number of values that are greate than the value y.
        public static int greaterThanY(int[] arr, int y) {
            int count = 0;
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] > y) {
                    count ++;
                } 
            }
            Console.WriteLine(count);
            return count;
        }

        // Given an array, multiply each value by itself.
        public static int[] squareNum(int[] arr) {
            for (int i = 0; i < arr.Length; i++) {
                arr[i] = arr[i] * arr[i];
                Console.WriteLine(arr[i]);
            }
            return arr;
        }

        // Given an array, replace any negative number with the value of 0.
        public static int[] eliminateNeg(int[] arr) {
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] < 0) {
                    arr[i] = 0;
                }
                Console.WriteLine(arr[i]);
            }
            return arr;
        }

        // Given an array, print the max, min, and average values in the array.
        public static void minMaxAvg(int[] arr) {
            int min = arr[0];
            int max = arr[0];
            int sum = 0;
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] < min) {
                    min = arr[i];
                } else if (arr[i] > max) {
                    max = arr[i];
                }
                sum += arr[i];
            }

            int avg = sum / arr.Length;
            
            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.WriteLine(avg);
        }

        // Given an array, shift each number by one to the front, and add "0" to the end.
        public static int[] shiftArr(int[] arr) {
            for (int i = 0; i < arr.Length - 1; i++) {
                arr[i] = arr[i+1];
                Console.WriteLine(arr[i]);
            }
            arr[arr.Length - 1] = 0;
            return arr;
        }

        // Given an array of numbers, replace any negative number with the string "Dojo".
        public static object[] replaceNeg(object[] arr) {
            for (int i = 0; i < arr.Length; i++) {
                if ((int)arr[i] < 0) {
                    arr[i] = "Dojo";
                }
                Console.WriteLine(arr[i]);
            }
            return arr;
        }
      

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // num1To255();
            // odd1To255();
            // sum0To255();

            // int[] arr = {1,2,3,4,-1};
            // iterateArray(arr);
            // maxNum(arr);
            // avgNum(arr);
            // oddNum();
            // greaterThanY(arr, 2);
            // squareNum(arr);
            // eliminateNeg(arr);
            // minMaxAvg(arr);
            // shiftArr(arr);
            object[] arr = {1,2,3,-4};
            replaceNeg(arr);

        }
    }
}
