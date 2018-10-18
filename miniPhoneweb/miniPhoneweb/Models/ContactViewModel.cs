using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniPhoneweb.Models
{
    public class ContactViewModel
    {
        public string  ContactNumber { get; set; }
        public string Type { get; set; }
        public int PersonId { get; set; }
        public int Contactid { get; set; }
    }
}