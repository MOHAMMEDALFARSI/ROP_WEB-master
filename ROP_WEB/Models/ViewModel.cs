using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ROP_WEB.Models
{
    public class ViewModel
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Ad> Ads { get; set; }
        public IEnumerable<NewsMain> News { get; set; }
    }
}