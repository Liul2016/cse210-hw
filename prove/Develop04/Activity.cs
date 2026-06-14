/* Activity (Parent Class)
This class is used as a parent for other activity classes.
It holds everything that all activities need.
*/

using System.ComponentModel;
using System.Diagnostics.Contracts;

class Activity
{
    private string _RCL_name;
    private string _RCL_discription;
    private int _RCL_time;

    public Activity(string name, string discription)
    {
        _RCL_name = name;
        _RCL_discription = discription;
    }

    public string RCL_GetStartMsg()
    {
        return $"Welcome to {_RCL_name}.\n{_RCL_discription}\nHow long do you want to do this activity? (Enter in seconds)\n";
    }

    public string RCL_GetEndMsg()
    {
        return $"You have completed {_RCL_time} seconds of the {_RCL_name} activity.";
    }

    public void RCL_SetTime(int time)
    {
        _RCL_time = time;
    }

    public int RCL_GetTime()
    {
        return _RCL_time;
    }
}