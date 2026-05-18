using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        fraction1.SetTop(2);
        fraction1.SetBottom(3);
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        fraction1.SetBottom(0);
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());

        Fraction fraction2 = new Fraction(2);
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());

        Fraction fraction3 = new Fraction(4, 5);
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());

        Fraction fraction4 = new Fraction(0, 5);
        Console.WriteLine(fraction4.GetFractionString());
        Console.WriteLine(fraction4.GetDecimalValue());


        Random random = new Random();
        Fraction fraction5 = new Fraction();
        for (int i = 0; i < 20; i++)
        {
            fraction5.SetTop(random.Next(11));
            fraction5.SetBottom(random.Next(1, 11));
            Console.WriteLine($"Fraction {i + 1}: String: {fraction5.GetFractionString()} Number: {fraction5.GetDecimalValue()}");
        }
    }
}