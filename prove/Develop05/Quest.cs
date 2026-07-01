/*
Abstract parent class for all quests
*/


using System.Reflection.Metadata.Ecma335;

public abstract class Quest
{
    private string _RCL_name;
    private string _RCL_description;
    private bool _RCL_completed;
    private int _RCL_reward;

    public Quest(string name, string description, bool completed, int reward)
    {
        _RCL_name = name;
        _RCL_description = description;
        _RCL_completed = completed;
        _RCL_reward = reward;
    }

    /* Getters */
    public string RCL_GetName()
    {
        return _RCL_name;
    }
    public string RCL_GetDescription()
    {
        return _RCL_description;
    }
    public bool RCL_GetCompleted()
    {
        return _RCL_completed;
    }
    public int RCL_GetReward()
    {
        return _RCL_reward;
    }

    /* Setters */
    public void RCL_SetCompleted(bool completed)
    {
        _RCL_completed = completed;
    }

    /* Changeable methods */
    public override string ToString() // Get string for listing goals
    {
        return $"{RCL_GetName()} ({RCL_GetDescription()})";
    }

    public abstract int RCL_CompleteQuest();
    public abstract string RCL_SaveGoals();
}