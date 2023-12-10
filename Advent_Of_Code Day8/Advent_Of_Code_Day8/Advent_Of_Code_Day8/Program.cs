
using System;
using System.IO;

namespace Advent_of_Code___Day_8
{
    class Program
    {
        //Part One solution

        public static void Main(string[] args)
        {

            // Retrive input	
            string notePth = @"C:\...\Advent of Code\Advent of Code Day8\Advent_Of_Code_Day8\Input\Input.txt";

            //Retrive data from Notepad and store them in variables
            //In order for this code to work input need to be modified to format like this: FJT,XDJ;LQV

            string text = File.ReadAllText(notePth);

            // Split the input into rows

            string[] rows = File.ReadAllLines(notePth);

            // start and finish values
            string start = "AAA";
            string finish = "ZZZ";
            string placeholder = "";
            string direction = "";
            string currentline = "";
            string lineStart = "";

            // Direction instructions
            string leftRight = "LRRRLRRLRRLRLRRLRRRLLRRLLRRLRRRLRLRRLLRRLRRLRLRRRLRRRLRLRLRLRRRLRRLRRRLRLRRLLLRLRLLRLRRRLRLRRRLRRRLLLRRLRLRRLRRRLLRRLRRLRRLRRRLRRLRRLRRLRLRRLRLRLRLRLRLRRRLRRLRLLLRRRLRLRRRLRRRLLRRLRRRLRRLRRRLRRRLRLRRRLRRLRLLRRLLRLRRLRLRLLRRLLRRLLRRLRRLRRRLRLRRLRLRRRLRRRLLRLRRLLLLRRRLLRLLLRRLRRRLRRRLRRRLRLRRRLRRRLRRRLRLRRRR";
            int x = 0;
            int y = 0;


            for (int i = 0; i < rows.Length; i++)
            {
                //string direction = leftRight.Substring(i,i+1);

                direction = "";

                currentline = rows[i];

                lineStart = currentline.Substring(0, 3);

                if (lineStart == start)
                {
                    if (x < leftRight.Length)
                    {

                        direction = leftRight.Substring(x, 1);

                        x = x + 1;

                        if (direction == "R")
                        {
                            placeholder = currentline.Substring(11 - 3, 3);
                        }
                        if (direction == "L")
                        {
                            placeholder = currentline.Substring(4, 3);
                        }
                    }

                    if (lineStart == start)
                    {
                        break;
                    }
                }
            }

            y = y + 1;

            for (int j = 0; j < rows.Length; j++)
            {
                direction = "";
                currentline = rows[j];
                lineStart = currentline.Substring(0, 3);

                if (lineStart == placeholder)
                {
                    if (x < leftRight.Length)
                    {

                        direction = leftRight.Substring(x, 1);

                        x = x + 1;

                        if (direction == "R")
                        {
                            placeholder = currentline.Substring(11 - 3, 3);

                            y = y + 1;
                            j = -1;
                        }
                        if (direction == "L")
                        {
                            placeholder = currentline.Substring(4, 3);

                            y = y + 1;
                            j = -1;
                        }
                    }

                }
                if (x == leftRight.Length)
                {

                    x = 0;
                }


                if (placeholder == finish)
                {
                    break;
                }

            }

            Console.WriteLine(y);
        }	

    }
}

