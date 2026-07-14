using System;

public class Task : Item
{
    // Constructor
    public Task(string title, DateTime dueDate, bool completed) : base(title, dueDate, completed) {}

    // Methods
    public override string RCL_Display()
    {
        return "";
    }

    public override string RCL_Save()
    {
        return "";
    }
}
