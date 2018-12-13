using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DevicesManager.Models
{
    public class RoleName
    {
        [Display(Name = "Administrator")]
        public const string Admin = "Admin";

        [Display(Name = "Użytkownik")]
        public const string User = "User";
    }
}