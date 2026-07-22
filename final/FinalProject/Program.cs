/*
Ryan Lee
Program

This is the main program. It is a scheduling tool
that allows users to create, delete, view, save,
load, and mark as complete assignments, events,
shopping list items, and tasks. The program can
display a dashboard that will immediately inform
the user of what is upcoming and what is overdue.

I used the following site to learn more about DateTime for this project.
https://learn.microsoft.com/en-us/dotnet/api/system.datetime?view=net-10.0
*/

using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        // Set up variables
        Schedule RCL_items = new Schedule();
        int userInput = 0;

        // Main loop
        while (userInput != 9)
        {
            RCL_items.RCL_SortItems();
            // Show menu and get user input
            Utility.RCL_DisplayMenu();
            userInput = Utility.RCL_GetIntInRange(">", 1, 9);
            Console.Clear();

            // Do the following based on user's choice
            if (userInput == 1) // Add
            {
                RCL_AddItem();
                Utility.RCL_Pause();
            }
            else if (userInput == 2) // Remove
            {
                if (RCL_items.RCL_GetItems().Count == 0) // Check if empty
                {
                    Console.WriteLine("No items found. Try uploading a file or adding items!");
                    Utility.RCL_Pause();
                    continue;
                }

                RCL_items.RCL_DisplayAll();
                Console.WriteLine();
                int number = Utility.RCL_GetIntInRange("Please select an item to remove.\n>", 1, RCL_items.RCL_GetItems().Count);

                RCL_items.RCL_RemoveItem(number - 1);
                Console.WriteLine($"\nNumber {number} removed successfully!");
                Utility.RCL_Pause();
            }
            else if (userInput == 3) // Display all items
            {
                RCL_items.RCL_DisplayAll();
                Console.WriteLine();
                Utility.RCL_Pause();
            }
            else if (userInput == 4) // Display items in a range
            {
                DateTime start = Utility.RCL_GetDateTime("Range Start:");
                Console.WriteLine();
                DateTime end = Utility.RCL_GetDateTime("Range End:");
                Console.Clear();

                RCL_items.RCL_DisplayRange(start, end);
                Console.WriteLine();
                Utility.RCL_Pause();
            }
            else if (userInput == 5) // Save schedule to a file
            {
                string filename = Utility.RCL_GetString("Filename (without file extension): ") + ".txt";
                RCL_items.RCL_Save(filename);

                Console.WriteLine($"File successfully saved to {filename}!\n");
                Utility.RCL_Pause();
            }
            else if (userInput == 6) // Load schedule from a file
            {
                string filename = Utility.RCL_GetString("Filename (without file extension): ") + ".txt";

                if (File.Exists(filename))
                {
                    RCL_items.RCL_Load(filename);
                    Console.WriteLine($"\nFile {filename} successfully loaded!");
                    Utility.RCL_Pause();
                    Utility.RCL_DisplayDash(RCL_items); // Display dashboard after loading file
                }
                else
                {
                    Console.WriteLine($"\nNo file called {filename} found.");
                    Utility.RCL_Pause();
                }
            }
            else if (userInput == 7) // Mark an item as complete
            {
                if (RCL_items.RCL_GetItems().Count == 0) // Check if empty
                {
                    Console.WriteLine("No items found. Try uploading a file or adding items!");
                    Utility.RCL_Pause();
                    continue;
                }

                RCL_items.RCL_DisplayAll();
                int number = Utility.RCL_GetIntInRange("Please select an item to complete.\n\n>", 1, RCL_items.RCL_GetItems().Count);
                
                if (RCL_items.RCL_GetItems()[number - 1].RCL_GetCompleted())
                {
                    Console.WriteLine($"\nNumber {number} already complete!");
                }
                else
                {
                    RCL_items.RCL_GetItems()[number - 1].RCL_SetCompleted(true);
                    Console.WriteLine($"\nNumber {number} completed successfully!");
                }
                Utility.RCL_Pause();
            }
            else if (userInput == 8) // Display dashboard
            {
                Utility.RCL_DisplayDash(RCL_items);
            }
        }
        Console.Clear();



        void RCL_AddItem() // Function used to add item to items
        {
            Utility.RCL_Display_Types();
            int number = Utility.RCL_GetIntInRange(">", 1, 4);
            Console.Clear();
            string title;

            if (number == 1) // Assignment
            {
                title = Utility.RCL_GetString("Assignment name: ");
                string tmhert = Utility.RCL_GetString("Class: ");
                DateTime dueDate = Utility.RCL_GetDateTime("\nDue Date:");
                int points = Utility.RCL_GetInt("\nPossible Points: ");

                RCL_items.RCL_AddItem(new Assignment(title, dueDate, false, tmhert, points));
            }
            else if (number == 2) // Event
            {
                title = Utility.RCL_GetString("Event name: ");
                Console.WriteLine();
                DateTime startTime = Utility.RCL_GetDateTime("Start Time:");
                Console.WriteLine();
                DateTime endTime = Utility.RCL_GetDateTime("End Time:");

                RCL_items.RCL_AddItem(new Event(title, startTime, false, endTime));
            }
            else if (number == 3) // Buy
            {
                title = Utility.RCL_GetString("Item to buy: ");
                DateTime dueDate = Utility.RCL_GetDateTime("\nDue Date:");
                string store = Utility.RCL_GetString("\nStore: ");

                RCL_items.RCL_AddItem(new Buy(title, dueDate, false, store));
            }
            else if (number == 4) // Task
            {
                title = Utility.RCL_GetString("Task: ");
                DateTime dueDate = Utility.RCL_GetDateTime("\nDue Date:");

                RCL_items.RCL_AddItem(new Task(title, dueDate, false));
            }
            else
            {
                return;
            }

            Console.WriteLine($"\nSuccessfully added {title}!");
        }
    }
}