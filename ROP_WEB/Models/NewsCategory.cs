//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ROP_WEB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NewsCategory
    {
        public NewsCategory()
        {
            this.NewsMains = new HashSet<NewsMain>();
        }
    
        public int CategoryID { get; set; }
        public string CategoryE { get; set; }
        public string CategoryA { get; set; }
    
        public virtual ICollection<NewsMain> NewsMains { get; set; }
    }
}
