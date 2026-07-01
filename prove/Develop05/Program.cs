/*
Ryan Lee
June 26, 2026

The main program found here handles the menu and user input.
It creates quest objects and uses their methods to gamify
the goal setting process.

To exceed requirements I have made slight improvements to 
the UI including clearing the console for a more finished
feel as well as sorting the quest list to put all completed
quests at the end. I've also added animations for saving
and loading files.

Used w3schools to learn about .Substring()
Used https://bytehide.com/blog/sorting-lists-csharp to learn about lambda sorting
*/

using System;
using System.IO.Enumeration;
using System.Reflection.Metadata;
using Microsoft.VisualBasic;

class Program
{
    static List<Quest> RCL_quests = new List<Quest>();
    static int RCL_totalPoints = 0;
    static void Main(string[] args)
    {
        int RCL_user_input = 0;
        while (RCL_user_input != 6)
        {
            RCL_DisplayMenu();
            RCL_user_input = RCL_GetInt(">");

            /* 1. Create goal */
            if (RCL_user_input == 1)
            {
                RCL_CreateGoal();
            }
            /* 2. List goals */
            else if (RCL_user_input == 2)
            {
                Console.Clear();
                RCL_ListGoals();
                Console.Write("\nPress any key to continue...");
                Console.ReadKey();
            }
            /* 3. Save goals */
            else if (RCL_user_input == 3)
            {
                Console.Clear();
                string filename = RCL_GetString("Filename (without extension): ");
                RCL_WriteGoals(filename);
                RCL_Load("\nSaving goals");
                Console.WriteLine($"\n\nGoals saved to {filename}.txt! Press any key to continue...");
                Console.ReadKey();
            }
            /* 4. Load goals */
            else if (RCL_user_input == 4)
            {
                Console.Clear();
                string filename = RCL_GetString("Filename (without extension): ");
                RCL_quests = RCL_ReadGoals(filename);
                RCL_Load("\nLoading goals");
                Console.WriteLine($"\n\nGoals loaded from {filename}.txt! Press any key to continue...");
                Console.ReadKey();
            }
            /* 5. Record event */
            else if (RCL_user_input == 5)
            {
                Console.Clear();
                RCL_ListGoals();
                int index = RCL_GetInt("\nSelect goal: ");
                Console.Clear();

                if (RCL_quests[index - 1].RCL_GetCompleted()) // Display message if goal is already completed
                {
                    Console.WriteLine($"Quest {index} has already been completed.");
                }
                else // Otherwise award points
                {
                    int points = RCL_quests[index - 1].RCL_CompleteQuest();
                    RCL_totalPoints += points;
                    Console.WriteLine($"Good job on that quest! You earned {points} points!");
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
        Console.Clear();
    }

    static void RCL_DisplayMenu() // Display the menu
    {
        Console.Clear();
        Console.WriteLine($"You have {RCL_totalPoints} points\n");
        Console.WriteLine("1. Create goal\n2. List goals\n3. Save goals\n4. Load goals\n5. Record event\n6. Quit\n\nPlease choose an option (1-6)");
    }

    static int RCL_GetInt(string str) // Print a string and return input only if it's an int
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
                Console.Write("\nInvalid input. Try again.\n>");
            }
        }
        return number;
    }

static string RCL_GetString(string str) // Print a string and return input
    {
        Console.Write(str);
        return Console.ReadLine();
    }

    static void RCL_CreateGoal() // Create a goal by asking for info
    {
        Console.Clear();
        Console.WriteLine("Which kind of goal would you like to create?\n1. Simple\n2. Eternal\n3. Checklist\n");
        int RCL_user_input = RCL_GetInt(">");
        Console.Clear();

        string name = RCL_GetString("Name: ");
        string description = RCL_GetString("Short description: ");
        int reward = RCL_GetInt("Reward amount: ");

        if (RCL_user_input == 1)
        {
            RCL_quests.Add(new Simple(name, description, false, reward));
        }
        else if (RCL_user_input == 2)
        {
            RCL_quests.Add(new Eternal(name, description, false, reward));
        }
        else if (RCL_user_input == 3) // Extra info needed for these goals
        {
            int goal = RCL_GetInt("Times to be completed: ");
            int bonus = RCL_GetInt("Bonus: ");
            RCL_quests.Add(new Checklist(name, description, false, reward, goal, bonus, 0));
        }
    }

    static void RCL_ListGoals() // List out all goals
    {
        RCL_quests.Sort((a, b) => a.RCL_GetCompleted().CompareTo(b.RCL_GetCompleted())); // Sort based on completion
        for (int i = 0; i < RCL_quests.Count(); i++)
        {
            if (RCL_quests[i].RCL_GetCompleted()) // Fill with an X if completed
            {
                Console.WriteLine($"{i + 1}. [X] {RCL_quests[i]}");
            }
            else
            {
                Console.WriteLine($"{i + 1}. [ ] {RCL_quests[i]}");
            }
        }
    }

    static void RCL_WriteGoals(string filename) // Write goals to a file
    {
        using (StreamWriter file = new StreamWriter($"{filename}.txt"))
        {
            file.WriteLine($"+{RCL_totalPoints}");
            foreach (Quest quest in RCL_quests)
            {
                file.WriteLine(quest.RCL_SaveGoals());
            }
        }
    }

    static List<Quest> RCL_ReadGoals(string filename) // Load goals from string filename
    {
        List<Quest> quests = new List<Quest>();
        string[] lines = System.IO.File.ReadAllLines($"{filename}.txt");
        
        foreach (string line in lines)
        {
            if (line[0] == '+') // Check if it's the points line
            {
                RCL_totalPoints = Convert.ToInt32(line.Substring(1)); // Get the line starting from the second char
                continue; // Don't try to get info from the first line
            }
            string[] info = line.Split("|||~~~");
            
            if (info[0] == "Simple") // Create simple quest for lines beginning in "simple" */
            {
                quests.Add(new Simple(info[1], info[2], bool.Parse(info[3]), Convert.ToInt32(info[4])));
            }
            else if (info[0] == "Eternal") // Create eternal quest for lines beginning in "eternal"
            {
                quests.Add(new Eternal(info[1], info[2], bool.Parse(info[3]), Convert.ToInt32(info[4])));
            }
            else if (info[0] == "Checklist") // Create checklist quest for lines beginning in "checklist"
            {
                quests.Add(new Checklist(info[1], info[2], bool.Parse(info[3]), Convert.ToInt32(info[4]), Convert.ToInt32(info[5]), Convert.ToInt32(info[6]), Convert.ToInt32(info[7])));
            }
        }

        return quests;
    }

    static void RCL_Load(string message) // Loading animation
    {
        Console.WriteLine(message);
        for (int i = 0; i < 30; i++)
        {
            Console.Write("x");
            for (int k = 30 - i; k > 0; k--)
            {
                Console.Write("-");
            }
            Thread.Sleep(50);
            for (int k = 30 - i; k > 0; k--)
            {
                Console.Write("\b");
            }
        }
        Console.Write("x");
    }
}