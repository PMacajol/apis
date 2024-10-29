namespace Api_validacionUsuario.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Usuarios")]
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
    }
}
