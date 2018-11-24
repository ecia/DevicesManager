using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevicesManager.Models;

namespace DevicesManager.ViewModels
{
    public class UserDeviceViewModel
    {
        public string UserName { get; set; }
        public List<Device> Devices { get; set; }
    }
}