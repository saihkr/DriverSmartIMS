using DriverSmartIMS.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace DriverSmartIMS.Services
{
    public class FileStorageService : IFileStorage
    {
        public Stream GetInputStream(string FileName)
        {
            try
            {
                var assembly = typeof(App).GetTypeInfo().Assembly;
                return assembly.GetManifestResourceStream($"{assembly.GetName().Name}.Inputs.{FileName}");
            }
            catch (Exception ex)
            {
            }
            return null;
        }
    }
}
