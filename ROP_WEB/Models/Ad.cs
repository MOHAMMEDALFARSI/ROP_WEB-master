using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ROP_WEB.Models
{
    public class Ad
    {

        public int AdId { get; set; }
        public string AdTitle { get; set; }
        public string Adtxt { get; set; }
        public string Adfile { get; set; }
        public string AdLang { get; set; }
        public DateTime AdEndDate { get; set; }

    }
}