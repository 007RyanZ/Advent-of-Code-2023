
using System;
using System.IO;
using System.Collections.Generic;


// The newly-improved calibration document consists of lines of text; each line originally 
//contained a specific calibration value that the Elves now need to recover. On each line, 
//the calibration value can be found by combining the first digit and the last digit (in that order) to form a single two-digit number.

namespace Advent_of_Code___Day_1
{
    class Program
    {
        // Solution Part 2
        public static void Main(string[] args)
        {

            // Retrive input

            string notePth = @"C:\...\Advent of Code - Day 1\Advent of code Day 1 input.txt";

            //Retrive data from Notepad and store them in variables

            string text = File.ReadAllText(notePth);
            string[] list = text.Split('\n');

            // Create a new array to store the results
            string[] resultsArray = new string[list.Length];

            // Variable to keep track of the sum
            int sum = 0;
            //---------------------------------------------------------------------------

            // Loop input list and extract from input firt and last number of the string

            for (int i = 0; i < list.Length; i++)
            {

                //string input = item;
                string input = list[i];
                string result = "";
                string result2 = "";


                //loop from front
                foreach (char c in input)
                {

                    if (result == "")
                    {

                        if (char.IsDigit(c))
                        {
                            result += c;
                            result2 = "";
                        }

                        else if (!char.IsDigit(c))
                        {

                            result2 += c;


                            // Define a dictionary to map words to their numeric values
                            Dictionary<string, string> wordToNumber = new Dictionary<string, string>
                            {
                                {"one", "1"},
                                {"two", "2"},
                                {"three", "3"},
                                {"four", "4"},
                                {"five", "5"},
                                {"six", "6"},
                                {"seven", "7"},
                                {"eight", "8"},
                                {"nine", "9"}
                            };

                            // Check if the current word in result2 is in the dictionary
                            foreach (var kvp in wordToNumber)
                            {

                                if (result2.Contains(kvp.Key))
                                {

                                    result += kvp.Value;

                                }

                            }
                        }

                    }
                }

                result2 = "";

                int strLng = input.Length;
                for (int j = strLng - 1; j >= 0; j--)
                {

                    char currentChar = input[j];

                    if (char.IsDigit(currentChar) && result.Length < 2)
                    {
                        result = result + currentChar;
                    }
                    else if (!char.IsDigit(currentChar) && result.Length < 2)
                    {

                        result2 = currentChar + result2;

                        // Define a dictionary to map words to their numeric values
                        Dictionary<string, string> wordToNumber = new Dictionary<string, string>
                            {
                                {"one", "1"},
                                {"two", "2"},
                                {"three", "3"},
                                {"four", "4"},
                                {"five", "5"},
                                {"six", "6"},
                                {"seven", "7"},
                                {"eight", "8"},
                                {"nine", "9"}
                            };

                        // Check if the current word in result2 is in the dictionary
                        foreach (var kvp in wordToNumber)
                        {

                            if (result2.Contains(kvp.Key))
                            {
                                //Partiali working
                                result += kvp.Value;

                            }

                        }

                    }

                }

                // Store the result in the new array
                resultsArray[i] = result;

                // Convert the result to an integer and add it to the sum
                sum += int.Parse(result);

                Console.WriteLine(result);

            }

            Console.WriteLine("Sum of all entries: {0}", sum);

        }

    }
}