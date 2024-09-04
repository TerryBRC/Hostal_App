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
    public class TipoHabitacionController : ControllerBase
    {
        private readonly HostalDbContext _context;

        public TipoHabitacionController(HostalDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoHabitacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoHabitacion>>> GetTipoHabitacions()
        {
            return await _context.TipoHabitacions.ToListAsync();
        }

        // GET: api/TipoHabitacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoHabitacion>> GetTipoHabitacion(long id)
        {
            var tipoHabitacion = await _context.TipoHabitacions.FindAsync(id);

            if (tipoHabitacion == null)
            {
                return NotFound();
            }

            return tipoHabitacion;
        }

        // PUT: api/TipoHabitacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoHabitacion(long id, TipoHabitacion tipoHabitacion)
        {
            if (id != tipoHabitacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoHabitacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoHabitacionExists(id))
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

        // POST: api/TipoHabitacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoHabitacion>> PostTipoHabitacion(TipoHabitacion tipoHabitacion)
        {
            _context.TipoHabitacions.Add(tipoHabitacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoHabitacion", new { id = tipoHabitacion.Id }, tipoHabitacion);
        }

        // DELETE: api/TipoHabitacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoHabitacion(long id)
        {
            var tipoHabitacion = await _context.TipoHabitacions.FindAsync(id);
            if (tipoHabitacion == null)
            {
                return NotFound();
            }

            _context.TipoHabitacions.Remove(tipoHabitacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoHabitacionExists(long id)
        {
            return _context.TipoHabitacions.Any(e => e.Id == id);
        }
    }
}
