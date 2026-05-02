using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Random randomNumGen = new Random();
            int magicNumber = randomNumGen.Next(1,101);
            //Console.WriteLine($"Debug mode on. Magic number: {magicNumber}"); //For testing
            
            int guess = 0;
            int attempt = 0;
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                attempt ++;

                if (guess > magicNumber)
                {
                    Console.WriteLine("Too high! Guess lower.");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Too low! Guess higher.");
                }
                else
                {
                    if (attempt != 1)
                    {
                        Console.WriteLine($"That's right! You got the magic number in {attempt} tries!");
                    }
                    else
                    {
                        Console.WriteLine("Wow! You got it on your first try!");
                    }
                }
            }
            Console.Write("Do you want to play again? ");
            string again = Console.ReadLine().ToLower();
            if (again != "yes" && again != "y")
            {
                Console.WriteLine("Thanks for playing. Goodbye!");
                break;
            }
        }
        

    }
}