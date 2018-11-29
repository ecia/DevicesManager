using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DevicesManager.Models
{
    public class DeviceData
    {
        [Key]
        [Display(Name = "Dane otrzymano ")]
        public DateTime SendDateTime { get; set; }
        public int DeviceId { get; set; }
        public Device Device { get; set; }
        public int? Battery { get; set; }
        public double? CPU { get; set; }
        public double? RAM { get; set; }
        public int? ProcessNumber { get; set; }
    }
}