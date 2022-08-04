using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AppointmentSystem.Models
{
    public partial class Doctor
    {
        public int DocId { get; set; }
        public string DocName { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public string Specialization { get; set; }
        public string Password { get; set; }
        public int? UserType { get; set; }
        public string CreatedBy { get; set; }
    }
}
