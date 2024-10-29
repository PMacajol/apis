using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api_NotaCredito.Models;
using Api_NotaCredito.Data;

[Route("api/[controller]")]
[ApiController]
public class NotaCreditoController : ControllerBase
{
    private readonly AppDbContext _context;

    public NotaCreditoController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/NotaCredito
    [HttpGet]
    public async Task<ActionResult<IEnumerable<NotaCredito>>> GetNotaCreditos()
    {
        return await _context.NotaCreditos.ToListAsync();
    }

    // GET: api/NotaCredito/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<NotaCredito>> GetNotaCredito(string id)
    {
        var notaCredito = await _context.NotaCreditos.FindAsync(id);

        if (notaCredito == null)
        {
            return NotFound();
        }

        return notaCredito;
    }

    // POST: api/NotaCredito
    [HttpPost]
    public async Task<ActionResult<NotaCredito>> PostNotaCredito(NotaCredito notaCredito)
    {
        _context.NotaCreditos.Add(notaCredito);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            if (NotaCreditoExists(notaCredito.CodigoNotaCredito))
            {
                return Conflict();
            }
            else
            {
                throw;
            }
        }

        return CreatedAtAction(nameof(GetNotaCredito), new { id = notaCredito.CodigoNotaCredito }, notaCredito);
    }

    // PUT: api/NotaCredito/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutNotaCredito(string id, NotaCredito notaCredito)
    {
        if (id != notaCredito.CodigoNotaCredito)
        {
            return BadRequest();
        }

        _context.Entry(notaCredito).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!NotaCreditoExists(id))
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

    private bool NotaCreditoExists(string id)
    {
        return _context.NotaCreditos.Any(e => e.CodigoNotaCredito == id);
    }
}
