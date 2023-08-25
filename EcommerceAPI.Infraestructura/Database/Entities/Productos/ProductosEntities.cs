using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.Infraestructura.Database.Entities.Productos
{
    [Table("Producto")]
    public class ProductosEntities
    {
        [Key]
        public int id_producto { get; set; }
        public string descripcion { get; set; } = string.Empty;
        public double valor { get; set; }
        public string? imagen { get; set; } = string.Empty;
        public int id_estado { get; set; }
    }
}
