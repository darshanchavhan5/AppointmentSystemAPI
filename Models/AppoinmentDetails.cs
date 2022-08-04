using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AppointmentSystem.Models
{
    public partial class AppoinmentDetails
    {
        public int AppoinmentId { get; set; }
        public string PatientName { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? AppoinmnetDate { get; set; }
        public int? PatientId { get; set; }
        public string DoctorName { get; set; }
        public string Comment { get; set; }
        public bool? Status { get; set; }
    }
}
