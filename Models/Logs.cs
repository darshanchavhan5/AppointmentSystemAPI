using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AppointmentSystem.Models
{
    public partial class Logs
    {
        public long Logid { get; set; }
        public string Logtype { get; set; }
        public string Actionname { get; set; }
        public string Controllername { get; set; }
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
