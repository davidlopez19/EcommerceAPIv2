namespace EcommerceAPI.Comunes.Classes.Contracts.Ecommerce
{
    public class ClienteContract
    {
        public int Consecutivo { get; set; }
        public string nombre { get; set; }
        public string contrasena { get; set; }
        public string correo { get; set; }
        public string direccioncliente { get; set; }
        public int telefono { get; set; }
    }
}
