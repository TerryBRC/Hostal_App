using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIHostalAPPMapeado.Models;

namespace APIHostalAPPMapeado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        private readonly HostalDbContext _context;

        public HabitacionController(HostalDbContext context)
        {
            _context = context;
        }

        // GET: api/Habitacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Habitacion>>> GetHabitacions()
        {
            return await _context.Habitacions.ToListAsync();
        }

        // GET: api/Habitacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Habitacion>> GetHabitacion(long id)
        {
            var habitacion = await _context.Habitacions.FindAsync(id);

            if (habitacion == null)
            {
                return NotFound();
            }

            return habitacion;
        }

        // PUT: api/Habitacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHabitacion(long id, Habitacion habitacion)
        {
            if (id != habitacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(habitacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabitacionExists(id))
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

        // POST: api/Habitacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Habitacion>> PostHabitacion(Habitacion habitacion)
        {
            _context.Habitacions.Add(habitacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHabitacion", new { id = habitacion.Id }, habitacion);
        }

        // DELETE: api/Habitacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabitacion(long id)
        {
            var habitacion = await _context.Habitacions.FindAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }

            _context.Habitacions.Remove(habitacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HabitacionExists(long id)
        {
            return _context.Habitacions.Any(e => e.Id == id);
        }
    }
}
