/* Program
This is the main program. It calls activity classes
and uses them to guide the user through mindfulness
activities.

Ryan Lee
No sources used throughout any of the classes
*/

using System;
using System.IO.Pipelines;
using System.Net.Cache;

class Program
{
    /* Main function. Calls the menu, takes input, and starts activities.*/
    static void Main(string[] args)
    {
        BreathingActivity RCL_breathing = new BreathingActivity("Breathing", "In this activity, you will breathe in and out to a timer.\nActivity time will take 12 seconds per cycle (4 seconds in, 4 seconds hold and 4 seconds out).\nEntered time will be rounded up if not a multiple of 12.\n");
        ReflectionActivity RCL_reflection = new ReflectionActivity("Reflection", "In this activity, you will be given prompts to reflect on.\n");
        ListingActivity RCL_listing = new ListingActivity("Listing", "In this activity, you will list as many items as you can in a certain time period based on a prompt.\n");
        int RCL_userInput = 0;
        while (RCL_userInput != 4)
        {
            RCL_DisplayMenu();
            RCL_userInput = RCL_GetInt("What activity would you like to do?\n>");

            if (RCL_userInput == 1) /* Breathing activity */
            {
                Utility.Animate("+x", 3, 500);
                Console.Clear();
                RCL_breathing.RCL_SetTime(RCL_GetInt(RCL_breathing.RCL_GetStartMsg()));
                Console.Clear();
                RCL_breathing.RCL_StartActivity();
                Console.Clear();
                Console.WriteLine(RCL_breathing.RCL_GetEndMsg());
                Thread.Sleep(3000);
            }
            else if (RCL_userInput == 2) /* Reflection activity */
            {
                Utility.Animate(".oOo", 4, 200);
                Console.Clear();
                RCL_reflection.RCL_SetTime(RCL_GetInt(RCL_reflection.RCL_GetStartMsg()));
                Console.Clear();
                RCL_reflection.RCL_StartActivity();
                Console.Clear();
                Console.WriteLine(RCL_reflection.RCL_GetEndMsg());
                Thread.Sleep(3000);
            }
            else if (RCL_userInput == 3) /* Listing activity */
            {
                Utility.Animate("<^>v", 3, 300, false);
                Console.Clear();
                RCL_listing.RCL_SetTime(RCL_GetInt(RCL_listing.RCL_GetStartMsg()));
                Console.Clear();
                RCL_listing.RCL_StartActivity();
                Console.Clear();
                Console.WriteLine(RCL_listing.RCL_GetEndMsg());
                Thread.Sleep(3000);
            }
        }
        Console.Clear();
    }

    /* Displays the menu */
    static void RCL_DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu:\n  1. Breathing Activity\n  2. Reflection Activity\n  3. Listing Activity\n  4. Quit\n");
    }

    /* Gets and validates user input */
    static int RCL_GetInt(string str)
    {
        Console.Write(str);
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
                Console.Write("Invalid input. Try again.\n>");
            }
        }
        return number;
    }
}