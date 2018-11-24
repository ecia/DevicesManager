using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;  //needed for Display annotation
using System.ComponentModel;

namespace DevicesManager.Models
{
    public class Device
    {
        
        public int DeviceId { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int? Battery { get; set; }
        public string CPU { get; set; }
        public int? RAM { get; set; }
        public int? ProcessNumber { get; set; }
    }
}