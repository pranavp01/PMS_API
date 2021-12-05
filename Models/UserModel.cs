using System;
using System.Collections.Generic;
using System.Text;

namespace PMS_Models
{
   public class UserModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Contactno { get; set; }
        public int Role { get; set; }
        public DateTime Dob { get; set; }
        public virtual Roles Roles { get; set; }
    }
}
