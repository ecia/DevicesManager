using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevicesManager.Models
{
    public class DeviceFile
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public Device Device { get; set; }
        public byte[] Data { get; set; }
    }
}