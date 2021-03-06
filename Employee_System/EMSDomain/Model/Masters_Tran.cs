//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EMSDomain.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Masters_Tran
    {
        public Masters_Tran()
        {
            this.EmployeeInsurances = new HashSet<EmployeeInsurance>();
            this.EmployeeInsurances1 = new HashSet<EmployeeInsurance>();
            this.Other_Expenses = new HashSet<Other_Expenses>();
            this.Petrol_Card = new HashSet<Petrol_Card>();
            this.Petrol_Card1 = new HashSet<Petrol_Card>();
            this.VehicleRepairings = new HashSet<VehicleRepairing>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> MasterId { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual ICollection<EmployeeInsurance> EmployeeInsurances { get; set; }
        public virtual ICollection<EmployeeInsurance> EmployeeInsurances1 { get; set; }
        public virtual Master Master { get; set; }
        public virtual ICollection<Other_Expenses> Other_Expenses { get; set; }
        public virtual ICollection<Petrol_Card> Petrol_Card { get; set; }
        public virtual ICollection<Petrol_Card> Petrol_Card1 { get; set; }
        public virtual ICollection<VehicleRepairing> VehicleRepairings { get; set; }
    }
}
