using System;

public class SimpleGoal : Goal
{
    private bool _isCompleted;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isCompleted = false;
    }

    public override void RecordEvent()
    {
        _isCompleted = true;
    }

    public override bool IsComplete()
    {
        return _isCompleted;
    }

    public override string GetStringRepresentation()
    {
        if (IsComplete() == true)
        {
            return $"SimpleGoal: {GetShortName()}, {GetDescription()}, {GetPoints()}, True";
        }
        else
        {
            return $"SimpleGoal: {GetShortName()}, {GetDescription()}, {GetPoints()}, False";          
        }
    }
}