using System;

public class Assignment : Item
{
    // Attributes
    private string _RCL_class;
    private string _RCL_points;

    // Constructor
    public Assignment(string title, DateTime dueDate, bool completed, string className, string points) : base(title, dueDate, completed)
    {
        _RCL_class = className;
        _RCL_points = points;
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
