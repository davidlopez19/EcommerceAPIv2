using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.Infraestructura.Database.Entities
{
    [Table("Cliente")]
    public class ClienteEntity
    {
        [Key]
        public int id_cliente { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string contrasena { get; set; }
        [Required]
        public string correo { get; set; }
        public string direccioncliente { get; set; }
        public int telefono { get; set; }
    }
}
