using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSDomain.ViewModel.Vehicle
{
    public class TripModel
    {
        public int Viewbagidformenu { get; set; }
        public int TID { get; set; }
        [Required(ErrorMessage = "Vehicle Type Required")]
        //[Display(Name = "Company :*")]
        
        public Nullable<int> CID { get; set; }
        public Nullable<int> BID { get; set; }
        public string OINo { get; set; }
        [Required(ErrorMessage = "Booking By Required")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Order/Inquiry Type Required")]
        public string OIType { get; set; }
        [Required(ErrorMessage = "Name Required")]
        public string PName1 { get; set; }
        [Required(ErrorMessage = "Mobile Required")]
        public string PMobile1 { get; set; }
        [Required(ErrorMessage = "City Required")]
        public string PCity1 { get; set; }
        public string PEmail1 { get; set; }
        public string PName2 { get; set; }
        public string PMobile2 { get; set; }
        public string PCity2 { get; set; }
        public string PEmail2 { get; set; }
        [Required(ErrorMessage = "Name Required")]
        public string BName { get; set; }
        [Required(ErrorMessage = "Mobile Required")]
        public string BMobile { get; set; }
        [Required(ErrorMessage = "City Required")]
        public string BCity { get; set; }
        public string BEmail { get; set; }
        [Required(ErrorMessage = "Name Required")]
        public string AName { get; set; }
        [Required(ErrorMessage = "Mobile Required")]
        public string AMobile { get; set; }
        [Required(ErrorMessage = "City Required")]
        public string ACity { get; set; }
        [Required(ErrorMessage = "Commission Required")]
        public string ACommission { get; set; }
        [Required(ErrorMessage = "From City Required")]
        public string FCity { get; set; }
        [Required(ErrorMessage = "To City Required")]
        public string TCity { get; set; }
        [Required(ErrorMessage = "Departure Date Time Required")]
        public Nullable<System.DateTime> DDtTime { get; set; }
        [Required(ErrorMessage = "Return Date Time Required")]
        public Nullable<System.DateTime> RDtTime { get; set; }
        [Required(ErrorMessage = "Total Days Required")]
        public string TotalDays { get; set; }
        [Required(ErrorMessage = "Total Vehicle Required")]
        public string TotalVehicle { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public List<TripModel> ListTrip { get; set; }
        public List<VehicleTypeModel> ListVType { get; set; }
        public TripVehicleModel VTypeModel { get; set; }
        public List<TripVehicleModel> lstTVehicle { get; set; }
    }
}
