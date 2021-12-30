using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PMS_Repository.Dtos
{
    public partial class EmergencyContactInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Relationship { get; set; }
        public string Email { get; set; }
        public string Contactno { get; set; }
        public string Address { get; set; }
        public int? Patientid { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
