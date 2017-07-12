using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSDomain.ViewModel.Vehicle
{
    public class VehicleTypeModel
    {
        
        public int VTID { get; set; }       
        public string VehicleType { get; set; }
        public string Capacity { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}
