//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EMS.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkHistory
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public int CompId { get; set; }
        public int BranchId { get; set; }
        public System.DateTime FromDate { get; set; }
        public System.DateTime ToDate { get; set; }
        public int DesignationId { get; set; }
        public string Remarks { get; set; }
        public string Perfomance { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    }
}