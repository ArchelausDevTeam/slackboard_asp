using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebApplication.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Assignments")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ExternalAssignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExternalAssignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ExternalAssignments
        [HttpGet]
        public IEnumerable<Assignment> GetAssignment()
        {
            return _context.Assignment;
        }

        // GET: api/ExternalAssignments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssignment([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignment = await _context.Assignment.SingleOrDefaultAsync(m => m.AssignmentId == id);

            if (assignment == null)
            {
                return NotFound();
            }

            return Ok(assignment);
        }

        // PUT: api/ExternalAssignments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignment([FromRoute] string id, [FromBody] Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assignment.AssignmentId)
            {
                return BadRequest();
            }

            _context.Entry(assignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ExternalAssignments
        [HttpPost]
        public async Task<IActionResult> PostAssignment([FromBody] Assignment assignment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Assignment.Add(assignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssignment", new { id = assignment.AssignmentId }, assignment);
        }

        // DELETE: api/ExternalAssignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assignment = await _context.Assignment.SingleOrDefaultAsync(m => m.AssignmentId == id);
            if (assignment == null)
            {
                return NotFound();
            }

            _context.Assignment.Remove(assignment);
            await _context.SaveChangesAsync();

            return Ok(assignment);
        }

        private bool AssignmentExists(string id)
        {
            return _context.Assignment.Any(e => e.AssignmentId == id);
        }
    }
}