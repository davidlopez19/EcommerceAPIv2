using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.Infraestructura.Database.Entities.Clientes
{

    [Table("Cliente")]
    public class ClientesEntities
    {
        [Key]
        public int id_cliente { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string correo { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public decimal telefono { get; set; }
        public string direccionfacturacion { get; set; } = string.Empty;
    }
}
