//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DailySoccer.DAC.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhoneVerification
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string VerificationCode { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<System.DateTime> CompletedDate { get; set; }
    }
}
