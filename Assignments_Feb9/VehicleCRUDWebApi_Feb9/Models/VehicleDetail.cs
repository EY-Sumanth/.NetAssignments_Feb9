using System;
using System.Collections.Generic;

namespace VehicleCRUDWebApi_Feb9.Models
{
    public partial class VehicleDetail
    {
        public int VehicleId { get; set; }
        public string? VehicleName { get; set; }
        public int? VehiclePrice { get; set; }
        public int? VehicleModel { get; set; }
        public string? VehicleType { get; set; }
    }
}
