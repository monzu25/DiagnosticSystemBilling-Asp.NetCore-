//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_CityLab
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvestigationMaster
    {
        public string VoucherNo { get; set; }
        public System.DateTime Date { get; set; }
        public string PatientName { get; set; }
        public string Guardian { get; set; }
        public string Address { get; set; }
        public Nullable<int> SLNo { get; set; }
        public string Mobile { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string Gender { get; set; }
        public Nullable<int> DoctorID { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> NetAmt { get; set; }
        public Nullable<decimal> PaidAmt { get; set; }
        public Nullable<decimal> DueAmt { get; set; }
    
        public virtual Doctors Doctors { get; set; }
    }
}
