using System;
using System.Collections.Generic;

#nullable disable

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
