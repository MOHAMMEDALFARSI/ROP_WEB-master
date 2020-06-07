using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ROP_WEB.Models
{
    public class ServiceViewModel
    {
        public int Service_Id { get; set; }
        public string Service_Name_Ar { get; set; }

        public string Service_Desc_Ar { get; set; }

        public string Service_procedure_Ar { get; set; }
   
        public string Service_Fees_Ar { get; set; }
 
        public string Service_Channel_Ar { get; set; }
            public string Service_Terms_Ar { get; set; }
       
        public string Service_Req_Doc_Ar { get; set; }
       
        public int Service_Cat_Id { get; set; }
        public string Service_Doc { get; set; }
        public int Service_Provider_Id { get; set; }
        public int services_Status_Id { get; set; }
       

        public virtual SERVICE_CAT SERVICE_CAT { get; set; }
        public virtual SERVICE_STATUS SERVICE_STATUS { get; set; }
        public virtual SERVICE_PROVIDER SERVICE_PROVIDER { get; set; }
    }
}