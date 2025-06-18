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
        return (CalcDistance() / GetDuraction()) * MinsPerHour;
    }

    public override double CalcPace()
    {
        return (GetDuraction() / CalcDistance());
    }
}

