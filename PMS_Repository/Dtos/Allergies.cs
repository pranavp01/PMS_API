using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PMS_Repository.Dtos
{
    public partial class Allergies
    {
        public int Id { get; set; }
        public string AllergyId { get; set; }
        public string AllergyType { get; set; }
        public string AllergyName { get; set; }
        public string AllergyDescription { get; set; }
        public string AllergyClinicalInformation { get; set; }
        public int? Patientid { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
