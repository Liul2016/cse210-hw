using System;
using System.Globalization;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int favNum = PromptUserNumber();
        PromptUserBirthYear(out int year);
        int sqrNum = SquareNumber(favNum);
        DisplayResult(name, sqrNum, year);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static void PromptUserBirthYear(out int year)
    {
        Console.Write("Please enter the year you were born: ");
        year = int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int num)
    {
        return num * num;
    }

    static void DisplayResult(string name, int sqrNum, int year)
    {
        Console.WriteLine($"{name}, the square of your number is {sqrNum}.");
        Console.WriteLine($"{name}, you will turn {2026 - year} this year.");
    }
}