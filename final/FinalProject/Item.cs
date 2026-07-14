/*
Items
*/
using System;

public abstract class Item
{
    // Attributes
    private string _RCL_title;
    private DateTime _RCL_dueDate;
    private bool _RCL_completed;

    // Constructor
    public Item(string title, DateTime dueDate, bool completed)
    {
        _RCL_title = title;
        _RCL_dueDate = dueDate;
        _RCL_completed = completed;
    }

    // Abstract Methods
    public abstract string RCL_Display();
    public abstract string RCL_Save();

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