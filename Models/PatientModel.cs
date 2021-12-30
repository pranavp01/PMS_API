using System;
using System.Collections.Generic;
using System.Text;

namespace PMS_Models
{
    public class PatientModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string Languages { get; set; }
        public string Email { get; set; }
        public string HomeAddress { get; set; }
        public string Contactno { get; set; }
        public List<EmergencyContactInfoModel> EmergencyContactInfos { get; set; }
        public List<AllergyModel> Allergys { get; set; }

    }

    
}
