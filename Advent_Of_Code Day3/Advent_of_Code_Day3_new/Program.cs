using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    // First Part

    static void Main()
    {
        //Retrive input

        string filePath = @"C:\...\Advent of Code\Advent of Code Day3\Advent_of_Code_Day3\Input\Input.txt";

        //Retrive data from Notepad and store them in variables

        char[][] schematic = ReadSchematicFromFile(filePath);

        int result = Part1(schematic);
        Console.WriteLine("Result: " + result);
    }

    static char[][] ReadSchematicFromFile(string filePath)
    {
        List<char[]> lines = new List<char[]>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                lines.Add(line.ToCharArray());
            }
        }

        return lines.ToArray();
    }

    static bool IsValidSymbol(char symbol)
    {
        return !(char.IsDigit(symbol) || symbol == '.' || symbol == '\n');
    }

    static bool IsValidPosition(int row, int col, int maxRow, int maxCol)
    {
        return 0 <= row && row < maxRow && 0 <= col && col < maxCol;
    }

    static bool IsValidPartNumber(char[][] schematic, int row, int partNumberStart, int partNumberEnd)
    {
        for (int col = partNumberStart; col < partNumberEnd; col++)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (IsValidPosition(row + i, col + j, schematic.Length, schematic[0].Length))
                    {
                        if (IsValidSymbol(schematic[row + i][col + j]))
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    static int Part1(char[][] schematic)
    {
        int partNumberSum = 0;

        for (int row = 0; row < schematic.Length; row++)
        {
            var matches = Regex.Matches(new string(schematic[row]), @"\d+");

            foreach (Match match in matches)
            {
                string partNumber = match.Value;
                int partNumberStart = match.Index;
                int partNumberEnd = match.Index + match.Length;

                if (IsValidPartNumber(schematic, row, partNumberStart, partNumberEnd))
                {
                    partNumberSum += int.Parse(partNumber);
                }
            }
        }

        return partNumberSum;
    }

    static bool IsAdjacent(int partNumberStart, int partNumberEnd, int gearCol)
    {
        return partNumberStart - 1 <= gearCol && gearCol <= partNumberEnd;
    }
}