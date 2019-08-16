namespace AngleBetweenClockHands
{
    public static class Time
    {
        delegate double Angle();

        private static double CalculateAngle(int hour, int minute)
        {
            double angle;

            double castHours = hour;
            double castMinutes = minute;

            hour = PreparationHourValue(hour);
            angle = ((castHours + (castMinutes / TimeConstants.OneHour)) * TimeConstants.HalfAnHour - (castMinutes * TimeConstants.DegreesInOneMinute));
            angle = PreparationAngleValue(angle);

            return angle;
        }

        public static double FindAngle(int hour, int minute)
        {
            Angle angle = () => CalculateAngle(hour, minute);
            return angle();
        }

        private static int PreparationHourValue(int hours)
        {
            if (hours >= TimeConstants.HalfDay)
            {
                hours -= TimeConstants.HalfDay;
            }

            if (hours == TimeConstants.Day)
            {
                hours = 0;
            }

            return hours;
        }

        private static double PreparationAngleValue(double angle)
        {
            if (angle > TimeConstants.HalfCircle)
            {
                angle -= TimeConstants.Circle;
            }

            if (angle < -TimeConstants.HalfCircle)
            {
                angle += TimeConstants.Circle;
            }

            return angle;
        }
    }
}
