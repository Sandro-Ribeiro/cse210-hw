using System;
using System.Globalization;

public abstract class Activity
{
    private DateTime _date;
    private int _durationInMin;

    public Activity(DateTime parsedDate, int durationInMin)
    {
        _date = parsedDate;
        _durationInMin = durationInMin;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public int GetDuration()
    {
        return _durationInMin;
    }

    public abstract double CalcDistance();

    public abstract double CalcSpeed();

    public abstract double CalcPace();

    public virtual void GetSummary()
    {
        string className = GetType().Name;
        string formatedDate = _date.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture);

        Console.WriteLine(
            $"{formatedDate} " +
            $"{className} ({GetDuration()} min), " +
            $"Distance: {CalcDistance().ToString("F2")} km, " +
            $"Speed: {CalcSpeed().ToString("F2")} kph, " +
            $"Pace: {CalcPace().ToString("F2")} min per km");
    }

}