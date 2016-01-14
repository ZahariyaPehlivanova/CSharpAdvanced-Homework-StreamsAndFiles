using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Couples_Frequency
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Write numbers");
            string[] input = Console.ReadLine().Split(' ');
            int[] numbers = new int[input.Length];

            List<string> numbersList = new List<string>();

           

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int count = 0;
                string couple = input[i] + " " + input[i + 1];
                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    string couple2 = input[j] + " " + input[j + 1];
                    if (couple.Equals(couple2))
                    {
                        count++;
                    }
                }

                if(!numbersList.Contains(couple))
                {
                    numbersList.Add(couple);
                    double percent = (((double)count / (double)(numbers.Length - 1)) * 100);
                    Console.WriteLine(couple + " -> " + percent + "%");
                   
                }
            }
        }
    }
}
