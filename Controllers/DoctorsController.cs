using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppointmentSystem.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using MimeKit;

namespace AppointmentSystem.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly AppoinmentSystemContext _context;

        public DoctorsController(AppoinmentSystemContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IEnumerable<Doctor> GetDoctors() => _context.Doctor.ToList();

        [HttpGet("{id:int}")]
        [Route("GetDoctor/{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            try
            {
                var result = await _context.Doctor.FindAsync(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error retrieving data from the database");
            }
        }


        [HttpGet("{id:int}")]
        [Route("GetDoctorAppointmentList/{id}")]
        public IEnumerable<AppoinmentDetails> GetDoctorAppointmentList(int id)
        {
            try
            {
                var result =  _context.AppoinmentDetails.Where(x => x.DoctorId == id && x.AppoinmnetDate.Value.Date >= DateTime.Today)
                                                                       .OrderByDescending(x => x.AppoinmnetDate).ToList();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("ApproveAppointment")]
        public async Task<ActionResult<AppoinmentDetails>> ApproveAppointment([FromBody] AppoinmentDetails appointmentDetail)
        {
            try
            {
                _context.Update(appointmentDetail);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "Appointment Successfully Approved..!!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        [Route("RejectAppointment")]
        public async Task<ActionResult<AppoinmentDetails>> RejectAppointment([FromBody] AppoinmentDetails appoinmentDetail)
        {
            try
            {
                var current = _context.AppoinmentDetails.Find(appoinmentDetail.AppoinmentId);
                AppoinmentDetails appointmentDetails = new AppoinmentDetails();
                if (current != null)
                {
                    appointmentDetails = _context.AppoinmentDetails.Where(u => u.AppoinmentId == appoinmentDetail.AppoinmentId).FirstOrDefault();
                    appointmentDetails.Comment = appoinmentDetail.Comment;
                    appointmentDetails.Status = false;
                    _context.Update(appointmentDetails);
                    await _context.SaveChangesAsync();
                }

                #region EMAIL SEND CODE HERE

                var PatientData = _context.PatientMaster.Find(appointmentDetails.PatientId);
                var DoctorData = _context.Doctor.Find(appointmentDetails.DoctorId);

               // this.SendEmailToPatient(DoctorData.EmailId ?? "", PatientData.EmailId ?? "", PatientData.PatientName ?? "", DoctorData.DocName ?? "");

                #endregion

                return StatusCode(StatusCodes.Status200OK, "Appointment Successfully Rejected..!!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Email not Sent..!!!");
            }
        }

        public void SendEmailToPatient(string strFromEmail , string strToEmail , string strPatientName, string strDoctorName)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(strFromEmail);
            mail.To.Add(strToEmail);
            mail.Subject = "Appointment Rejected.!!";
            mail.Body = "Hi" + strPatientName + "," +
                         @"Your Appointment Rejected by" + strDoctorName ;

            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("email", "Password");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }

        [HttpPost]
        [Route("CreateDoctor")]
        public async Task<ActionResult<Doctor>> CreateDoctor([FromBody] Doctor doctor)
        {

            try
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Doctor registration successfully done..!!");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }


        }
    }
}
