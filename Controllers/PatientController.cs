﻿using System;
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
        public async Task<ActionResult<AppoinmentDetail>> CreateAppointment([FromBody] AppoinmentDetail appoinmentDetail)
        {
            try
            {
               // AppoinmentDetail appoinmentDetail = new AppoinmentDetail();
               // appoinmentDetail = JsonConvert.DeserializeObject<AppoinmentDetail>(appointment);
                _context.Add(appoinmentDetail);
               await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Appointment Successfully inserted..!!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

    }
}
