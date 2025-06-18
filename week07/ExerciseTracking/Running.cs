using System;

public class Running : Activity
{
    private double _distance;
    private const double MinsPerHour = 60;

    public Running(DateTime date, int durationInMin, double distance) : base(date, durationInMin)
    {
        _distance = distance;
    }

    public override double CalcDistance()
    {
        return _distance;
    }

    public override double CalcSpeed()
    {
        return (CalcDistance() / GetDuration()) * MinsPerHour;
    }

    public override double CalcPace()
    {
        double distance = CalcDistance();
        if (distance == 0)
        {
            return 0;
        }
        return (GetDuration() / distance);
    }

}