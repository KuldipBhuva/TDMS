using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSDomain.ViewModel.Vehicle
{
    public class TripVehicleModel
    {
        public int Viewbagidformenu { get; set; }
        public int TVID { get; set; }
        public Nullable<int> TID { get; set; }
        [Required(ErrorMessage = "Vehicle Type Required")]
        public Nullable<int> VTID { get; set; }
        public Nullable<int> VTID1 { get; set; }
        public Nullable<int> VTID2 { get; set; }
        public Nullable<int> VTID3 { get; set; }
        [Required(ErrorMessage = "No. of Vehicle Required")]
        public string TotalVehicle { get; set; }
        public string TotalVehicle1 { get; set; }
        public string TotalVehicle2 { get; set; }
        public string TotalVehicle3 { get; set; }
    }
}
