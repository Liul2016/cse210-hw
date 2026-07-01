/*
Checklist quest: A quest that needs to be completed a specified amount of times.
Each time completed a reward is given, and a bonus is given if completed for the last time.
*/

public class Checklist : Quest
{
    private int _RCL_goal;
    private int _RCL_bonus;
    private int _RCL_completionCounter;

    public Checklist(string name, string description, bool completed, int reward, int goal, int bonus, int completionCounter) : base(name, description, completed, reward)
    {
        _RCL_goal = goal;
        _RCL_bonus = bonus;
        _RCL_completionCounter = completionCounter;
    }

    public override int RCL_CompleteQuest() // Complete a quest
    {
        _RCL_completionCounter ++;

        if (_RCL_completionCounter == _RCL_goal) // Give bonus if completing for the last time
        {
            base.RCL_SetCompleted(true);
            return base.RCL_GetReward() + _RCL_bonus;
        }
        else
        {
            return base.RCL_GetReward(); // Give standard reward if simply completing another time
        }
    }

    public override string RCL_SaveGoals() // Return a string with all variable to save a quest
    {
        return $"{GetType()}|||~~~{RCL_GetName()}|||~~~{RCL_GetDescription()}|||~~~{RCL_GetCompleted()}|||~~~{RCL_GetReward()}|||~~~{_RCL_goal}|||~~~{_RCL_bonus}|||~~~{_RCL_completionCounter}";
    }

    public override string ToString()
    {
        return $"{RCL_GetName()} ({RCL_GetDescription()}) -- Completed {_RCL_completionCounter}/{_RCL_goal} times";
    }
}