using System;
using System.Collections.Generic;
using System.Text;

namespace DriverSmartIMS.Model
{
    public class DriverTripReportModel : ObservableBase
    {
        public string DriverName { get; set; }

        public double AverageSpeed { get; set; }

        public double TotalDistance { get; set; }

        public double TotalTime { get; set; }        

        private double CalculateAverageMPH()
        {
            try
            {
                AverageSpeed =  Math.Round((TotalDistance / TotalTime), 0);
                TotalDistance = Math.Round(TotalDistance, 0);
            }
            catch (Exception Ex)
            {
            }
            return 0;
        }

        public string OutPutString
        {
            get
            {
                CalculateAverageMPH();
                if (TotalDistance == 0)
                    return $"{DriverName}: {TotalDistance} miles";
                else
                    return $"{DriverName}: {TotalDistance} miles @ {AverageSpeed} mph";
            }
        }
    }
}
