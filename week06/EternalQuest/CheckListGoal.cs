using System;
using System.Runtime;

public class CheckListGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public CheckListGoal(string name, string description, int points, int target, int bonus, int amountCompleted = 0) : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;  
    }

    public override void RecordEvent()
    {
        _amountCompleted += 1;
    }

    public override bool IsComplete()
    {
        if (_amountCompleted == _target)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string GetDetailString()
    {
        return $"{GetShortName} ({GetDescription()}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"Checkist Goal: {GetShortName()}, {GetDescription()}, {GetPoints()}, {_bonus}, {_target}, {_amountCompleted}";          
    }
}