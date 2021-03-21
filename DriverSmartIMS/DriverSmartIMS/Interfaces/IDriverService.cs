using DriverSmartIMS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DriverSmartIMS.Interfaces
{
    public interface IDriverService
    {
        List<DriverTripReportModel> GetDriverTripReports(HashSet<string> DriverList, List<DriverTripModel> DriverTripDetails);
    }
}
