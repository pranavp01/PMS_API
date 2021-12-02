using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PMS_Repository.Dtos
{
    public partial class User
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Contactno { get; set; }
        public byte? IsFirstLogin { get; set; }
        public byte? IsBlocked { get; set; }
        public int Role { get; set; }
        public DateTime Dob { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int IsActive { get; set; }
        public virtual RolesModel IdNavigation { get; set; }
    }
}
