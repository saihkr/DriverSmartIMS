using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DriverSmartIMS.Model
{
    public class DriverTripModel
    {
        public DriverTripModel(string[] tripValues)
        {
            if (tripValues.Length == 5)
            {
                DriverName = tripValues[1];
                StrartTime = StringToTimeStamp(tripValues[2]);
                EndTime = StringToTimeStamp(tripValues[3]);
                MilesDriven = Convert.ToDouble(tripValues[4]);
                ValidateTrip();
            }
        }

        public string DriverName { get; set; }

        public DateTime StrartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool CanDiscard { get; set; }

        public double MilesDriven { get; set; }
        public double TimeTravelled { get; set; }
        public double Speed { get; set; }

        private DateTime StringToTimeStamp(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                var date = DateTime.Now.Date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                var dateTime = $"{date} {value}";
                return DateTime.Parse(dateTime, CultureInfo.InvariantCulture);
            }
            return DateTime.MinValue;
        }

        private void ValidateTrip()
        {
            TimeTravelled = TimeTakenInHrs(EndTime, StrartTime);
            if (TimeTravelled > 0)
            {
                Speed = CalculateAverageMPH(TimeTravelled, MilesDriven);
                if (Speed < 5 || Speed > 100) CanDiscard = true;
                return;
            }
            CanDiscard = true;
        }

        private double CalculateAverageMPH(double timeTaken,double distanceTravelled)
        {
            try
            {
                return Math.Round((distanceTravelled / timeTaken), 0);
            }
            catch (Exception Ex)
            {
            }
            return 0;
        }

        private double TimeTakenInHrs(DateTime newTime, DateTime oldTime)
        {
            try
            {
                if (newTime < oldTime) return -1;
                return Math.Round((newTime - oldTime).TotalHours, 2);
            }
            catch (Exception Ex)
            {
            }
            return -1;
        }
    }
}
