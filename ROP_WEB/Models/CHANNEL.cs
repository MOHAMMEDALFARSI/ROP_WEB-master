
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
    
public partial class CHANNEL
{

    public CHANNEL()
    {

        this.CHANNEL_SERVICES = new HashSet<CHANNEL_SERVICES>();

    }


    public int Channel_Id { get; set; }

    public string Channel_Name_Ar { get; set; }

    public string Channel_Name_En { get; set; }

    public string channel_url { get; set; }



    public virtual ICollection<CHANNEL_SERVICES> CHANNEL_SERVICES { get; set; }

}

}
