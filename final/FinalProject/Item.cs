/*
Item

This is an abstract class with children
that make up the different kinds of to-do
list items.
*/
using System;
using System.Globalization;

public abstract class Item
{
    // Attributes
    private string _RCL_title;
    private DateTime _RCL_dueDate;
    private bool _RCL_completed;

    // Constructors
    public Item(string title, DateTime dueDate, bool completed)
    {
        _RCL_title = title;
        _RCL_dueDate = dueDate;
        _RCL_completed = completed;
    }

    public Item(string[] info) // For loading from file
    {
        _RCL_title = info[1];
        _RCL_dueDate = DateTime.ParseExact(info[2], "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
        _RCL_completed = bool.Parse(info[3]);
    }

    // Abstract Methods
    public abstract string RCL_Display(); // Will return string with info on item
    public abstract string RCL_Save(); // Will return string formatted for saving to a file

    // Getters
    public string RCL_GetTitle()
    {
        return _RCL_title;
    }
    public DateTime RCL_GetDueDate()
    {
        return _RCL_dueDate;
    }
    public bool RCL_GetCompleted()
    {
        return _RCL_completed;
    }

    // Setters
    public void RCL_SetCompleted(bool completed)
    {
        _RCL_completed = completed;
    }
}