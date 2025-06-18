using System;

public class Cycling : Activity
{
    private double _speed;
    private const int MinsPerHour = 60;


    public Cycling(DateTime date, int duractionInMin, double speed) : base(date, duractionInMin)
    {
        _speed = speed;
    }

    public override double CalcSpeed()
    {
        return _speed;
    }

    public override double CalcDistance()
    {
        return _speed * (GetDuraction() / MinsPerHour);
    }

    public override double CalcPace()
    {
        return (GetDuraction() / CalcDistance());
    }
}