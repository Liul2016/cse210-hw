/*
Assignment

This is a class for school assignments. User
will add possible points, assignment names,
and the class for which the assignment is due.
*/

using System;
using System.Runtime.InteropServices.Swift;

public class Assignment : Item
{
    // Attributes
    private string _RCL_class;
    private int _RCL_points;

    // Constructors
    public Assignment(string title, DateTime dueDate, bool completed, string className, int points) : base(title, dueDate, completed)
    {
        _RCL_class = className;
        _RCL_points = points;
    }

    public Assignment(string[] info) : base(info) // For loading from file
    {
        _RCL_class = info[4];
        _RCL_points = int.Parse(info[5]);
    }

    // Methods
    public override string RCL_Display()
    {
        return $"{_RCL_class}: {base.RCL_GetTitle()} - Due {base.RCL_GetDueDate()} ({_RCL_points} points)";
    }

    public override string RCL_Save()
    {
        return $"{GetType()}~~~|||~~~{base.RCL_GetTitle()}~~~|||~~~{base.RCL_GetDueDate().ToString("MM/dd/yyyy HH:mm")}~~~|||~~~{base.RCL_GetCompleted()}~~~|||~~~{_RCL_class}~~~|||~~~{_RCL_points}";
    }
}
