using System;

class Program
{
    static void Main(string[] args)
    {
        // Instantiate Fraction objects with no arguments, one argument, and two arguments
        Fraction fraction_01 = new Fraction();
        Fraction fraction_02 = new Fraction(6);
        Fraction fraction_03 = new Fraction(6, 7);

        Console.WriteLine("Getting values of the top and bottom");

        // Displaying the numerator and denominator values of each Fraction object
        Console.WriteLine("Fraction 01");
        Console.WriteLine($"{fraction_01.GetTop()}");
        Console.WriteLine($"{fraction_01.GetBottom()}");
        Console.WriteLine("Fraction 02");
        Console.WriteLine($"{fraction_02.GetTop()}");
        Console.WriteLine($"{fraction_02.GetBottom()}");
        Console.WriteLine("Fraction 03");
        Console.WriteLine($"{fraction_03.GetTop()}");
        Console.WriteLine($"{fraction_03.GetBottom()}");

        // Setting new numerator and denominator values for the first Fraction object
        fraction_01.SetTop(3);
        fraction_01.SetBottom(4);

        // Setting new numerator and denominator values for the second Fraction object
        fraction_02.SetTop(5);
        fraction_02.SetBottom(8);

        // Setting new numerator and denominator values for the third Fraction object
        fraction_03.SetTop(1);
        fraction_03.SetBottom(4);

        Console.WriteLine("Setting new values to top and bottom");

        // Displaying the updated numerator and denominator values of each Fraction object
        Console.WriteLine("Fraction 01");
        Console.WriteLine($"{fraction_01.GetTop()}");
        Console.WriteLine($"{fraction_01.GetBottom()}");
        Console.WriteLine("Fraction 02");
        Console.WriteLine($"{fraction_02.GetTop()}");
        Console.WriteLine($"{fraction_02.GetBottom()}");
        Console.WriteLine("Fraction 03");
        Console.WriteLine($"{fraction_03.GetTop()}");
        Console.WriteLine($"{fraction_03.GetBottom()}");

        Console.WriteLine("Displaying the fractions in string and decimal formats");

        Console.WriteLine("Fraction 01");
        Console.WriteLine(fraction_01.GetFractionString());
        Console.WriteLine($"{fraction_01.GetDecimalValue()}");
        Console.WriteLine("Fraction 02");
        Console.WriteLine(fraction_02.GetFractionString());
        Console.WriteLine($"{fraction_02.GetDecimalValue()}");
        Console.WriteLine("Fraction 03");
        Console.WriteLine(fraction_03.GetFractionString());
        Console.WriteLine($"{fraction_03.GetDecimalValue()}");

    }
}