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
    
    public partial class employee_document
    {
        public int id { get; set; }
        public int empid { get; set; }
        public int categoryid { get; set; }
        public string title { get; set; }
        public string docu_copy { get; set; }
    
        public virtual employee_master employee_master { get; set; }
    }
}
