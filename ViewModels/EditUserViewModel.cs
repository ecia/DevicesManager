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

        [StringLength(100, ErrorMessage = "{0} musi zawierać co najmniej następującą liczbę znaków: {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public String Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Hasło i jego potwierdzenie są niezgodne.")]
        public String ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Adres e-mail")]
        public string Email { get; set; }

        public string Code { get; set; }

        public string RoleID { get; set; }

        [Display(Name = "Rola użytkownika")]
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}