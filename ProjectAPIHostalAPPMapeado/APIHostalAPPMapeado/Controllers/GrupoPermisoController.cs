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
    public class GrupoPermisoController : ControllerBase
    {
        private readonly HostalDbContext _context;

        public GrupoPermisoController(HostalDbContext context)
        {
            _context = context;
        }

        // GET: api/GrupoPermiso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GruposPermiso>>> GetGruposPermisos()
        {
            return await _context.GruposPermisos.ToListAsync();
        }

        // GET: api/GrupoPermiso/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GruposPermiso>> GetGruposPermiso(long id)
        {
            var gruposPermiso = await _context.GruposPermisos.FindAsync(id);

            if (gruposPermiso == null)
            {
                return NotFound();
            }

            return gruposPermiso;
        }

        // PUT: api/GrupoPermiso/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGruposPermiso(long id, GruposPermiso gruposPermiso)
        {
            if (id != gruposPermiso.Id)
            {
                return BadRequest();
            }

            _context.Entry(gruposPermiso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GruposPermisoExists(id))
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

        // POST: api/GrupoPermiso
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GruposPermiso>> PostGruposPermiso(GruposPermiso gruposPermiso)
        {
            _context.GruposPermisos.Add(gruposPermiso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGruposPermiso", new { id = gruposPermiso.Id }, gruposPermiso);
        }

        // DELETE: api/GrupoPermiso/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGruposPermiso(long id)
        {
            var gruposPermiso = await _context.GruposPermisos.FindAsync(id);
            if (gruposPermiso == null)
            {
                return NotFound();
            }

            _context.GruposPermisos.Remove(gruposPermiso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GruposPermisoExists(long id)
        {
            return _context.GruposPermisos.Any(e => e.Id == id);
        }
    }
}
