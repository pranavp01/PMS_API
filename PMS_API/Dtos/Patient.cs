using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PMS_API.Dtos
{
    public partial class Patient
    {
        public int PId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public DateTime? Dob { get; set; }
        public string Role { get; set; }
        public int? Count { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
