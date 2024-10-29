using System.ComponentModel.DataAnnotations;

namespace Api_Producto.Models
{
    public class Producto
    {
        [Key] // Indica que esta propiedad es la clave primaria
        public string CodigoProducto { get; set; }

        public string Descripcion { get; set; }
        public string CodigoProveedor { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string UbicacionFisica { get; set; }
        public int? ExistenciaMinima { get; set; }
    }
}
