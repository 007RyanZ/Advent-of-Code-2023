using System;
using System.Collections.Generic;

// Part 2 - part one was done in excel :)

class Program
{
    public static void Main(string[] args)
    {

        long time = 56717999;
        long distance = 334113513502430;
        long result = 0;
        long finalResult = 0;
        List<long> resultList = new List<long>();

        //vzorec

        for (int i = 1; i <= time; i++)
        {
            // Your code here
            result = (i * 1) * (time - i);

            if (result > distance)
            {
                resultList.Add(result);

            }

        }

        Console.WriteLine(finalResult = resultList.Count);
    }
}