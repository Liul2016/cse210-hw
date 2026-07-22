/*
Schedule

This class holds all the methods for the
functionality of the items. It stores a
list of items in the schedule object, and
lets you display, add, remove, and more.
*/

using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

public class Schedule
{
    // Attributes
    private List<Item> _RCL_items;

    // Constructor
    public Schedule()
    {
        _RCL_items = new List<Item>();
    }

    // Methods
    public void RCL_AddItem(Item item) // Adds an item to the list
    {
        _RCL_items.Add(item);
    }

    public void RCL_RemoveItem(int index) // Removes an item from the list
    {
        _RCL_items.RemoveAt(index);
    }

    public void RCL_DisplayAll() // Displays all items in the list
    {
        int i = 0;
        foreach (Item item in _RCL_items)
        {
            i++;
            if (item.RCL_GetCompleted())
            {
                Console.WriteLine($"{i}. [X] {item.RCL_Display()}"); // Completed
            }
            else
            {
                Console.WriteLine($"{i}. [ ] {item.RCL_Display()}"); // Not completed
            }
        }
    }

    public void RCL_DisplayRange(DateTime start, DateTime end) // Displays all items in a given range
    {
        int i = 0;
        foreach (Item item in _RCL_items)
        {
            if (item.RCL_GetDueDate() >= start && item.RCL_GetDueDate() <= end)
            {
                i ++;
                if (item.RCL_GetCompleted())
                {
                    Console.WriteLine($"{i}. [X] {item.RCL_Display()}"); // Completed
                }
                else
                {
                    Console.WriteLine($"{i}. [ ] {item.RCL_Display()}"); // Not completed
                }
            }
        }
    }

    public void RCL_Save(string filename) // Saves items to a file
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Item item in _RCL_items)
            {
                outputFile.WriteLine(item.RCL_Save());
            }
        }
    }

    public void RCL_Load(string filename) // Loads items from a file
    {
        string[] lines = System.IO.File.ReadAllLines(filename);
        _RCL_items = new List<Item>();

        foreach (string line in lines)
        {
            string[] info = line.Split("~~~|||~~~");
            
            Item item;
            if (info[0] == "Assignment")
            {
                item = new Assignment(info);
            }
            else if (info[0] == "Event")
            {
                item = new Event(info);
            }
            else if (info[0] == "Buy")
            {
                item = new Buy(info);
            }
            else
            {
                item = new Task(info);
            }
            _RCL_items.Add(item);
        }
    }

    public void RCL_Complete(int index) // Marks an item as complete
    {
        _RCL_items[index].RCL_SetCompleted(true);
    }

    public void RCL_SortItems() // Sorts the list
    {
        RCL_CheckEvents();
        _RCL_items = _RCL_items.OrderBy(item => item.RCL_GetCompleted()).ThenBy(item => item.RCL_GetDueDate()).ToList();
    }

    public void RCL_CheckEvents() // Marks events as finished if they are passed
    {
        foreach (Event item in _RCL_items.OfType<Event>())
        {
            if (item.RCL_GetDueDate() < DateTime.Now)
            {
                item.RCL_SetCompleted(true);
            }
        }
    }

    // Get List
    public List<Item> RCL_GetItems()
    {
        return _RCL_items;
    }
}
