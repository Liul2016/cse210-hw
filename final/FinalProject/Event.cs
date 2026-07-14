using System;

public class Event : Item
{
    // Attributes
    private DateTime _RCL_endTime;

    // Constructor
    public Event(string title, DateTime dueDate, bool completed, DateTime endTime) : base(title, dueDate, completed)
    {
        _RCL_endTime = endTime;
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

    public DateTime RCL_GetEndTime()
    {
        return _RCL_endTime;
    }
}
