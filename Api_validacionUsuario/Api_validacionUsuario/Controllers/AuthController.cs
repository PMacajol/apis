using Microsoft.AspNetCore.Mvc;
using Api_validacionUsuario.Models;
using Microsoft.EntityFrameworkCore;
using Api_validacionUsuario.Data;

namespace Api_validacionUsuario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == loginRequest.NombreUsuario);

            // Verifica la contraseña en texto plano
            if (usuario == null || usuario.Contrasena != loginRequest.Contrasena)
            {
                return Unauthorized(new { mensaje = "Usuario o contraseña incorrectos" });
            }

            return Ok(new { mensaje = "Autenticación exitosa" });
        }
    }
}
