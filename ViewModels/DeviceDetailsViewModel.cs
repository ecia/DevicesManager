using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevicesManager.Models;

namespace DevicesManager.ViewModels
{
    public class DeviceDetailsViewModel
    {
        public Device Device { get; set; }
        public IEnumerable<DeviceData> DeviceData { get; set; }
    }
}