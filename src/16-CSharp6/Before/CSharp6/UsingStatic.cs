// Using Static
namespace UsingStatic
{
    using System;

    // Import static or enum members
    //using static System.Math;
    //using static System.DayOfWeek;

    // C# 5:
    // Class name needed to invoke static or enum members
    public class Calculator_CS5
    {
        public double SquareRoot(double n)
        {
            return Math.Sqrt(n);
        }

        public double Pi
        {
            get { return Math.PI; }
        }

        public int WeekdayNumber(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday:
                    return 1;
                case DayOfWeek.Tuesday:
                    return 2;
                case DayOfWeek.Wednesday:
                    return 3;
                case DayOfWeek.Thursday:
                    return 4;
                case DayOfWeek.Friday:
                    return 5;
                default:
                    return 0;
            }
        }
    }

    // C# 6:
    // Use using static to import static or enum members
    //public class Calculator_CS6
    //{
    //    public double SquareRoot(double n)
    //    {
    //        return Sqrt(n);
    //    }

    //    public double Pi
    //    {
    //        get { return PI; }
    //    }

    //    public int WeekdayNumber(DayOfWeek day)
    //    {
    //        switch (day)
    //        {
    //            case Monday:
    //                return 1;
    //            case Tuesday:
    //                return 2;
    //            case Wednesday:
    //                return 3;
    //            case Thursday:
    //                return 4;
    //            case Friday:
    //                return 5;
    //            default:
    //                return 0;
    //        }
    //    }
    //}
}
