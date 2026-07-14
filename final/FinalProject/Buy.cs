using System;
using System.Runtime.CompilerServices;

public class Buy : Item
{
    // Attributes
    private string Store;

    // Constructor
    public Buy(string title, DateTime dueDate, bool completed, string store) : base(title, dueDate, completed)
    {
        Store = store;
    }

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
