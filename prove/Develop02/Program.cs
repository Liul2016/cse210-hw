using System;
using System.Net.Quic;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Entry entry = new Entry();
        Journal journal = new Journal();

        bool quit = false;
        while (quit != true)
        {
            // Clear the console and display the main menu
            Console.Clear();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            // Get the user's menu choice
            Console.Write("\nWhat would you like to do (1-5)? ");
            string userInput = Console.ReadLine();
            Console.Clear();

            if (userInput == "1") // Write
            {
                Console.Write("1. Custom prompt\n2. Random prompt\n3. No prompt\n\nWhat would you like to do (1-3)? ");
                string promptChoice = Console.ReadLine();
                Console.Clear();

                string prompt = "No prompt";
                if (promptChoice == "1") // Custom prompt
                {
                    Console.Write("Custom prompt: ");
                    prompt = Console.ReadLine();
                }
                else if (promptChoice == "2") // Random prompt
                {
                    prompt = entry.GetRandomPrompt();
                }

                Console.Clear();
                Console.Write($"Prompt: {prompt}\nEntry: ");
                string userEntry = Console.ReadLine();

                string date = DateTime.Now.ToShortDateString();

                journal._entries.Add(entry.GetEntry(date, prompt, userEntry));
            }

            if (userInput == "2") // Display
            {
                journal.DisplayJournal();
                Console.Write("Press enter to continue...");
                Console.ReadKey();
            }

            if (userInput == "3") // Load
            {
                Console.Write("File name (no file extention needed): ");
                string fileName = Console.ReadLine() + ".txt";
                journal._entries = journal.LoadJournal(fileName);

                if (journal._entries.Count() > 0)
                {
                    Console.WriteLine("\nJournal loaded. Press enter to continue...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"\nNo file called {fileName} found, or {fileName} is empty.\n\nPress enter to continue...");
                    Console.ReadKey();
                }
            }

            if (userInput == "4") // Save
            {
                Console.Write("File name (no file extention needed): ");
                string fileName = Console.ReadLine() + ".txt";
                journal.SaveJournal(fileName);
                Console.WriteLine("\nJournal saved. Press enter to continue...");
                Console.ReadKey();
            }

            if (userInput == "5") // Quit
            {
                quit = true;
                Console.WriteLine("Thank you! Goodbye! (Press enter to exit...)");
                Console.Read();
                Console.Clear();
            }
        }
    }
}