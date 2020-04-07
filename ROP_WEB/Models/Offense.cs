using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ROP_WEB.Models
{
    public class Offense
    {
        public int OffenseId { get; set; }
        public string OffenseClassAr { get; set; }
        public string OffenseClassEn { get; set; }
        public string OffenseDescAr { get; set; }
        public string OffenseDescEn { get; set; }
        public int OffensePoints { get; set; }
        public float OffenseAmount { get; set; }
    }
}