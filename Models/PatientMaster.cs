using System;
using System.Collections.Generic;

#nullable disable

namespace AppointmentSystem.Models
{
    public partial class PatientMaster
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public string Password { get; set; }
        public int? UserType { get; set; }
        public string CreatedBy { get; set; }
    }
}
