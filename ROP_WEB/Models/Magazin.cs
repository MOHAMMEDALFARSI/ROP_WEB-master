using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ROP_WEB.Models
{
    public class Magazin
    {
        public int count { get; set; }
        public DateTime publishdate { get; set; }
        public string filename { get; set; }
        public string magaimg { get; set; }
        public int filesize { get; set; }
        public string magalang { get; set; }
        public int status { get; set; }
    }
}