using System;
using System.Collections.Generic;
using System.Text;

namespace PMS_Models
{
   public class EmergencyContactInfoModel
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
    }
}
