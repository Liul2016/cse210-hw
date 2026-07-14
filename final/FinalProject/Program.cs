using System;

class Program
{
    static void Main(string[] args)
    {
        Schedule RCL_items = new Schedule();
        int userInput = 0;
        while (userInput != 7)
        {
            Console.Clear();
            Utility.RCL_DisplayMenu();
            userInput = Utility.RCL_GetInt("> ");

            if (userInput == 1)
            {
                RCL_items.RCL_AddItem();
            }
            else if (userInput == 2)
            {
                RCL_items.RCL_RemoveItem();
            }
            else if (userInput == 3)
            {
                RCL_items.RCL_DisplayAll();
            }
            else if (userInput == 4)
            {
                RCL_items.RCL_DisplayRange();
            }
            else if (userInput == 5)
            {
                RCL_items.RCL_Save();
            }
            else if (userInput == 6)
            {
                RCL_items.RCL_Load();
            }
        }
        Console.Clear();
    }
}