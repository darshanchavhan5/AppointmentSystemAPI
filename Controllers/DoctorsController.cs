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
        [Route("GetDoctors")]
        public IEnumerable<Doctor> GetDoctors() => _context.Doctors.ToList();

        [HttpGet("{id:int}")]
        [Route("GetDoctor/{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            try
            {
                var result = await _context.Doctors.FindAsync(id);

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
        public IEnumerable<AppoinmentDetail> GetDoctorAppointmentList(int id)
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

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocId,DocName,EmailId,MobileNumber,Specialization,Password,UserType,CreatedBy")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return null;// View(doctor);
        }

      
    }
}
