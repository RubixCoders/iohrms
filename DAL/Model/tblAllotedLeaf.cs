//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblAllotedLeaf
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public Nullable<int> CL { get; set; }
        public Nullable<int> PL { get; set; }
        public Nullable<int> CompOff { get; set; }
        public int MonthId { get; set; }
    }
}
