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
    
    public partial class ConsignmentMaster
    {
        public int GrNo { get; set; }
        public string LR { get; set; }
        public Nullable<int> TaxPaidBy { get; set; }
        public string BillingName { get; set; }
        public string BillingAddress { get; set; }
        public Nullable<int> ConsignorID { get; set; }
        public Nullable<int> ConsigneeID { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public Nullable<decimal> Packages { get; set; }
        public string PackingMethod { get; set; }
        public Nullable<decimal> ActualWeight { get; set; }
        public Nullable<decimal> ChargedWeight { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> FreightCharge { get; set; }
        public Nullable<decimal> LabourCharge { get; set; }
        public Nullable<decimal> OtherCharge { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<decimal> InvoiceAmount { get; set; }
        public string Remarks { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<System.DateTime> BookingDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> CompID { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> DeliveryMode { get; set; }
        public Nullable<int> CompBrokerID { get; set; }
        public string ConsigneeInvoiceNo { get; set; }
        public Nullable<decimal> ConsigneeInvoiceValue { get; set; }
        public string PickUp { get; set; }
    }
}
