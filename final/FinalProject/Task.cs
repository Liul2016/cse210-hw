/*
Task

This class is for the most basic item;
a task to be done by a time.
*/

using System;

public class Task : Item
{
    // Constructors
    public Task(string title, DateTime dueDate, bool completed) : base(title, dueDate, completed) {}
    public Task(string[] info) : base(info) {} // For loading from a file

    // Methods
    public override string RCL_Display()
    {
        return $"{base.RCL_GetTitle()} - {base.RCL_GetDueDate()}";
    }

    public override string RCL_Save()
    {
        return $"{GetType()}~~~|||~~~{base.RCL_GetTitle()}~~~|||~~~{base.RCL_GetDueDate().ToString("MM/dd/yyyy HH:mm")}~~~|||~~~{base.RCL_GetCompleted()}";
    }
}
