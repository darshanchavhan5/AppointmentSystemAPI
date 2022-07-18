using System;
using System.Collections.Generic;

#nullable disable

namespace AppointmentSystem.Models
{
    public partial class AppoinmentDetail
    {
        public int AppoinmentId { get; set; }
        public string PatientName { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? AppoinmnetDate { get; set; }
        public int? PatientId { get; set; }
        public string DoctorName { get; set; }

    }
}
