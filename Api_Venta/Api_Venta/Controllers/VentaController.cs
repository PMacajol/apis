using Microsoft.AspNetCore.Mvc;
using Api_Venta.Data;
using Api_Venta.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Venta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VentaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/venta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVentas()
        {
            return await _context.Ventas.ToListAsync();
        }

        // GET: api/venta/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetVenta(string id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }

            return venta;
        }

        // POST: api/venta
        [HttpPost]
        public async Task<ActionResult<Venta>> PostVenta(Venta venta)
        {
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVenta), new { id = venta.CodigoVenta }, venta);
        }

        // PUT: api/venta/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenta(string id, Venta venta)
        {
            if (id != venta.CodigoVenta)
            {
                return BadRequest();
            }

            _context.Entry(venta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(id))
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

        private bool VentaExists(string id)
        {
            return _context.Ventas.Any(e => e.CodigoVenta == id);
        }
    }
}
