/*
This program helps the user memorize a scripture passage by replacing 3 words
with blanks each time the user continues the program. To exceed the requirments
of the assignment, I have changed the Console.ReadLine() to a ReadKey to allow
the user to continue simply by pressing any key. As the user can no longer type
'quit' to exit the program, they can instead exit by pressing the 'Esc' key. I
also took input from the user to get the scripture passage that they would use.
*/

using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.Write("Refernece: ");
        string reference = Console.ReadLine();

        Console.Write("\nPassage: ");
        string passage = Console.ReadLine();

        Scripture s = new Scripture(reference, passage);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(s);
            Console.WriteLine("\nPress any key to remove words, or press 'Esc' to quit...");
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (s.IsEmpty())
            {
                Console.Clear();
                Console.WriteLine("Great job!\nPress any key to exit...");
                break;
            }
            else if (userInput.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Console.WriteLine("Done already? Okay.\nPress any key to exit...");
                break;
            }
            else
            {
                s.RemoveWords(Math.Min(3, s.GetAmountLeft()));
            }
        }
        Console.ReadKey();
        Console.Clear();
    }
}