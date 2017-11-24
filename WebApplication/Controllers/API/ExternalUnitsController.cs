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

namespace WebApplication.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Units")]
    [Authorize]
    public class ExternalUnitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExternalUnitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ExternalUnits
        [HttpGet]
        public IEnumerable<Unit> GetUnit()
        {
            return _context.Unit;
        }

        // GET: api/ExternalUnits/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUnit([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var unit = await _context.Unit.SingleOrDefaultAsync(m => m.UnitId == id);

            if (unit == null)
            {
                return NotFound();
            }

            return Ok(unit);
        }

        // PUT: api/ExternalUnits/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnit([FromRoute] string id, [FromBody] Unit unit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unit.UnitId)
            {
                return BadRequest();
            }

            _context.Entry(unit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitExists(id))
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

        // POST: api/ExternalUnits
        [HttpPost]
        public async Task<IActionResult> PostUnit([FromBody] Unit unit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Unit.Add(unit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnit", new { id = unit.UnitId }, unit);
        }

        // DELETE: api/ExternalUnits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnit([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var unit = await _context.Unit.SingleOrDefaultAsync(m => m.UnitId == id);
            if (unit == null)
            {
                return NotFound();
            }

            _context.Unit.Remove(unit);
            await _context.SaveChangesAsync();

            return Ok(unit);
        }

        private bool UnitExists(string id)
        {
            return _context.Unit.Any(e => e.UnitId == id);
        }
    }
}