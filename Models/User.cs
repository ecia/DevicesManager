using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevicesManager.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Name
        {
            get
            {
                return string.Format("{0} {1}", FirstName, Surname);
            }
        }
    }
}