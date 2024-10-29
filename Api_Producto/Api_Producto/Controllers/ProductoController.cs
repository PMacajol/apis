using Microsoft.AspNetCore.Mvc;
using Api_Producto.Models;
using Api_Producto.Data;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ProductoController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductoController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Producto/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Producto>> GetProducto(string id)
    {
        var producto = await _context.Productos.FindAsync(id);

        if (producto == null)
        {
            return NotFound();
        }

        return producto;
    }

    // POST: api/Producto
    [HttpPost]
    public async Task<IActionResult> PostProducto([FromBody] Producto producto)
    {
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProducto), new { id = producto.CodigoProducto }, producto);
    }

    // PUT: api/Producto/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProducto(string id, [FromBody] Producto producto)
    {
        if (id != producto.CodigoProducto)
        {
            return BadRequest();
        }

        _context.Entry(producto).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Productos.Any(e => e.CodigoProducto == id))
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
}
