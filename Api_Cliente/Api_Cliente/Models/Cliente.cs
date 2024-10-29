namespace Api_Cliente.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Cliente")]
    public class Cliente
    {
        public int CodigoCliente { get; set; }
        public string NombresCliente { get; set; }
        public string ApellidosCliente { get; set; }
        public int? NIT { get; set; }
        public string DireccionCliente { get; set; }
        public string CategoriaCliente { get; set; }
        public string EstadoCliente { get; set; }
    }
}
