using System;

namespace AngleBetweenClockHands
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.InitLogger();
            InputHelper.GetAngle();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
