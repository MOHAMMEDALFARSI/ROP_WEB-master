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
    
    public partial class SERVICE_PROVIDER
    {
        public SERVICE_PROVIDER()
        {
            this.SERVICEs = new HashSet<SERVICE>();
        }
    
        public int Service_Provider_Id { get; set; }
        public string Service_Provider_Name_Ar { get; set; }
        public string Service_Provider_Name_En { get; set; }
    
        public virtual ICollection<SERVICE> SERVICEs { get; set; }
    }
}