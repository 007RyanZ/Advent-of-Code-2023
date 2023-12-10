
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Advent_of_Code___Day_4
{
    class Program
    {
        // Part 1

        public static void Main(string[] args)
        {

            // Retrive input

            string notePth = @"C:\...\Advent of Code - Day 4\Input.txt";

            //Retrive data from Notepad and store them in variables

            string text = File.ReadAllText(notePth);
            string[] list = text.Split('\n');

            char[] delimiterChars = { '|', ':' };

            int sum = 0;

            for (int i = 0; i < list.Length - 1; i++)

            {
                string[] splitResult = list[i].Split(delimiterChars);

                //Indices of the lines you want to merge
                int lineIndex1 = 1;
                int lineIndex2 = 2;

                //Merge the lines
                string mergedLine = splitResult[lineIndex1].Trim() + " " + splitResult[lineIndex2].Trim();


                // Split the merged line into individual numbers
                string[] numbers = mergedLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                // Convert the numbers to integers
                List<int> intList = numbers.Select(int.Parse).ToList();

                // Find duplicates
                int duplicateCount = intList.GroupBy(x => x)
                           .Count(group => group.Count() > 1);

                int points = (int)Math.Pow(2, duplicateCount - 1);

                sum += points;

            }

            Console.WriteLine(sum);

        }
    }
}