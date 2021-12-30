using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PMS_API
{
    public partial class Patient
    {
        public Patient()
        {
            Allergies = new HashSet<Allergies>();
            EmergencyContactInfo = new HashSet<EmergencyContactInfo>();
            VitalSigns = new HashSet<VitalSigns>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string Languages { get; set; }
        public string HomeAddress { get; set; }
        public string Contactno { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Allergies> Allergies { get; set; }
        public virtual ICollection<EmergencyContactInfo> EmergencyContactInfo { get; set; }
        public virtual ICollection<VitalSigns> VitalSigns { get; set; }
    }
}
