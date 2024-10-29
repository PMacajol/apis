using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Api_NotaCredito.Models;

namespace Api_NotaCredito.Models
{
    [Table("NotaCredito")]
    public class NotaCredito
    {
        [Key]
        public string CodigoNotaCredito { get; set; }

        public DateTime? FechaNotaCredito { get; set; }

        public int CodigoCliente { get; set; }

        public string CodigoVenta { get; set; }

        public decimal? Monto { get; set; }

        public string Motivo { get; set; }

        public string EstadoNotaCredito { get; set; }
    }


}



