
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
    
public partial class CHANNEL_SERVICES
{

    public int Service_Channel_Id { get; set; }

    public int Channel_Id { get; set; }

    public int Service_Id { get; set; }



    public virtual CHANNEL CHANNEL { get; set; }

    public virtual SERVICE SERVICE { get; set; }

}

}