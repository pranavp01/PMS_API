using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PMS_Repository.Dtos
{
    public partial class VitalSigns
    {
        public int Id { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string BloodPressure { get; set; }
        public string BodyTemperature { get; set; }
        public string RespirationRate { get; set; }
        public int? Patientid { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
