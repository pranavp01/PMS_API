using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PMS_Repository.Dtos
{
    public partial class RolesModel
    {
        public int Id { get; set; }
        public string Rolename { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual User User { get; set; }
    }
}
