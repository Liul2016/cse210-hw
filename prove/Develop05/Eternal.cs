/*
Eternal quest: A quest that never ends
*/

public class Eternal : Quest
{
    public Eternal(string name, string description, bool completed, int reward) : base(name, description, completed, reward){}

    public override int RCL_CompleteQuest() // Complete a quest
    {
        return base.RCL_GetReward();
    }

    public override string RCL_SaveGoals() // Return a string with all variable to save a quest
    {
        return $"{GetType()}|||~~~{RCL_GetName()}|||~~~{RCL_GetDescription()}|||~~~{RCL_GetCompleted()}|||~~~{RCL_GetReward()}";
    }
}