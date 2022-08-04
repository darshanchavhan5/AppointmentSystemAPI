using AppointmentSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly AppoinmentSystemContext _context;

        public LogsController(AppoinmentSystemContext context)
        {
            this._context = context;
        }

        [HttpPost]
        [Route("InsertLog")]
        public async Task<ActionResult<Logs>> InsertLog([FromBody] Logs log)
        {
            try
            {
                _context.Add(log);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "Log Inserted Successfully..!!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}
