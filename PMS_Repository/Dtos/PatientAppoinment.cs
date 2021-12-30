using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PMS_Repository.Dtos
{
    public partial class PatientAppoinment
    {
        public int Id { get; set; }
        public int? Patientid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Physicianname { get; set; }
        public string AppoinmentType { get; set; }
        public string AppoinmentDate { get; set; }
        public double? AppoinmentTime { get; set; }
        public string Contactno { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
