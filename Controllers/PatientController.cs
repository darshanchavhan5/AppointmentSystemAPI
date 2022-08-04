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
using Newtonsoft.Json;

namespace AppointmentSystem.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly AppoinmentSystemContext _context;
        
        public PatientController(AppoinmentSystemContext context)
        {
            this._context = context;
        }

        
        [HttpPost]
        [Route("CreateAppointment")]
        public async Task<ActionResult<AppoinmentDetails>> CreateAppointment([FromBody] AppoinmentDetails appoinmentDetail)
        {
            try
            {
                _context.Add(appoinmentDetail);
               await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Appointment Successfully inserted..!!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        [Route("CreatePatient")]
        public async Task<ActionResult<PatientMaster>> CreatePatient([FromBody] PatientMaster patientmaster)
        {

            try
            {
                _context.Add(patientmaster);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Patient registration successfully done..!!");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }


        }
        [HttpGet]
        [Route("GetPatients")]
        public IEnumerable<PatientMaster> GetPatients() => _context.PatientMaster.ToList();
    }
}
