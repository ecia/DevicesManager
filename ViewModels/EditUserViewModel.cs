using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevicesManager.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DevicesManager.ViewModels
{
    public class EditUserViewModel
    {
        public ApplicationUser User { get; set; }

        [Display(Name = "Rola użytkownika")]
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}