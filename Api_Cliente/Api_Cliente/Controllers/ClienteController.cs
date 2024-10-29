namespace Api_Cliente.Controllers
{
    using Api_Cliente.Data;
    using Api_Cliente.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Cliente
        [HttpPost]
        public async Task<IActionResult> PostCliente([FromBody] Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.CodigoCliente }, cliente);
        }

        // GET: api/Cliente/{id}
        // GET: api/Cliente/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // GET: api/Cliente/Nombre/{nombres}
        [HttpGet("Nombre/{nombres}")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientesByNombre(string nombres)
        {
            var clientes = await _context.Clientes
                                         .Where(c => c.NombresCliente.Contains(nombres))
                                         .ToListAsync();

            if (clientes == null || clientes.Count == 0)
            {
                return NotFound();
            }

            return Ok(clientes);
        }

        // GET: api/Cliente/Apellido/{apellidos}
        [HttpGet("Apellido/{apellidos}")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientesByApellido(string apellidos)
        {
            var clientes = await _context.Clientes
                                         .Where(c => c.ApellidosCliente.Contains(apellidos))
                                         .ToListAsync();

            if (clientes == null || clientes.Count == 0)
            {
                return NotFound();
            }

            return Ok(clientes);
        }

        // GET: api/Cliente/Nit/{nit}
        [HttpGet("Nit/{nit}")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientesByNit(int nit)
        {
            var clientes = await _context.Clientes
                                         .Where(c => c.NIT == nit)
                                         .ToListAsync();

            if (clientes == null || clientes.Count == 0)
            {
                return NotFound();
            }

            return Ok(clientes);
        }

        // GET: api/Cliente/Estado/{estado}
        [HttpGet("Estado/{estado}")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientesByEstado(string estado)
        {
            var clientes = await _context.Clientes
                                         .Where(c => c.EstadoCliente.Contains(estado))
                                         .ToListAsync();

            if (clientes == null || clientes.Count == 0)
            {
                return NotFound();
            }

            return Ok(clientes);
        }

        // PUT: api/Cliente/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, [FromBody] Cliente cliente)

        {
            if (id != cliente.CodigoCliente)
            {
                return BadRequest("El ID del cliente no coincide.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var clienteExistente = await _context.Clientes.FindAsync(id);
            if (clienteExistente == null)
            {
                return NotFound();
            }

            // Actualizar los campos del cliente existente
            clienteExistente.NombresCliente = cliente.NombresCliente;
            clienteExistente.ApellidosCliente = cliente.ApellidosCliente;
            clienteExistente.NIT = cliente.NIT;
            clienteExistente.DireccionCliente = cliente.DireccionCliente;
            clienteExistente.CategoriaCliente = cliente.CategoriaCliente;
            clienteExistente.EstadoCliente = cliente.EstadoCliente;

            _context.Entry(clienteExistente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.CodigoCliente == id);
        }
    }
}

