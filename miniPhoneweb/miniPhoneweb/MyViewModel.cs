using miniPhoneweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniPhoneweb
{
    public class MyViewModel
    {
        public List<PersonViewModel> Birthday { get; set; }
        public List<PersonViewModel> Update { get; set; }
    }
}