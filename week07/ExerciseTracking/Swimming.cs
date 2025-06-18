using System;

public class Swimming : Activity
{
    private int _numberOfLaps;
    private const double MetersPerLap = 50;
    private const double MetersPerKm = 1000;
    private const double MinsPerHour = 60;

    public Swimming(DateTime date, int duration, int numberOfLaps) : base(date, duration)
    {
        _numberOfLaps = numberOfLaps;

    }

    public override double CalcDistance()
    {
        return (_numberOfLaps * MetersPerLap) / MetersPerKm;
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

