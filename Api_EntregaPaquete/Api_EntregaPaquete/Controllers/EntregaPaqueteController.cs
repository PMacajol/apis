using Api_EntregaPaquete.Models;
using Microsoft.AspNetCore.Mvc;
using Api_EntregaPaquete.Data;
using Microsoft.EntityFrameworkCore;

namespace Api_EntregaPaquete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregaPaqueteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EntregaPaqueteController(AppDbContext context)
        {
            _context = context;
        }

        // Método GET para obtener todas las entregas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntregaPaquete>>> GetEntregaPaquetes()
        {
            return await _context.EntregaPaquetes.ToListAsync();
        }

        // Método GET para obtener una entrega por su CódigoEntrega
        [HttpGet("{codigo}")]
        public async Task<ActionResult<EntregaPaquete>> GetEntregaPaquete(string codigo)
        {
            var entregaPaquete = await _context.EntregaPaquetes.FindAsync(codigo);

            if (entregaPaquete == null)
            {
                return NotFound();
            }

            return entregaPaquete;
        }

        // Método POST para crear una nueva entrega
        [HttpPost]
        public async Task<ActionResult<EntregaPaquete>> PostEntregaPaquete(EntregaPaquete entregaPaquete)
        {
            _context.EntregaPaquetes.Add(entregaPaquete);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EntregaPaqueteExists(entregaPaquete.CodigoEntrega))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetEntregaPaquete), new { codigo = entregaPaquete.CodigoEntrega }, entregaPaquete);
        }

        // Método PUT para actualizar una entrega existente
        [HttpPut("{codigo}")]
        public async Task<IActionResult> PutEntregaPaquete(string codigo, EntregaPaquete entregaPaquete)
        {
            if (codigo != entregaPaquete.CodigoEntrega)
            {
                return BadRequest();
            }

            _context.Entry(entregaPaquete).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntregaPaqueteExists(codigo))
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

        private bool EntregaPaqueteExists(string codigo)
        {
            return _context.EntregaPaquetes.Any(e => e.CodigoEntrega == codigo);
        }
    }
}
