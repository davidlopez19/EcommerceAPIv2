using System.Text.Json.Serialization;

namespace EcommerceAPI.Common.Classes.Contracts.Productos
{
    public class StockContract
    {
        public int id_stock { get; set; }
        public int cantidad { get; set; }
        [JsonIgnore]
        public int id_producto { get; set; }
    }
}
