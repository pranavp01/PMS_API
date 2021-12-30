using System;
using System.Collections.Generic;
using System.Text;

namespace PMS_Models
{
    public class AllergyModel
    {
        public int Id { get; set; }
        public string AllergyId { get; set; }
        public string AllergyType { get; set; }
        public string AllergyName { get; set; }
        public string AllergyDescription { get; set; }
        public string AllergyClinicalInformation { get; set; }
        public int? Patientid { get; set; }
    }
}
