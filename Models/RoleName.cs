using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;  //needed for Display annotation
using System.ComponentModel;

namespace DevicesManager.Models
{
    public static class RoleName
    {
        [Display(Name = "Administrator")]
        public const string Admin = "Admin";

        [Display(Name = "Użytkownik")]
        public const string User = "User";
    }
}