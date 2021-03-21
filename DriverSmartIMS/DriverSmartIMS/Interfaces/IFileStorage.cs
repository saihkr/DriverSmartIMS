using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DriverSmartIMS.Interfaces
{
    public interface IFileStorage
    {
        Stream GetInputStream(string FileName);
    }
}
