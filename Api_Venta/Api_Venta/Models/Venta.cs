using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api_Venta.Models;

namespace Api_Venta.Models
{
    [Table("Venta")]
    public class Venta
    {
        [Key]  // Indicamos que esta es la clave primaria
        public string CodigoVenta { get; set; }
        public DateTime? FechaVenta { get; set; }
        public int CodigoCliente { get; set; }
        public string CodigoProducto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? Total { get; set; }
        public string EstadoVenta { get; set; }
    }
}
