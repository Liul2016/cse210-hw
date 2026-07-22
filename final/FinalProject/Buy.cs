/*
Buy

This class allows the user to create a
shopping list item, and takes the item
name and the store name.
*/

using System;
using System.Runtime.CompilerServices;

public class Buy : Item
{
    // Attributes
    private string _RCL_store;

    // Constructors
    public Buy(string title, DateTime dueDate, bool completed, string store) : base(title, dueDate, completed)
    {
        _RCL_store = store;
    }

    public Buy(string[] info) : base(info) // For loading from a file
    {
        _RCL_store = info[4];
    }

    // Methods
    public override string RCL_Display()
    {
        return $"Buy {base.RCL_GetTitle()} from {_RCL_store} before {base.RCL_GetDueDate()}";
    }

    public override string RCL_Save()
    {
        return $"{GetType()}~~~|||~~~{base.RCL_GetTitle()}~~~|||~~~{base.RCL_GetDueDate().ToString("MM/dd/yyyy HH:mm")}~~~|||~~~{base.RCL_GetCompleted()}~~~|||~~~{_RCL_store}";
    }
}
