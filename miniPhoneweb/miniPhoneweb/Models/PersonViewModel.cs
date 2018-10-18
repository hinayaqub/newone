using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace miniPhoneweb.Models
{
    public class PersonViewModel
    {
        public int PersonId { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime AddedOn { get; set; }
        public String HomeAddress { get; set; }
        public String HomeCity { get; set; }
        public String FaceBookAccountId { get; set; }
        public String LinkedInId { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> UpdateOn { get; set; }
        public String ImagePath { get; set; }
        public String TwitterId { get; set; }
        public String EmailId { get; set; }
    }
}