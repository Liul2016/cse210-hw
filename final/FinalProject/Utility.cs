using System;
using System.Formats.Asn1;

public static class Utility
{
    public static DateTime RCL_GetDateTime()
    {
        return DateTime.Now;
    }

    public static string RCL_GetString()
    {
        return "";
    }

    public static int RCL_GetInt(string prompt)
    {
        Console.Write(prompt);
        int number;
        while(true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out number))
            {
                break;
            }
            else
            {
                Console.Write($"\nInvalid input. Try again.\n{prompt}");
            }
        }
        return number;
    }

    public static void RCL_DisplayMenu()
    {
        Console.WriteLine("What would you like to do?\n1. Add item\n2. Remove item\n3. Display all\n4. Display range\n5. Save\n6. Load\n7. Quit\n");
    }
}
