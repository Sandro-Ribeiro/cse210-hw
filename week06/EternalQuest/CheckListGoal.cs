using System;

public class CheckListGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public CheckListGoal(string name, string description, int points) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = 0;
        _bonus = 0;
        
    }
    public override void RecordEvent()
    {

    }

    public override bool IsComplete()
    {
        return true;
    }

    public override string GetDetailString()
    {
        return $"";
    }

    public override string GetStringRepresentation()
    {
        return $"";
    }

}