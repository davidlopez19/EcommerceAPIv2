using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.Infraestructura.Database.Entities.Productos
{
    [Table("Stock")]
    public class StockEntities
    {
        [Key]
        public int id_stock { get; set; }
        public int cantidad { get; set; }
        public int id_producto { get; set; }
    }
}
