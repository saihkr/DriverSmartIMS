using DriverSmartIMS.Interfaces;
using DriverSmartIMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriverSmartIMS.Services
{
    public class DriverService : IDriverService
    {
        public List<DriverTripReportModel> GetDriverTripReports(HashSet<string> DriverList, List<DriverTripModel> DriverTripDetails)
        {
            List<DriverTripReportModel> driverTripReport = new List<DriverTripReportModel>();
            foreach (string driverName in DriverList)
            {
                try
                {
                    List<DriverTripModel> tripDetails = DriverTripDetails?.Where(x => x.DriverName == driverName && !x.CanDiscard)?.ToList();
                    if (tripDetails != null)
                    {
                        driverTripReport.Add(
                            new DriverTripReportModel()
                            {
                                DriverName = driverName,
                                TotalTime = tripDetails.Sum(x => x.TimeTravelled),
                                TotalDistance = tripDetails.Sum(x => x.MilesDriven)
                            }
                        );
                    }
                    else
                    {
                        driverTripReport.Add(
                            new DriverTripReportModel()
                            {
                                DriverName = driverName,
                                TotalTime = 0,
                                TotalDistance = 0
                            }
                        );
                    }
                }
                catch (Exception ex) { }
            }

            return driverTripReport.OrderByDescending(x => x.TotalDistance).ToList();
        }
    }
}
