/*
Utility

Used by other classes (mainly program) to
complete common actions, such as getting an
int, string, or DateTime, and more.
*/

using System;
using System.Formats.Asn1;
using System.Globalization;

public static class Utility
{
    public static DateTime RCL_GetDateTime(string prompt) // Validates inputs to get a DateTime
    {
        Console.WriteLine(prompt);

        while (true)
        {
            string date = RCL_GetString("Date (mm/dd/yyyy): ");
            string time = RCL_GetString("Time (24-hour hh:mm): ");

            if (DateTime.TryParseExact(
                $"{date} {time}",
                "MM/dd/yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime result))
            {
                return result;
            }

            Console.WriteLine("Invalid date or time. Please try again.\n");
        }
    }

    public static string RCL_GetString(string prompt) // Displays prompt and gets input
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    public static int RCL_GetInt(string prompt) // Validates inputs to get an int
    {
        Console.Write(prompt);
        int number;
        while(true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out number))
            {
                return number;
            }
            else
            {
                Console.Write($"\nInvalid input. Try again.\n{prompt}");
            }
        }
    }

    public static int RCL_GetIntInRange(string prompt, int low, int high) // Validates inputs to get an int between two numbers
    {
        Console.Write(prompt);
        int number;
        while(true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out number) && number >= low && number <= high)
            {
                return number;
            }
            else
            {
                Console.Write($"\nInvalid input. Try again.\n{prompt}");
            }
        }
    }

    public static void RCL_DisplayMenu() // Display the start menu
    {
        Console.Clear();
        Console.WriteLine("What would you like to do?\n1. Add item\n2. Remove item\n3. Display all\n4. Display in range\n5. Save\n6. Load\n7. Complete item\n8. Display Dashboard\n9. Quit\n");
    }

    public static void RCL_Display_Types() // Display the list of item types
    {
        Console.WriteLine("1. Assignment\n2. Event\n3. Shopping\n4. Task\n");
    }

    public static void RCL_Pause() // Pause and wait for next keypress
    {
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }

    public static void RCL_DisplayDash(Schedule schedule) // Display a dashboard with info on most relevant items
    {
        Console.Clear();

        List<Item> items = schedule.RCL_GetItems();

        // Set up lists for items by due date
        List<Item> overdue = new List<Item>();
        List<Item> dueToday = new List<Item>();
        List<Item> dueTomorrow = new List<Item>();

        foreach (Item item in items)
        {
            if (item.RCL_GetCompleted()) // Only show items that are incomplete
            {
                continue;
            }

            if (item.RCL_GetDueDate() < DateTime.Now) // Overdue items
            {
                overdue.Add(item);
            }
            else if (item.RCL_GetDueDate().Date == DateTime.Now.Date) // Due today
            {
                dueToday.Add(item);
            }
            else if (item.RCL_GetDueDate().Date == DateTime.Now.AddDays(1).Date) // Due tomorrow
            {
                dueTomorrow.Add(item);
            }
        }

        // Display dashboard with all info or a nothing to show message
        if (overdue.Count != 0)
        {
            Console.WriteLine($"!! Overdue ({overdue.Count}) !!");
            foreach (Item item in overdue)
            {
                Console.WriteLine(item.RCL_Display());
            }
            Console.WriteLine();
        }
        if (dueToday.Count != 0)
        {
            Console.WriteLine($"Today ({dueToday.Count})");
            foreach (Item item in dueToday)
            {
                Console.WriteLine(item.RCL_Display());
            }
            Console.WriteLine();
        }
        if (dueTomorrow.Count != 0)
        {
            Console.WriteLine($"Tomorrow ({dueTomorrow.Count})");
            foreach (Item item in dueTomorrow)
            {
                Console.WriteLine(item.RCL_Display());
            }
            Console.WriteLine();
        }
        if (overdue.Count == 0 && dueToday.Count == 0 && dueTomorrow.Count == 0)
        {
            Console.WriteLine("Nothing to show! Try adding tasks or loading from a file.\n");
        }

        RCL_Pause();
    }
}