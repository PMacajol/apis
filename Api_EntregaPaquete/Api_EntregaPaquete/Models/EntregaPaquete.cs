using System.ComponentModel.DataAnnotations;
using System;
using Api_EntregaPaquete.Models;

namespace Api_EntregaPaquete.Models
{
    public class EntregaPaquete
    {
        [Key]
        public string CodigoEntrega { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public int CodigoCliente { get; set; }
        public string CodigoProducto { get; set; }
        public int? Cantidad { get; set; }
        public string DireccionEntrega { get; set; }
        public string EstadoEntrega { get; set; }
    }
}