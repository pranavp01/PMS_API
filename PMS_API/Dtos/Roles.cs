using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PMS_API.Dtos
{
    public partial class Roles
    {
        public Roles()
        {
            User = new HashSet<User>();
        }

        public string Rolename { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int Id { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
