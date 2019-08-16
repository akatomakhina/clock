using System;

namespace AngleBetweenClockHands
{
    public static class InputHelper
    {
        public static void GetAngle()
        {
            double angle;

            Logger.Log.Info("Start input.");

            Console.WriteLine("Enter hours: ");
            var h = Console.ReadLine();

            Console.WriteLine("Enter minutes: ");
            var m = Console.ReadLine();

            bool isCorrect = false;
            while (!isCorrect)
            {
                try
                {
                    Validate(h, m);
                    isCorrect = true;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Logger.Log.Error("ArgumentOutOfRangeException in input.");
                    HandleException(ex.Message, ref h, ref m);
                }
                catch (FormatException ex)
                {
                    Logger.Log.Error("FormatException in input.");
                    HandleException(ex.Message, ref h, ref m);
                }
            }

            Logger.Log.Info("Successful input.");
            Logger.Log.Info("Start calculating.");
            angle = Time.FindAngle(int.Parse(h), int.Parse(m));
            Console.WriteLine("Angle: " + angle);
        }

        private static void HandleException(string message, ref string h, ref string m)
        {
            if (message == ValidationErrorCodes.HoursFormatError || message == ValidationErrorCodes.HoursFormatError)
            {
                Console.WriteLine($"{message}. Repeat input for hours.");
                h = Console.ReadLine();
            }
            else if (message == ValidationErrorCodes.MinutesFormatError || message == ValidationErrorCodes.MinutesOutOfRangeError)
            {
                Console.WriteLine($"{message}. Repeat input for minutes.");
                m = Console.ReadLine();
            }
        }

        private static void Validate(string hours, string minutes)
        {
            int resultHours;
            int resultMinutes;
            if (int.TryParse(hours, out resultHours))
            {
                if (resultHours < 0 || resultHours > TimeConstants.Day)
                {
                    throw new ArgumentOutOfRangeException(ValidationErrorCodes.HoursOutOfRangeError);
                }
            }
            else
            {
                throw new FormatException(ValidationErrorCodes.HoursFormatError);
            }
            if (int.TryParse(minutes, out resultMinutes))
            {
                if (resultMinutes < 0 || resultMinutes > TimeConstants.OneHour)
                {
                    throw new ArgumentOutOfRangeException(ValidationErrorCodes.MinutesOutOfRangeError);
                }
            }
            else
            {
                throw new FormatException(ValidationErrorCodes.MinutesFormatError);
            }
        }
    }
}
