using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Units")]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class UnitsAPIController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UnitsAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UnitsAPI
        [HttpGet]
        public IEnumerable<Unit> GetUnit()
        {
            return _context.Unit;
        }

        // GET: api/UnitsAPI/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUnit([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var unit = await _context.Unit.SingleOrDefaultAsync(m => m.Id == id);

            if (unit == null)
            {
                return NotFound();
            }

            return Ok(unit);
        }

        // PUT: api/UnitsAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnit([FromRoute] int id, [FromBody] Unit unit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != unit.Id)
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

        // POST: api/UnitsAPI
        [HttpPost]
        public async Task<IActionResult> PostUnit([FromBody] Unit unit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Unit.Add(unit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnit", new { id = unit.Id }, unit);
        }

        // DELETE: api/UnitsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnit([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var unit = await _context.Unit.SingleOrDefaultAsync(m => m.Id == id);
            if (unit == null)
            {
                return NotFound();
            }

            _context.Unit.Remove(unit);
            await _context.SaveChangesAsync();

            return Ok(unit);
        }

        private bool UnitExists(int id)
        {
            return _context.Unit.Any(e => e.Id == id);
        }
    }
}