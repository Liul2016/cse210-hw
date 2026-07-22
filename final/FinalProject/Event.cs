/*
Event

This class is for making events with a start
date and time and an end date and time.

Note: Events are automatically marked as complete
when the current time passes the start time. Events
can still be manually marked as complete though, in
case they are completed early for some reason.
*/

using System;
using System.Globalization;

public class Event : Item
{
    // Attributes
    private DateTime _RCL_endTime;

    // Constructors
    public Event(string title, DateTime dueDate, bool completed, DateTime endTime) : base(title, dueDate, completed)
    {
        _RCL_endTime = endTime;
    }

    public Event(string[] info) : base(info) // For loading from a file
    {
        _RCL_endTime = DateTime.ParseExact(info[4], "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
    }

    // Methods
    public override string RCL_Display()
    {
        return $"Event: {base.RCL_GetTitle()} - {base.RCL_GetDueDate()} to {_RCL_endTime}";
    }

    public override string RCL_Save()
    {
        return $"{GetType()}~~~|||~~~{base.RCL_GetTitle()}~~~|||~~~{base.RCL_GetDueDate().ToString("MM/dd/yyyy HH:mm")}~~~|||~~~{base.RCL_GetCompleted()}~~~|||~~~{_RCL_endTime.ToString("MM/dd/yyyy HH:mm")}";
    }

    public DateTime RCL_GetEndTime()
    {
        return _RCL_endTime;
    }
}
