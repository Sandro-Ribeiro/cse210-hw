using System;

public class Running : Activity
{
    private double _distance;
    private const double MinsPerHour = 60;

    public Running(DateTime date, int duractionInMin, double distance) : base(date, duractionInMin)
    {
        _distance = distance;
    }

    public override double CalcDistance()
    {
        return _distance;
    }

    public override double CalcSpeed()
    {
        return (CalcDistance() / GetDuraction()) * MinsPerHour;
    }

    public override double CalcPace()
    {
        return (GetDuraction() / CalcDistance());
    }

}