using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DevicesManager.Models
{
    public class User
    {
        [Display(Name = "Imie")]
        public string FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }
        [Display(Name = "Imię i nazwisko")]
        public string Name
        {
            get
            {
                return string.Format("{0} {1}", FirstName, Surname);
            }
        }
    }
}