using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> list = new List<int>();

        int total = 0;

        while (true)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());

            if (number != 0)
            {
                list.Add(number);
                total += number;
            }
            else
            {
                break;
            }
        }
        list.Sort();
        Console.WriteLine($"The sum is: {total}");
        Console.WriteLine($"The average is: {(float)total / list.Count}");
        Console.WriteLine($"The largest number is: {list[list.Count - 1]}");
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] > 0)
            {
                Console.WriteLine($"The smallest positive number is: {list[i]}");
                break;
            }
        }
        Console.WriteLine("The sorted list is:");
        foreach (int num in list)
        {
            Console.WriteLine(num);
        }
    }
}